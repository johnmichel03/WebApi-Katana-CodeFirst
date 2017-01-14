using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.KPMG.PC.Model
{
    public class Comment : BaseEntity
    {
        [StringLength(1000)]
        [Required]
        public string CommentedText { get; set; }
        public DateTime CommentedDate { get; set; }
        [StringLength(50)]
        [Required]
        public string CommentedPerson { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
