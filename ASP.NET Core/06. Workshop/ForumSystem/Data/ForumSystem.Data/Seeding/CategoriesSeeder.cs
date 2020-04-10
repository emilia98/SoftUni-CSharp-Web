namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<(string Name, string ImageUrl)>
            {
                ("Sport", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Sport_balls.svg/200px-Sport_balls.svg.png"),
                ("Coronavirus", "https://lh3.googleusercontent.com/proxy/rOSZgiGUiNypIQPA32K2GyFJQeAJMHaqiT0yOIue561OVMWuhvIqEA95bYOCnfBlWQ9Nddwpkp9NvhoNsvt4buJdso_J5NLDsHbQro7RPxbBGgtPM3ecCUqMDx8qaBdq3ertzRSLSiYLOYPageZaINJ0RJ-6hMLtJgR9Ju2KUxoHRL_7fn_gDi-X-lS_K5Kk6SqgfukmsAy7VH7-jLpMpGDNZA"),
                ("News", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTVlesGdJXpxvu_bJO-4-svyQubcqNVPp5IktTwhgUdFjBhQ1oy&usqp=CAU"),
                ("Music", "https://www.bensound.com/bensound-img/happyrock.jpg"),
                ("Programming", "https://learnworthy.net/wp-content/uploads/2019/12/Why-programming-is-the-skill-you-have-to-learn.jpg"),
                ("Cats", "https://www.rd.com/wp-content/uploads/2019/11/cat-10-e1573844975155.jpg"),
                ("Dogs", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSCJsqP-Lq0x83G3tDIdWyDkzpMX8UaOxmO2yjB6McNjgkBP6U3&usqp=CAU"),
            };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Description = category.Name,
                    Title = category.Name,
                    ImageUrl = category.ImageUrl,
                });
            }
        }
    }
}
