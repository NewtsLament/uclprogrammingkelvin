using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SurfBoardManager.Models;
using System;
using System.Linq;

namespace SurfBoardManager.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SurfBoardManagerContext(serviceProvider.GetService<DbContextOptions<SurfBoardManagerContext>>()))
            {
                // Look for any movies.
                if (context.Board.Any() || context.Post.Any())
                {
                    return;   // DB has been seeded
                }
                {

                    context.Board.AddRange(
                        new Board
                        {
                            Name = "The Minilog",
                            Width = 21,
                            Length = 6,
                            Thickness = 2.75,
                            Volume = 38.8,
                            BoardType = Board.Type.Shortboard
                        },
                        new Board
                        {
                            Name = "The Wide Glider",
                            Width = 21.75,
                            Length = 7.1,
                            Thickness = 2.75,
                            Volume = 44.16,
                            BoardType = Board.Type.Funboard
                        },
                        new Board
                        {
                            Name = "The Golden Ratio",
                            Width = 21.85,
                            Length = 6.3,
                            Thickness = 2.9,
                            Volume = 43.22,
                            BoardType = Board.Type.Shortboard
                        },
                        new Board
                        {
                            Name = "Uranium untanium",
                            Width = 59.4,
                            Length = 7.5,
                            Thickness = 2.22,
                            Volume = 50,
                            BoardType = Board.Type.Shortboard
                        },
                        new Board
                        {
                            Name = "Warmachine",
                            Width = 48.2,
                            Length = 0.59,
                            Thickness = 9.91,
                            Volume = 8.58,
                            BoardType = Board.Type.Fish
                        }
                    );

                    context.SaveChanges();

                    context.Post.AddRange(
                        new Post
                        {
                            Price = 526.50,
                            Equipment = "Nothing!",
                            Board = context.Board.Find(5)
                        },
                        new Post
                        {
                            Price = 56.50,
                            Equipment = "Fin, Leash",
                            Board = context.Board.Find(1)
                        },
                        new Post
                        {
                            Price = 999.99,
                            Equipment = "Fin, Paddle, Pump, Leash",
                            Board = context.Board.Find(4)
                        },
                        new Post
                        {
                            Price = 500.63,
                            Equipment = "Paddle",
                            Board = context.Board.Find(3)
                        },
                        new Post
                        {
                            Price = 899.00,
                            Equipment = "Nothing!",
                            Board = context.Board.Find(4)
                        },
                        new Post
                        {
                            Price = 400.00,
                            Equipment = "Pump",
                            Board = context.Board.Find(5)
                        },
                        new Post
                        {
                            Price = 526,
                            Equipment = "",
                            Board = context.Board.Find(1)
                        }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
