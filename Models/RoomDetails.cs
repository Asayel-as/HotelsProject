using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelsProject.Models
{
    public class RoomDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Image1 { get; set; }
        [Required]
        [StringLength(50)]
        public string Image2 { get; set; }
        [Required]
        [StringLength(50)]
        public string Image3 { get; set; }
        public string? Food { get; set; }
        [Required]
        public string Services { get; set; }
        [Required]
        public int HotelID { get; set; }
        [Required]
        public int RoomID { get; set; }
        [Required]
        [StringLength (50)]
        public string Features { get; set; }
    }
}
