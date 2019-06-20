using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Models;

namespace WebSite.ViewModels
{
    public class PostAndComment
    {
        public List<Comment> Comments { get; set; }
        public List<Post> Posts { get; set; }

        public PostAndComment ()
        {
            Comments = new  List<Comment>();
            Posts = new List<Post>();

        }
    }
}