﻿using DatabasDemoFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDemoFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new DatabaseFirstDemoEntities3();
            var post = new Post()
            {
                Body = "Body",
                DatePublished = DateTime.Now,
                PostID = 1,
                Title = "Title"
            };
            context.Posts.Add(post);
            context.SaveChanges();
            Console.ReadLine();
        }
    }
}
