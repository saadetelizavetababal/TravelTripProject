using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string CommentDetails { get; set; }
        public int BlogId {  get; set; }
        public virtual Blog Blog { get; set; }


    }
}