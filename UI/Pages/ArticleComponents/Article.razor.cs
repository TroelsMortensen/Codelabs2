using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using UI.Data.Models;
using UI.State;

namespace UI.Pages.ArticleComponents;

public partial class Article : ComponentBase
{
    [Parameter] public string TutorialsName { get; set; } = string.Empty;
    [Parameter] public string Owner { get; set; } = string.Empty;
    [Parameter, SupplyParameterFromQuery] public string? PageNumber { get; set; }

    [Inject] public NavigationManager NavMgr { get; set; } = null!;
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;
    [Inject] public ArticlesState ArticlesState { get; set; } = null!;

    private string CleanedTutorialsName => HttpUtility.UrlDecode(TutorialsName)
        .Substring(TutorialsName.LastIndexOf('/') + 1)
        .RemoveFirst("Session \\d{1,2} ")
        .Replace(" - ", "");

    private List<ArticlePage> pages = new();
    private int stepIndex = 0;
    private ArticlePage? currentPage = null!;
    private bool isDropdownVisible = false;

    protected override async Task OnInitializedAsync()
    {
        pages = await ArticlesState.GetArticlePages(Owner, TutorialsName);
        SetPageIndex();
        currentPage = pages[stepIndex];
    }

    private void SetPageIndex() =>
        stepIndex =
            int.TryParse(PageNumber, out int pageNumber)
                ? pageNumber - 1
                : 0;

    private async Task ChangePage(int step)
    {
        stepIndex += step;
        currentPage = null;
        await Task.Delay(1); // gives time to rerender page, with no content, so this causes a scroll to top, when the page is changed. Beautiful hack.
        currentPage = pages[stepIndex];
    }

    private void GoToPage(int idx)
    {
        stepIndex = idx;
        currentPage = pages[stepIndex];
        isDropdownVisible = false;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JsRuntime.InvokeVoidAsync("Prism.highlightAll");
        await JsRuntime.InvokeVoidAsync("MathJax.typeset");
        await JsRuntime.InvokeVoidAsync("initializeMermaid");
        await JsRuntime.InvokeVoidAsync("renderMermaid");
    }


    private void ToggleDropdown() =>
        isDropdownVisible = !isDropdownVisible;

    private void CloseDropdown() =>
        isDropdownVisible = false;
}

public static class RegexExtensions
{
    public static string RemoveFirst(this string text, string pattern) =>
        Regex.Replace(text, pattern, "");
}