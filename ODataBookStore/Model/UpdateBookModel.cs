using ODataBookStore.Entity;

namespace ODataBookStore.Model
{
    public class UpdateBookModel
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int? PressId { get; set; }
        public Address Location { get; set; }
    }
}
