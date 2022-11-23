using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace host.Pages;

    public class IndexModel : PageModel
    {
		public Dictionary<(string, string), string> Links { get; set; } = new Dictionary<(string, string), string>
		{
			{ ("Menu", "gray"), "https://localhost:7004" },
			{ ("App 1", "red"), "https://localhost:7001" },
			{ ("App 2", "green"), "https://localhost:7002" },
			{ ("App 3", "blue"), "https://localhost:7003" },
		};

        public void OnGet()
        {
        }
    }
