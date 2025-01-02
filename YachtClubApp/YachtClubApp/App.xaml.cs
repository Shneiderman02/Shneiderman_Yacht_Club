using Xamarin.Forms;

namespace YachtClubApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Обработка при запуске приложения
        }

        protected override void OnSleep()
        {
            // Обработка при сворачивании приложения
        }

        protected override void OnResume()
        {
            // Обработка при возобновлении приложения
        }
    }
}
