using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HikingProject.Models
{
    [Table("hikes")]
    public class Hikes
    {
        //ID venant de la base
        [Key]
        public int ID { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? difficulty { get; set; }
        [Range(1,10000)]
        public double distance { get; set; }
        [Range(1,5000)]
        public int duration { get; set; }
        [Range(1,10000)]
        public int elevation_gain { get; set; }
        //public int link { get; set; }
    }
}
