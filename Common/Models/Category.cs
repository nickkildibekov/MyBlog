using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Common.Models
{
    public sealed class Category
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        public DateTime? DateCreated { get; set; }

        public ICollection<Post> Posts { get; set; }
        public Category()
        {
            DateCreated = DateTime.Now;
            Posts = new List<Post>();
        }
    }
}