using Aot.User.Store.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;

namespace Aot.User.Store.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //InsertData();
            //PrintData();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        //private static void InsertData()
        //{
        //    using (var context = new UserStoreDBContext())
        //    {
        //        // Creates the database if not exists
        //        context.Database.EnsureCreated();

        //        // Add User
        //        var user = new Entities.User
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "Talha Liaquat"
        //        };
        //        context.User.Add(user);

        //        // Add Group
        //        var group = new Entities.Group
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Title = ".net developers"
        //        };
        //        context.Group.Add(group);

        //        // Add Role
        //        var role = new Entities.Role
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "Administrator"
        //        };
        //        context.Role.Add(role);

        //        // Adds User Group Role
        //        context.UserGroupRole.Add(new Entities.UserGroupRole
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            User = user,
        //            Group = group,
        //            Role = role
        //        });

        //        // Saves changes
        //        context.SaveChanges();
        //    }
        //}

        //private static void PrintData()
        //{
        //    // Gets and prints all books in database
        //    using (var context = new UserStoreDBContext())
        //    {
        //        var users = context.User;
        //        var userGroupRoles = context.UserGroupRole.Include(x => x.User).Include(x => x.Role).Include(x => x.Group);
        //        foreach (var userGroupRole in userGroupRoles)
        //        {
        //            var data = new StringBuilder();
        //            data.AppendLine($"UserId: {userGroupRole.User.Name}");
        //            data.AppendLine($"GroupId: {userGroupRole.Group.Title}");
        //            data.AppendLine($"RoleId: {userGroupRole.Role.Name}");
        //            Console.WriteLine(data.ToString());
        //        }
        //    }
        //}
    }
}