using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab10.Filters
{
    public class UserFilter : Attribute, IActionFilter
    {
        private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "logs", "users.txt");
        private static HashSet<string> usersIds = new HashSet<string>();
        public void OnActionExecuting(ActionExecutingContext context)
        {


        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string userId = GetUserId(context);
            if (!usersIds.Contains(userId))
            {
                string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                usersIds.Add(userId);
                string message = $"{Time} Унікальних користувачів {usersIds.Count}";
                File.AppendAllText(FilePath, message + Environment.NewLine);
            }
        }
        public string GetUserId(ActionExecutedContext context)
        {
            var userId = context.HttpContext.Request.Cookies["userId"];
            return userId;
        }




    }


}
