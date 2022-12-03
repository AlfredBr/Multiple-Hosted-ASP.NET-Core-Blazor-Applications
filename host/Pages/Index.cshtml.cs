using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace host.Pages;

public class IndexModel : PageModel
{
    public string HostName { get; set; } = string.Empty;
    public string MachineName { get; set; } = string.Empty;
    public void OnGet()
    {
		HostName = Request.Host.Host;
        MachineName = System.Environment.MachineName;
    }
}
