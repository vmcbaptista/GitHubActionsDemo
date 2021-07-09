using GitHubActionsDemo.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace GitHubActionsDemo.Pages
{
    public class IndexModel : PageModel
    {
        public IReadOnlyList<Message> Messages { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly IMessageService _service;

        public IndexModel(ILogger<IndexModel> logger, IMessageService service)
        {
            _logger = logger;
            _service = service;
        }

        public void OnGet()
        {
            Messages = _service.GetMessages();
        }
    }
}
