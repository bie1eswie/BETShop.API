using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShop.API.Controllers
{
		[Route("api/[controller]")]
		[ApiController]
		[EnableCors("CorsPolicy")]
		public class BaseController : ControllerBase
		{
		}
}
