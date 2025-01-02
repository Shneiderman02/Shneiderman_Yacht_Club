using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YachtClubApp.Models;

namespace YachtClubApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage : ContentPage
    {
        public BookingPage()
        {
            InitializeComponent();
            LoadYachtOptions();
            SetDatePickerLimits();
        }

        private void LoadYachtOptions()
        {
            var yachts = new List<Yacht>
            {
                new Yacht { Id = 1, Name = "Yacht A" },
                new Yacht { Id = 2, Name = "Yacht B" },
                new Yacht { Id = 3, Name = "Yacht C" },
            };

            YachtPicker.ItemsSource = yachts;
            YachtPicker.ItemDisplayBinding = new Binding("Name");
        }

        private void SetDatePickerLimits()
        {
            DatePicker.MinimumDate = DateTime.Today;
            DatePicker.MaximumDate = DateTime.Today.AddYears(1);
        }

        private void OnBookButtonClicked(object sender, EventArgs e)
        {
            var selectedYacht = YachtPicker.SelectedItem as Yacht;
            if (selectedYacht == null)
            {
                DisplayAlert("Ошибка", "Пожалуйста, выберите яхту.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text))
            {
                DisplayAlert("Ошибка", "Пожалуйста, заполните все поля.", "OK");
                return;
            }

            // Дополнительная проверка выбранной даты
            if (DatePicker.Date < DateTime.Today)
            {
                DisplayAlert("Ошибка", "Выберите дату бронирования не ранее сегодняшней.", "OK");
                return;
            }

            // Для демонстрации просто отобразим данные
            string message = $"Бронирование:\nЯхта: {selectedYacht.Name}\nИмя: {NameEntry.Text}\nEmail: {EmailEntry.Text}\nДата: {DatePicker.Date.ToString("dd.MM.yyyy")}";
            DisplayAlert("Успешно", "Бронирование успешно!", "OK");

            // Очистим поля
            YachtPicker.SelectedItem = null;
            NameEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            DatePicker.Date = DateTime.Today;
        }
    }
}
