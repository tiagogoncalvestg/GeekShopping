﻿using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 1;

        public string SubstringName()
        {
            if (Name.Length < 13) return Name + " ...";
            return $"{ Name.Substring(0, 12) } ...";
        }

        public string SubstringDescription()
        {
            if (Description.Length < 60) return Description;
            return $"{ Description.Substring(0, 55) } ...";
        }
    }
}
