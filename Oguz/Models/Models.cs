using Oguz.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oguz.Data;

namespace Oguz.Models
{
    public class BaseDbObject : IDBObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class City : BaseDbObject
    {
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }

    public class Country : BaseDbObject
    {
        List<City> Cities { get; set; }
    }

    public class Order : BaseDbObject
    {
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string DateTime { get; set; }
        public List<Size> Sizes { get; set; }
        [Required]
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }
        public Guid? StyleId { get; set; }
        public Style Style { get; set; }
        public Guid? ColorId { get; set; }
        public Color Color { get; set; }
        public Guid MaterialId { get; set; }
        public Material Material { get; set; }
        public Guid? DiscountId { get; set; }
        public Discount Discount { get; set; }
        public Guid? CityId { get; set; }
        public City City { get; set; }
        public string PostCode { get; set; }
    }

    public class Style : BaseDbObject
    {
        public string ImageName { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
    }

    public enum Category
    {
        Curtains,
        Shades,
        Pillows,
        Accessories
    }

    public class Size
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Guid? OrderId { get; set; }
    }

    public class Material : BaseDbObject
    {
        public int Cost { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string FabricStructure { get; set; }
        public string CareInstructions { get; set; }

        public Guid? SizeId { get; set; }
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

    public class SMTPClient : BaseDbObject
    {
        public int Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
    }

    public class Discount : BaseDbObject
    {
        public int Value { get; set; }
        public int LinearMeters { get; set; }
    }
}
