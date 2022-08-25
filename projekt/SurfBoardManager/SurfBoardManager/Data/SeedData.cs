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
                            Name = "Plormt",
                            Width = 5.55,
                            Length = 2.98,
                            Thickness = 3.41,
                            Volume = 23.1,
                            BoardType = Board.Type.Funboard
                        },
                        new Board
                        {
                            Name = "Happy board",
                            Width = 5.23,
                            Length = 1.83,
                            Thickness = 3.14,
                            Volume = 3.1,
                            BoardType = Board.Type.Funboard
                        },
                        new Board
                        {
                            Name = "Concrete funtime",
                            Width = 9.2,
                            Length = 5.56,
                            Thickness = 0.41,
                            Volume = 12.5,
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
