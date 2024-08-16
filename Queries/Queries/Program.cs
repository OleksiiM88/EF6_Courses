
using System;
using System.Data.Entity;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            PlutoContext context = new PlutoContext();

            var author2 = context.Authors.Include(x => x.Courses).Single(a => a.Id == 2);
            context.Courses.RemoveRange(author2.Courses);
            context.Authors.Remove(author2);

            //context.Courses.Add(new Course
            //{
            //    Name = "New Course3",
            //    Description = "New Desc",
            //    FullPrice = 19.95f,
            //    Level = 1,
            //    AuthorId = 1
            //});

            context.SaveChanges();

            Console.WriteLine("Author added");
            Console.ReadLine();

            var courses1 = context.Courses;

            foreach (var item in courses1)
            {
                Console.WriteLine(item.Name);
            }

            var query =
                from c in context.Courses 
                where c.Level == 1 && c.Author.Id == 1
                orderby c.Level descending, c.Name
                select new { Name = c.Name, Author = c.Author };

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.Name);
            //}

            var courses = context.Courses
                .Where(c => c.Name.Contains("c#"))
                .OrderBy(c => c.Name);

            //foreach (var item in courses)
            //    Console.WriteLine(item.Name);

            var query2 = from c in context.Courses
                         group c by c.Level into g
                         select g;

            //foreach (var item in query2)
            //{
            //    Console.WriteLine($"{item.Key}, {item.Count()}");

            //}

            var query3 = from a in context.Authors
                         join c in context.Courses on a.Id equals c.AuthorId into g 
                         select g;


            var tags = context.Courses
                .Where(x => x.Level == 1)
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.Level)
                .SelectMany(x => x.Tags)
                .Distinct();

            //foreach (var t in tags)
            //{
            //        Console.WriteLine(t.Name);

            //}

            var groups = context.Courses.GroupBy(c => c.Level);

            //foreach (var item in groups)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine(i.Name);
            //    }
            //}

            context.Courses
                .Join(context.Authors, 
                        c => c.AuthorId, 
                        a => a.Id, 
                        (course, author) => new { CourseName = course.Name, AuthorName = author.Name });

            Console.ReadLine();
        }
    }
}
