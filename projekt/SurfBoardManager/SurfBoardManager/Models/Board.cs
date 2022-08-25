using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfBoardManager.Models
{
    public class Board
    {
        public enum Type {
            Shortboard,
            Funboard,
            Fish,
            Longboard,
            SUP
        }
        public int Id { get; set; }
        [Display(Name = "Navn")]
        public string? Name { get; set; }
        [Display(Name = "Bredde")]
        [Column(TypeName="decimal(18,2)")]
        public double Width { get; set; }
        [Display(Name = "Længde")]
        [Column(TypeName = "decimal(18,2)")]
        public double Length { get; set; }
        [Display(Name = "Tykkelse")]
        [Column(TypeName = "decimal(18,2)")]
        public double Thickness { get; set; }
        [Display(Name = "Volumen")]
        [Column(TypeName = "decimal(18,2)")]
        public double Volume { get; set; }
        [Display(Name="Board type")]
        [Column(TypeName = "INT")]
        public Type? BoardType { get; set; }
    }
}