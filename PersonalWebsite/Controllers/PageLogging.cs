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
                    //Exclude retrieving files
                    var split = url.Value.Split("/");
                    if (!split[split.Length - 1].Contains("."))
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
                var _db = scope.ServiceProvider.GetRequiredService<DBContext>();
                _db.VisitLogs.Add(new VisitLog(url, DateTime.Now));
                _db.SaveChanges();
            }            
        }
    }

}
