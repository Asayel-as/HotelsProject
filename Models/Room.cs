using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelsProject.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int RoomNum { get; set; }
        [Required]
        public decimal RoomPrice { get; set; }
        [Required]
        public int HotelID { get; set; }
    }
}
