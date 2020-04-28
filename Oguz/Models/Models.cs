﻿using Oguz.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Oguz.Models
{
    public class BaseDbObject : IDBObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Order : BaseDbObject
    {
        public string Price { get; set; }
        public string DateTime { get; set; }
        public string Color { get; set; }
        public List<Size> Sizes { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Guid MaterialId { get; set; }
        public Material Material { get; set; }

    }

    public class Size
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Customer : BaseDbObject 
    {
        public string Email { get; set; }
        public int Amount { get; set; }
        public bool IsSubscribe { get; set; }
    }

    public class Material : BaseDbObject
    {
        public int Cost { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string FabricStructure { get; set; }
        public string CareInstructions { get; set; }

        public List<Color> Colors { get; set; } 

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; } 
    }

    public class Color : BaseDbObject
    {
        public string Photo { get; set; }
    }

    public class Brand : BaseDbObject
    {
    }

    public class Category : BaseDbObject
    {
    }

    public class SMTPClient : BaseDbObject
    {
        public int Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
    }

}
