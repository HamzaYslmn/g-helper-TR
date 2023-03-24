using Microsoft.Win32.TaskScheduler;
using System.Diagnostics;
using System.Security.Principal;

public class Startup
{

    static string taskName = "GHelperTR";

    public static bool IsScheduled()
    {
        TaskService taskService = new TaskService();
        return (taskService.RootFolder.AllTasks.Any(t => t.Name == taskName));
    }

    public static void Schedule()
    {

        string strExeFilePath = Application.ExecutablePath;

        if (strExeFilePath is null) return;

        var userId = WindowsIdentity.GetCurrent().Name;

        TaskDefinition td = TaskService.Instance.NewTask();
        td.RegistrationInfo.Description = "GHelperTR Otomatik Başlatma";

        var trigger = new LogonTrigger { UserId = userId, Delay = TimeSpan.FromSeconds(10) }; // 10 saniye gecikme
        td.Triggers.Add(trigger);
        td.Actions.Add(strExeFilePath);

        td.Settings.StopIfGoingOnBatteries = false;
        td.Settings.DisallowStartIfOnBatteries = false;
        td.Settings.ExecutionTimeLimit = TimeSpan.Zero;

        Debug.WriteLine(strExeFilePath);
        Debug.WriteLine(userId);

        try
        {
            TaskService.Instance.RootFolder.RegisterTaskDefinition(taskName, td);
        } catch (Exception e)
        {
            MessageBox.Show(e.ToString(), "Scheduler Error", MessageBoxButtons.OK);
        }

    }

    public static void UnSchedule()
    {
        TaskService taskService = new TaskService();
        taskService.RootFolder.DeleteTask(taskName);
    }
}
