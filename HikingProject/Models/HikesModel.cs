
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
        
        public string? name { get; set; }
        
        public string? difficulty { get; set; }
        
        public double distance { get; set; }
        public int duration { get; set; }
        public int elevation_gain { get; set; }
    }
}
