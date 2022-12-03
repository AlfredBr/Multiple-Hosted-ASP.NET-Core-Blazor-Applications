using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace host.Pages;

public class IndexModel : PageModel
{
    public string Hostname { get; set; } = string.Empty;
    public void OnGet()
    {
        Hostname = System.Environment.MachineName;
    }
}
