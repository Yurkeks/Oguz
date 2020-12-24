using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oguz.Data;
using Oguz.Models;

namespace Oguz.ControllersWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Pillow> GetPillows()
        {
            var pillowsList = _context.Pillows.Include(b => b.Brand).Include(c => c.Colors);
            foreach (var item in pillowsList)
            {
                item.ImageName = "/Images/Pillows/" + item.ImageName;
            }
            return pillowsList;
        }
    }
}

