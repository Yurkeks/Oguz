using Oguz.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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

        public List<Size> Sizes { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid StyleId { get; set; }
        public Style Style { get; set; }
        public Guid ColorId { get; set; }
        public Color Color { get; set; }
        public Guid MaterialId { get; set; }
        public Material Material { get; set; }
    }

    public class Style : BaseDbObject
    {
        public string ImageName { get; set; }
        public Category Category { get; set; }
    }

    public enum Category
    {
        Шторы,
        Гардины,
        Подушки,
        Аксессуары
    }

    public class Size
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }

    public class Material : BaseDbObject
    {
        public int Cost { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string FabricStructure { get; set; }
        public string CareInstructions { get; set; }

        public Guid SizeId { get; set; }
        public Size Size { get; set; }
        public List<Color> Colors { get; set; }
        public Category Category { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
    }

    public class Color : BaseDbObject
    {
        public string ImageName { get; set; }
        public Guid MaterialId { get; set; }
    }

    public class Brand : BaseDbObject
    {
    }

    public class Customer : BaseDbObject
    {
        public string Email { get; set; }
        public int Amount { get; set; }
        public bool IsSubscribe { get; set; }
    }

    public class SMTPClient : BaseDbObject
    {
        public int Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
    }

}
