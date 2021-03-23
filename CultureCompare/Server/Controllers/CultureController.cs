using CultureCompare.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CultureCompare.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CultureController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CultureDTO> Get()
        {
            return CultureDTO.GetAllCultures();
        }
    }
}
