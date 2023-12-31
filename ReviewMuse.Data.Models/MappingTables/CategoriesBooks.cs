﻿namespace ReviewMuse.Data.Models.MappingTables
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CategoriesBooks
    {
        public CategoriesBooks()
        {
            this.IsActive = true;
        }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [Required]
        public virtual Book Book { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
