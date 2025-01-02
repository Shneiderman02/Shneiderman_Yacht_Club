using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YachtClubApp.Models;

namespace YachtClubApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogPage : ContentPage
    {
        public CatalogPage()
        {
            InitializeComponent();
            LoadYachts();
        }

        private void LoadYachts()
        {
            var yachts = new List<Yacht>
            {
                new Yacht
                {
                    Id = 1,
                    Name = "Yacht A",
                    Size = "40ft",
                    Price = "$5000/неделя",
                    Image = "yacht_a.jpg", // Указываем имя файла с расширением для Android
                    Description = "Yacht A – комфортная яхта среднего размера, идеально подходящая для семейных путешествий."
                },
                new Yacht
                {
                    Id = 2,
                    Name = "Yacht B",
                    Size = "50ft",
                    Price = "$7000/неделя",
                    Image = "yacht_b.jpg", // Указываем имя файла с расширением для Android
                    Description = "Yacht B – просторная яхта с современным дизайном и всеми удобствами для длительных круизов."
                },
                new Yacht
                {
                    Id = 3,
                    Name = "Yacht C",
                    Size = "60ft",
                    Price = "$9000/неделя",
                    Image = "yacht_c.jpg", // Указываем имя файла с расширением для Android
                    Description = "Yacht C – роскошная яхта премиум-класса с эксклюзивным интерьером и дополнительными опциями."
                },
            };

            YachtListView.ItemsSource = yachts;
        }

        // Обработчик события нажатия на элемент списка (опционально)
        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var selectedYacht = e.Item as Yacht;

            // Отображаем детальную информацию о яхте
            await DisplayAlert(selectedYacht.Name, selectedYacht.Description, "OK");

            // Снимаем выделение
            ((ListView)sender).SelectedItem = null;
        }
    }
}
