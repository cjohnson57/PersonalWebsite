using PersonalWebsite.Models;

namespace PersonalWebsite.Middleware
{
    public class PageLogging
    {
        private readonly RequestDelegate _next;

        public PageLogging(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            //Retrieve the requested URL
            var url = context.Request.Path;

            if (url.HasValue)
            {
                //Handle index specially
                if (url.Value == "/")
                {
                    LogPageVisit("Index", serviceProvider);
                }
                else
                {
                    //Ensure it is actually a valid URL
                    var endpoint = context.GetEndpoint();
                    //Exclude retrieving files
                    var split = url.Value.Split("/");
                    if (endpoint != null && !split[split.Length - 1].Contains("."))
                    {
                        LogPageVisit(url.Value, serviceProvider);
                    }
                }
                
            }
            

            //Call the next middleware in the pipeline
            await _next(context);
        }

        private void LogPageVisit(string url, IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var _statsDb = scope.ServiceProvider.GetRequiredService<StatsDBContext>();
                _statsDb.VisitLogs.Add(new VisitLog(url, DateTime.Now));
                _statsDb.SaveChanges();
            }
        }
    }

}
