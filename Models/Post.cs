using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [HiddenInput]
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }
        
        [NotMapped]
        [BindingBehavior(BindingBehavior.Never)]
        public string Identifier {
            get
            {
                return $"{Title?.Replace(' ', '-')}-{Id}";
            }
        }
    }
}
