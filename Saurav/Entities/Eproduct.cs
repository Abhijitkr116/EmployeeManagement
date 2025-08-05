using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saurav.Entities
{
    public class Eproduct
    {
        [Key] //Primary key Identity
        public int Id { get; set; }
        public string? ProductName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        public string? ProductBrand { get; set; } 
        public string? Category { get; set; }
    }
}
