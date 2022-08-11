namespace my_books2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rate { get; set; }
        public User User { get; set; }
    }
}
