using Foompany.Services.SampleService1.Models;
using Microsoft.EntityFrameworkCore;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.SampleService1.Modules
{
    public class DefaultModule : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Autowire]
        dbSchemaContext db;

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> Default()
        {
            var sb = new StringBuilder();

            sb.AppendLine("---------");
            sb.AppendLine("  Blogs");
            sb.AppendLine("---------");
            var blogNames = await db.Blogs.Select(b => b.Name)
                                          .ToListAsync();
            foreach (var name in blogNames)
                sb.AppendLine(name);

            sb.AppendLine("");
            sb.AppendLine("");

            sb.AppendLine("-------------------");
            sb.AppendLine(" First Blog Posts");
            sb.AppendLine("-------------------");
            var firstBlog = await db.Blogs.OrderBy(b => b.Id).FirstOrDefaultAsync();
            if (firstBlog != null)
            {
                var posts = await db.Posts.Where(p => p.BlogId == firstBlog.Id)
                                           .Select(p => new { p.Id, p.Title })
                                           .ToListAsync();
                foreach (var p in posts)
                    sb.AppendLine($"id:{p.Id} - {p.Title}");
            }

            //done
            return sb.ToString();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public async Task<string> Seed()
        {
            // Create new blog
            Console.WriteLine("Inserting a new blog");
            var blog = new Blog
            {
                Name = $"Blog {new Random().Next(0, 100)}"
            };

            // Add a post
            blog.Posts = new List<Post>()
            {
                new Post
                {
                    Title = "Hello World",
                    Content = "I wrote an app using EF Core!"
                },
                new Post
                {
                    Title = "Another random post " + new Random().Next(0, 100),
                    Content = "Post with random title!"
                }
            };

            //add blog and posts to db
            await db.AddAsync(blog);

            //save changes
            await db.SaveChangesAsync();

            //done
            return $"Created blog with name '{blog.Name}'";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
