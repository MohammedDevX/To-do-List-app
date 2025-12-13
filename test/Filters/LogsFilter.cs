using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

public class LogsFilter : ActionFilterAttribute
{
    private readonly string logFile;

    public LogsFilter()
    {
        logFile = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "todo-log.txt");
        Directory.CreateDirectory(Path.GetDirectoryName(logFile)!);
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        var message = $"Executing action {context.ActionDescriptor.DisplayName} " +
            $"avec params {JsonSerializer.Serialize(context.ActionArguments)}";
        WriteLogToFile(message);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);
        string message;
        message = $"Executed action {context.ActionDescriptor.DisplayName} avec succes";
        WriteLogToFile(message);
    }

    private void WriteLogToFile(string message)
    {
        File.AppendAllText(logFile, $"[{DateTime.Now}] {message}{Environment.NewLine}");
    }
}
