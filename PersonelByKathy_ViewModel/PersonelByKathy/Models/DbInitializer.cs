using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PersonelByKathy.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<PersonelByKathyContext>
    {
        protected override void Seed(PersonelByKathyContext context)
        {
            context.Users.Add(new User
            {
                Email = "email.gmail.com",
                FirstName = "Kathy",
                LastName = "Awesome",
                Password = "aweso",
                UserName = "kawesome"
            });

            context.Jobs.Add(new Job
            {
                City = "Detroit",
                Title = "Lawyer",
                Description = "Take peoples money",
                IsFullTime = true,
            });

            context.Jobs.Add(new Job
            {
                City = "Boston",
                Title = "Doctor",
                Description = "Save lives and make money",
                IsFullTime = true,
            });

            context.Jobs.Add(new Job
            {
                City = "London",
                Title = "Cook",
                Description = "Cook expensive meals and make someone else money",
                IsFullTime = false,
            });

            base.Seed(context);
        }
    }
}