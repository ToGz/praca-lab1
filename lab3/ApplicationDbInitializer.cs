using lab3.Models;
using System;
using System.Linq;

namespace lab3
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            InitializeBooks(context);
            InitializePeople(context);
        }

        private static void InitializeBooks(ApplicationDbContext context)
        {
            if (context.Books.Any())
            {
                return;
            }

            var book = new Book { Title = "Ania z Zielonego wzgórza", DatePublished = DateTime.Parse("01.05.1911") };

            context.Books.Add(book);
            context.SaveChanges();
        }

        private static void InitializePeople(ApplicationDbContext context)
        {
            if (context.Persons.Any())
            {
                return;
            }

            var persons = new Person[]
            {
                new Person{Name="Komasz",Surname="Kądzik",IsAwesome=true},
                new Person{Name="Garol", Surname="Tozubek", IsAwesome=true}
            };

            context.Persons.AddRange(persons);
            context.SaveChanges();
        }
    }
}
