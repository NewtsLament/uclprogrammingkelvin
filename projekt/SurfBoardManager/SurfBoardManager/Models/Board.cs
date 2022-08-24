using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfBoardManager.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public double Width { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Length { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Thickness { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Volume { get; set; }
        public BoardType? BoardType { get; set; }
    }
}