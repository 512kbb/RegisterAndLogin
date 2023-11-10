using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RegisterAndLogin.Views.Shared
{
    public class _UserForm : PageModel
    {
        private readonly ILogger<_UserForm> _logger;

        public _UserForm(ILogger<_UserForm> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}