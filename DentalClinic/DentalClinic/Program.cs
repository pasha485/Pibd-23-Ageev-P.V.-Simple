using DentalClinic.Forms;
using Unity; // <--- ОБЯЗАТЕЛЬНО добавить эту строку

namespace DentalClinic;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // 1. Создаем контейнер
        var container = IoCContainer.Configure();

        // 2. Запускаем MainForm, передавая управление контейнеру
        Application.Run(container.Resolve<MainForm>());
    }
}