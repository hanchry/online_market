using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Algorithm.Model;
using Database.Persistance.Readers;
using market.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Test : ControllerBase
    {
        private readonly ILogger<Test> _logger;
        

        private Calculator calculator;

        public Test(Calculator calculator)
        {
            this.calculator = calculator;
        }
        
        [HttpGet]
        public async Task<ActionResult<Result>> Get()
        {
            try
            {
                return StatusCode(200, calculator.getBestOf(4, true));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(400, "adding not succesfull");
            }
        }
    }
}