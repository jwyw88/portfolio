using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StevesHeadlines.Models;
using System.Data.Entity;

namespace StevesHeadlines.Migrations
{
    public class Configuration : DropCreateDatabaseIfModelChanges<StevesHeadlinesContext>
    {
        protected override void Seed(StevesHeadlinesContext context)
        {
            context.Stories.Add(new Story
            {
                Title = "Animal Voted to Office",
                Posted = DateTime.Parse("2014-01-27"),
                Details = "An animal was unanimously voted into office in the 3rd riding in the Windsor region beating out 3 lawyers. Progress for the future expected."
            });

            context.Stories.Add(new Story
            {
                Title = "Local Man Bests Millionaire Kathy",
                Posted = DateTime.Parse("2014-01-01"),
                Details = "Recently it was proven that Steve is better than Kathy. Kathy is expected to deliver her response by weeks end by way of angry tweets. Stay tuned."
            });

            context.Stories.Add(new Story
            {
                Title = "Winter Snow to Fall Shockingly Again Soon",
                Posted = DateTime.Parse("2014-01-15"),
                Details = "Winter weather reported this winter. Snow has caught the region by suprise during this season of snow. What's next, rain in spring?!?"
            });

            base.Seed(context);
        }
    }
}