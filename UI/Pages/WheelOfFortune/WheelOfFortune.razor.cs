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
    private double AngularVelocity { get; set; } = 0;
    private bool IsSpinning { get; set; } = false;
    
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
        AngularVelocity = Random.Shared.NextDouble() * 2.0 + 4.0; // Random between 4.0 and 6.0
        IsSpinning = true;
        
        StartAnimationLoop();
    }

    private void ResetPosition()
    {
        IsSpinning = false;
        AngularVelocity = 0;
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
        if (!IsSpinning) return;

        // Apply friction based on velocity
        if (AngularVelocity > 0.2)
        {
            AngularVelocity *= 0.98; // Hard friction
        }
        else if (AngularVelocity > 0.1)
        {
            AngularVelocity *= 0.99; // Medium friction
        }
        else if (AngularVelocity > 0.05)
        {
            AngularVelocity *= 0.995; // Soft friction
        }
        else if (AngularVelocity > 0.025)
        {
            AngularVelocity *= 0.9975; // Softer friction
        }
        else
        {
            AngularVelocity *= 0.9999; // Super soft friction
            
            // Increase friction when over target sector
            var currentSector = GetCurrentSectorIndex();
            if (currentSector == SelectedQuestionNumber - 1)
            {
                double scaledFriction = Sectors.Count / 100.0;
                AngularVelocity *= 0.95 - scaledFriction;
            }
        }

        if (AngularVelocity < 0.002)
        {
            AngularVelocity = 0;
            IsSpinning = false;
            animationTimer?.Stop();
        }

        CurrentAngle += AngularVelocity;
        CurrentAngle %= TAU;

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
