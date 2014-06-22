using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StevesHeadlines.Models
{
    public class Story
    {
        public int StoryId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Posted { get; set; }

        [Required]
        public string Details { get; set; }
    }
}