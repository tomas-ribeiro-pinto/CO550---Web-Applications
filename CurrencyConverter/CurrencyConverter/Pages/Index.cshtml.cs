using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurrencyConverter.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public string Amount { get; set; }
    private const double RATE = 1.14;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public void OnPost()
    {
        double result;
        result = Convert.ToDouble(Amount) * RATE;
        ViewData["Message"] = $"{Amount} GBP is {result.ToString("0.00")} EUR";
    }
}

