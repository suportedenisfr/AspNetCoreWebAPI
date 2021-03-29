//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
*/

namespace SmartSchool2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professors: Denis, Vera, Isabella, Denis Filho");


            //("Professors: Denis, Vera, Isabella Denis Filho");
        }

    }

}
