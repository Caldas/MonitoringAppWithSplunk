using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Web.Configurations;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly Random random = new Random(DateTimeOffset.UtcNow.Millisecond);

        private readonly ILogger<IndexModel> logger;
        private readonly ApplicationOptions applicationOptions;

        public IndexModel(ILogger<IndexModel> logger, IOptions<ApplicationOptions> applicationOptions)
        {
            this.logger = logger;
            this.applicationOptions = applicationOptions.Value;
        }

        [DisplayName("Username")]
        public string Username { get; set; }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var userCookieValue = Request.Cookies[applicationOptions.UserCookieName];
            if (string.IsNullOrWhiteSpace(userCookieValue))
            {
                Username = "Anonymous " + random.Next(0, 10000);
                SetUserNameAtCookie();
                logger.LogInformation($"New user created: `{Username}`");
            }
            else
            {
                Username = userCookieValue;
                logger.LogInformation($"Old user returned: `{Username}`");
            }

            base.OnPageHandlerExecuting(context);
        }

        public void OnGet()
        {
            
        }

        public void OnPost(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                logger.LogInformation($"User renamed: `{Username}` is now `{username}`");
                Username = username;
                SetUserNameAtCookie();
            }
        }

        private void SetUserNameAtCookie()
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(2)
            };
            Response.Cookies.Append(applicationOptions.UserCookieName, Username, cookieOptions);
        }
    }
}
