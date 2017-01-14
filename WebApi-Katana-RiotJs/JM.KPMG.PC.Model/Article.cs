using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JM.KPMG.PC.Model
{
  
    public class Article : BaseEntity
    {
       // public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
        [StringLength(1000)]
        [Required]
        public string Body { get; set; }
        [StringLength(50)]
        [Required]
        public string AuthourName { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? LikeCount { get; set; }
        public ICollection<Comment> Posts { get; set; }
    }
}