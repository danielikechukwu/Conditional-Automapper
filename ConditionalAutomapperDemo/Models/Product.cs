﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ConditionalAutomapperDemo.Models
{
    public class Product
    {
        public int Id { get; set; }

        [NoMap]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
    }
}
