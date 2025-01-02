namespace YachtClubApp.Models
{
    public class Yacht
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        public string Image { get; set; } // Путь к изображению
        public string Description { get; set; } // Описание яхты 
    }
}
