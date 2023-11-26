using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab10.Filters
{
    public class LogFilter : Attribute,IActionFilter
    {
        private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "logs", "actionlog.txt");
        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string NameController = context.RouteData.Values["controller"].ToString();
            string NameAction = context.RouteData.Values["action"].ToString();
            string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string message = $"Controller:{NameController} Action: {NameAction} Time: {Time}";
            File.AppendAllText(FilePath, message  + Environment.NewLine);
        }
    }
}
