using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace UI.Pages.WheelOfFortune;

public partial class WheelOfFortune : ComponentBase, IDisposable
{
    [Inject] public IJSRuntime JSRuntime { get; set; } = null!;
    [Inject] public NavigationManager NavMgr { get; set; } = null!;

    private ElementReference canvasElement;
    private System.Timers.Timer? animationTimer;
    private const double PI = Math.PI;
    private const double TAU = 2 * PI;
    private const double InitialAngle = -PI / 2; // Start at top

    // Predefined sectors with colors and labels
    private readonly Sector[] PreDefSectors = [
        new Sector("#0bf", "1"),
        new Sector("#fb0", "2"),
        new Sector("#0fb", "3"),
        new Sector("#b0f", "4"),
        new Sector("#f0b", "5"),
        new Sector("#bf0", "6"),
        new Sector("#09ff00", "7"),
        new Sector("#676bff", "8"),
        new Sector("#ff2020", "9"),
        new Sector("#0f9a00", "10"),
        new Sector("#bb54ff", "11"),
        new Sector("#ff8000", "12"),
    ];

    // State
    private int NumberOfSlices { get; set; } = 2;
    private List<Sector> Sectors { get; set; } = new();
    private List<double> Weights { get; set; } = new();
    private int SelectedQuestionNumber { get; set; } = 0;
    private bool ShowSpinText { get; set; } = true;
    private bool ShowWeightBar { get; set; } = false;
    
    // Animation state
    private double CurrentAngle { get; set; } = InitialAngle;
    private bool IsSpinning { get; set; } = false;
    
    // Deterministic rotation properties
    private double TotalRotationRemaining { get; set; } = 0;
    private double TotalRotationInitial { get; set; } = 0;
    private double TargetAngle { get; set; } = 0;
    private double MaxRotationPerFrame { get; set; } = 0.3; // Maximum rotation per frame in radians (calculated dynamically)
    private const double EaseFactor = 0.75; // Ease-out curve factor (0.5 = gradual deceleration)
    private const double TargetDurationSeconds = 5.0; // Target duration for spin in seconds
    private const double FramesPerSecond = 60.0; // Animation frame rate
    
    // Computed properties for UI
    private string CurrentSectorLabel => GetCurrentSectorLabel();
    private string CurrentSectorColor => GetCurrentSectorColor();
    private string SpinButtonText => ShowSpinText ? "SPIN" : SelectedQuestionNumber.ToString();
    private string SpinButtonColor => IsSpinning ? CurrentSectorColor : (ShowSpinText ? "#fff" : GetSelectedSectorColor());
    private double Arc => TAU / Sectors.Count;
    private int CanvasDiameter { get; set; } = 300;

    private List<WeightSegment> WeightDistributionSegments
    {
        get
        {
            if (Sectors.Count == 0 || Weights.Count == 0) return new List<WeightSegment>();
            
            double totalWeight = Weights.Sum();
            if (totalWeight == 0) return new List<WeightSegment>();

            return Sectors.Select((sector, index) => new WeightSegment
            {
                Label = sector.Label,
                Color = sector.Color,
                Weight = Weights[index],
                WidthPercentage = (Weights[index] / totalWeight) * 100.0
            }).ToList();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        InitializeSectors();
        InitializeWeights();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await InitializeCanvas();
        }
    }

    private void InitializeSectors()
    {
        Sectors = PreDefSectors.Take(NumberOfSlices).ToList();
    }

    private void InitializeWeights()
    {
        Weights = Enumerable.Range(0, NumberOfSlices).Select(_ => 1.0).ToList();
    }

    private async Task InitializeCanvas()
    {
        // Wait a bit for DOM to be ready
        await Task.Delay(100);
        
        // Get container size and calculate canvas dimensions
        var size = await JSRuntime.InvokeAsync<int>("getCanvasSize", "wheelOfFortune");
        if (size > 0)
        {
            CanvasDiameter = size;
        }
        else
        {
            // Fallback to a reasonable default
            CanvasDiameter = 500;
        }
        
        await RedrawWheel();
    }

    private async Task RedrawWheel()
    {
        if (Sectors.Count > 0 && CanvasDiameter > 0)
        {
            await JSRuntime.InvokeVoidAsync("redrawWheel", "wheel", Sectors.Select(s => new { color = s.Color, label = s.Label }).ToArray(), CanvasDiameter);
        }
    }

    private async void OnSliceCountChanged(ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out int count) && count >= 1 && count <= 12)
        {
            NumberOfSlices = count;
            InitializeSectors();
            InitializeWeights();
            await RedrawWheel();
            StateHasChanged();
        }
    }

    private void Spin()
    {
        if (IsSpinning) return; // Cannot spin while already spinning

        SelectedQuestionNumber = GetQuestion() + 1;
        ShowSpinText = false; // Hide "SPIN" text, will show selected number
        
        // Calculate target sector angle range
        int targetSectorIndex = SelectedQuestionNumber - 1;
        double sectorArc = TAU / Sectors.Count;
        
        // Reverse-engineer GetCurrentSectorIndex() logic to find the correct target angle
        // GetCurrentSectorIndex() uses: index = (int)Math.Floor(Sectors.Count - adjustedAngle / TAU * Sectors.Count)
        // For target index i, the adjustedAngle range is:
        // (Sectors.Count - i - 1) / Sectors.Count * TAU < adjustedAngle <= (Sectors.Count - i) / Sectors.Count * TAU
        
        // Pick a random point within the target sector's range in adjusted coordinate system
        double random = Random.Shared.NextDouble();
        double adjustedAngle = (Sectors.Count - targetSectorIndex - 1 + random) / Sectors.Count * TAU;
        
        // Convert from adjusted coordinate system back to CurrentAngle coordinate system
        // adjustedAngle = (normalizedAngle - InitialAngle + TAU) % TAU
        // So: normalizedAngle = (adjustedAngle + InitialAngle) % TAU
        double normalizedAngle = (adjustedAngle + InitialAngle + TAU) % TAU;
        TargetAngle = normalizedAngle;
        
        // Calculate angle difference from current to target
        double currentNormalized = (CurrentAngle % TAU + TAU) % TAU;
        double angleToTarget = TargetAngle - currentNormalized;
        
        // Normalize angle difference to shortest path (-PI to PI range)
        if (angleToTarget > PI) angleToTarget -= TAU;
        if (angleToTarget < -PI) angleToTarget += TAU;
        
        // Add 15-20 full rotations (random between 15-20)
        int extraRotations = 15 + Random.Shared.Next(6); // 15 to 20 inclusive
        double extraRotationAmount = extraRotations * TAU;
        
        // If angleToTarget is negative, we need to go the other way, so add extra rotations first
        if (angleToTarget < 0)
        {
            angleToTarget += TAU; // Make it positive by going the long way
        }
        
        // Calculate total rotation needed
        TotalRotationRemaining = angleToTarget + extraRotationAmount;
        TotalRotationInitial = TotalRotationRemaining;
        
        // Calculate MaxRotationPerFrame to complete in approximately TargetDurationSeconds
        // For ease-out curve, we need to account for the deceleration
        // Approximate: with ease-out factor, average speed ≈ maxSpeed * (1 / (1 + easeFactor))
        double targetFrames = TargetDurationSeconds * FramesPerSecond;
        double averageRotationPerFrame = TotalRotationInitial / targetFrames;
        // Adjust for ease-out curve: average ≈ max * (1 / (1 + easeFactor))
        MaxRotationPerFrame = averageRotationPerFrame * (1 + EaseFactor);
        
        IsSpinning = true;
        StartAnimationLoop();
    }

    private void ResetPosition()
    {
        IsSpinning = false;
        TotalRotationRemaining = 0;
        TotalRotationInitial = 0;
        CurrentAngle = InitialAngle;
        ShowSpinText = true; // Show "SPIN" text again
        StateHasChanged();
    }

    private void ToggleWeightBar()
    {
        ShowWeightBar = !ShowWeightBar;
        StateHasChanged();
    }

    private int GetQuestion()
    {
        // Calculate total weight
        double maxValue = Weights.Sum();

        // Generate random number
        double randomNumber = maxValue * Random.Shared.NextDouble();

        // Find the selected sector
        double current = 0;
        int questionNumber = 0;
        for (int i = 0; i < Weights.Count; i++)
        {
            current += Weights[i];
            if (randomNumber <= current)
            {
                questionNumber = i;
                break;
            }
        }

        // Reduce selected sector's weight by 50%
        double prevWeight = Weights[questionNumber];
        Weights[questionNumber] *= 0.5;

        // Distribute the weight difference to other sectors
        double increaseToOthers = (prevWeight - Weights[questionNumber]) / (Weights.Count - 1);
        for (int i = 0; i < Weights.Count; i++)
        {
            if (i != questionNumber)
            {
                Weights[i] += increaseToOthers;
            }
        }

        return questionNumber;
    }

    private void StartAnimationLoop()
    {
        animationTimer?.Dispose();
        animationTimer = new System.Timers.Timer(16); // ~60fps
        animationTimer.Elapsed += OnAnimationFrame;
        animationTimer.AutoReset = true;
        animationTimer.Start();
    }

    private void OnAnimationFrame(object? sender, System.Timers.ElapsedEventArgs e)
    {
        if (!IsSpinning || TotalRotationRemaining <= 0) return;

        // Calculate progress (starts at 1.0, goes to 0.0)
        double progress = TotalRotationRemaining / TotalRotationInitial;
        
        // Apply ease-out curve: gradual deceleration
        double easeProgress = Math.Pow(progress, EaseFactor);
        
        // Calculate rotation amount for this frame
        double rotationThisFrame = MaxRotationPerFrame * easeProgress;
        
        // Ensure we don't overshoot
        if (rotationThisFrame > TotalRotationRemaining)
        {
            rotationThisFrame = TotalRotationRemaining;
        }
        
        // Rotate the wheel
        CurrentAngle += rotationThisFrame;
        CurrentAngle %= TAU;
        
        // Subtract from remaining rotation
        TotalRotationRemaining -= rotationThisFrame;
        
        // Stop when we've completed the rotation
        if (TotalRotationRemaining <= 0)
        {
            TotalRotationRemaining = 0;
            // Ensure we end exactly at the target angle
            CurrentAngle = TargetAngle;
            IsSpinning = false;
            animationTimer?.Stop();
        }

        InvokeAsync(StateHasChanged);
    }

    private int GetCurrentSectorIndex()
    {
        if (Sectors.Count == 0) return 0;
        // Normalize angle to 0-TAU range
        double normalizedAngle = (CurrentAngle % TAU + TAU) % TAU;
        // Convert to index (accounting for initial offset of -PI/2 which points to top)
        // The arrow points to the top, so we need to adjust
        double adjustedAngle = (normalizedAngle - InitialAngle + TAU) % TAU;
        int index = (int)Math.Floor(Sectors.Count - adjustedAngle / TAU * Sectors.Count) % Sectors.Count;
        // Ensure index is positive
        if (index < 0) index = (index + Sectors.Count) % Sectors.Count;
        return index;
    }

    private string GetCurrentSectorLabel()
    {
        var index = GetCurrentSectorIndex();
        return index >= 0 && index < Sectors.Count ? Sectors[index].Label : "";
    }

    private string GetCurrentSectorColor()
    {
        var index = GetCurrentSectorIndex();
        return index >= 0 && index < Sectors.Count ? Sectors[index].Color : "#fff";
    }

    private string GetSelectedSectorColor()
    {
        if (SelectedQuestionNumber > 0 && SelectedQuestionNumber <= Sectors.Count)
        {
            return Sectors[SelectedQuestionNumber - 1].Color;
        }
        return "#fff";
    }

    public void Dispose()
    {
        animationTimer?.Dispose();
    }

    private record Sector(string Color, string Label);
    
    private class WeightSegment
    {
        public string Label { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public double Weight { get; set; }
        public double WidthPercentage { get; set; }
    }
}
