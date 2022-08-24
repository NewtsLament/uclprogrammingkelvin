using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfBoardManager.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public double Price { get; set; }
        public virtual ICollection<Equipment>? Equipment { get; set; }
        public Board? Board { get; set; }
    }
}
