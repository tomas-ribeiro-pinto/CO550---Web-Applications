using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurrencyConverter.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public string Amount { get; set; }
    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Email { get; set; }
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

        // Display Result in case the user has clicked the Convert button
        if (!String.IsNullOrEmpty(Amount))
        {
            result = Convert.ToDouble(Amount) * RATE;
            ViewData["Message"] = $"{Amount} GBP is {result.ToString("0.00")} EUR";
        }
        // Display message in case the user has clicked the Post button
        if (!String.IsNullOrEmpty(Name))
            ViewData["Hello"] = $"Hello {Name}! Your email adress is {Email}";
    }
}

