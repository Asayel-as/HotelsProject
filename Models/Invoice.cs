using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelsProject.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int HotelID { get; set; }
        [Required]
        public int RoomIDs { get; set; }
        [Required]
        public int RoomDetelsID { get; set; }
        public DateTime dateInvoice { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public decimal Net { get; set; }
        [Required]
        public DateTime DateFrom { get; set;}
        [Required]
        public DateTime DateTo { get; set;}

    }
}
