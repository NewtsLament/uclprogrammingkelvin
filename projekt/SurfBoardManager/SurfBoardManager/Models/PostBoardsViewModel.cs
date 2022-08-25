using System.ComponentModel.DataAnnotations;

namespace SurfBoardManager.Models
{
    public class PostBoardsViewModel
    {
        [Required]
        public Post Post { get; set; }
        public IEnumerable<Board> Boards { get; set; }
        [Display(Name = "Surfboards")]
        [Required]
        public int ChosenBoardId { get; set; }
    }
}
