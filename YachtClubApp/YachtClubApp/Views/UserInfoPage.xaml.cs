using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YachtClubApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInfoPage : ContentPage
    {
        public UserInfoPage()
        {
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            var name = Preferences.Get("UserName", string.Empty);
            var email = Preferences.Get("UserEmail", string.Empty);
            var phone = Preferences.Get("UserPhone", string.Empty);

            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(phone))
            {
                SavedInfoLabel.Text = $"Имя: {name}\nEmail: {email}\nТелефон: {phone}";
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(PhoneEntry.Text))
            {
                DisplayAlert("Ошибка", "Пожалуйста, заполните все поля.", "OK");
                return;
            }

            Preferences.Set("UserName", NameEntry.Text);
            Preferences.Set("UserEmail", EmailEntry.Text);
            Preferences.Set("UserPhone", PhoneEntry.Text);

            DisplayAlert("Успешно", "Информация сохранена!", "OK");

            // Обновим отображение сохраненной информации
            SavedInfoLabel.Text = $"Имя: {NameEntry.Text}\nEmail: {EmailEntry.Text}\nТелефон: {PhoneEntry.Text}";

            // Очистим поля ввода
            NameEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            PhoneEntry.Text = string.Empty;
        }
    }
}
