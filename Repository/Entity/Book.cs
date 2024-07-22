using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Repository.Entity
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int? PressId {  get; set; }
        public Address Location { get; set; }
        [ForeignKey(nameof(PressId))]
        public Press? Press { get; set; }
    }
}
