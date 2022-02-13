using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.MembershipTypes.Any() && context.Genre.Any() && context.Customers.Any() && context.Books.Any())
                {
                    Console.WriteLine("Database already seeded");
                    return;
                }

                context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0,
                    Name = "Pay as You GO"
                },
                new MembershipType
                {
                    Id = 2,
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10,
                    Name = "Monthly"
                },
                new MembershipType
                {
                    Id = 3,
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15,
                    Name = "Quaterly"
                },
                new MembershipType
                {
                    Id = 4,
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20,
                    Name = "Yearly"
                });

                //context.Genre.AddRange(
                //new Genre
                //{
                //    Id = 1,
                //    Name = "Fantasy",
                //},
                //new Genre
                //{
                //    Id = 2,
                //    Name = "Drama"
                //});

                context.Customers.AddRange(
                new Customer
                {
                    Name = "John Lock",
                    Birthdate = new DateTime(2000, 1, 1),
                    HasNewsletterSubscribed = true,
                    MembershipTypeId = 1
                },
                new Customer
                {
                    Name = "Jan Kowalski",
                    Birthdate = new DateTime(2002, 2, 2),
                    HasNewsletterSubscribed = false,
                    MembershipTypeId = 2
                },
                new Customer
                {
                    Name = "Janusz Tracz",
                    Birthdate = new DateTime(2003, 1, 9),
                    HasNewsletterSubscribed = false,
                    MembershipTypeId = 2,
                });

                context.Books.AddRange(
                new Book
                {
                    ReleaseDate = new DateTime(2000, 1, 1),
                    AuthorName = "Jim Butcher",
                    GenreId = 1,
                    Name = "Storm Front",
                    NumberInStock = 10,
                },
                new Book
                {
                    ReleaseDate = new DateTime(2005, 1, 1),
                    AuthorName = "Shannon Hale",
                    GenreId = 1,
                    Name = "Princess Academy",
                    NumberInStock = 22,
                },
                new Book
                {
                    ReleaseDate = new DateTime(1996, 3, 12),
                    AuthorName = "William Shakespeare",
                    GenreId = 2,
                    Name = "Twelfth Night",
                    NumberInStock = 2,
                });
                context.SaveChanges();
            }
        }
    }
}