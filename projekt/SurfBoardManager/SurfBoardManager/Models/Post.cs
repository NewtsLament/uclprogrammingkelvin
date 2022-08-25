using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfBoardManager.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Display(Name = "Pris")]
        [Required]
        [Column(TypeName="decimal(18,2)")]
        public double Price { get; set; }
        [Display(Name = "Udstyr")]
        [Required]
        [Column(TypeName = "NVarChar(255)")]
        public string? Equipment { get; set; }
        //Virtual for lazy loading, no name, since it is not directly displayed.
        public virtual Board? Board { get; set; }
    }
}
