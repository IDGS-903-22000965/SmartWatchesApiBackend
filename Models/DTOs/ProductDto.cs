﻿namespace SmartWatchesAPI.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int Stock { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public bool IsActive { get; set; }
    }
}