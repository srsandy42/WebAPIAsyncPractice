﻿using System.ComponentModel.DataAnnotations;

namespace WebApiProjectAsync.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }
       
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Category { get; set; }
    }
}
