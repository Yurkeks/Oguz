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
    public class GetProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable <Curtains> GetCurtains()
        {
            var curtainsList = _context.Curtains.Include(b => b.Brand).Include(c => c.Colors);
            foreach (var item in curtainsList)
            {
                item.ImageName = "/Images/Curtains/" + item.ImageName;
            }
            return curtainsList;
        }
    }
}