using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Common.Models
{
    public class Post
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name= "Description")]
        public string Description { get; set; }
        [Display(Name = "Content")]
        public string Content { get; set; }
        [Display(Name = "Attach File")]
        public byte[] ImageData { get; set;}
        public byte[] ImageThumbnail { get; set; }
        private int ContentLimit = 950;
        public string ContentTrimmed
        {
            get
            {
                if (Content.Length > ContentLimit)
                    return Content.Substring( 0, ContentLimit ) + "...";
                else
                    return Content;
            }
        }
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display( Name = "Posted" )]
        public DateTime PostedDateTime { get; set; }
        [Display( Name = "Modified" )]
        public DateTime? ModifiedDateTime { get; set; }
        public string ImageMimeType { get; set; }
        public string Author { get; set; }
        public string DefaultImageName { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeclined { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Post ()
        {
            IsApproved = false;
            IsDeclined = false;
            IsDeleted = false;
            PostedDateTime = DateTime.Now;
            Comments = new List<Comment>();
        }

    }
}