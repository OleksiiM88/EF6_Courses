﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations
{
    public class Course
    {
        public Course()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public int Level { get; set; }

        public float FullPrice { get; set; }

        [ForeignKey("Author")]
        public int AuthprId {  get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}