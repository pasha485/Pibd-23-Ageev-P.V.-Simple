using DentalClinic.Forms;
using Serilog;
using Unity;

namespace DentalClinic;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // 1. Настраиваем Serilog (пишем логи в папку Logs)
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        ApplicationConfiguration.Initialize();

        // 2. Настраиваем IoC-контейнер
        var container = IoCContainer.Configure();

        // 3. Запускаем программу
        Application.Run(container.Resolve<MainForm>());

        // 4. При закрытии программы корректно сохращаем логи
        Log.CloseAndFlush();
    }
}