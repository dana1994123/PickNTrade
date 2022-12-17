using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private Database _database;
        public  StoreController(Database database){
            _database = database; 
        }

        [HttpGet]
        public IActionResult GetStoreDetails(){
            return Ok(_database.Store);
        }

        
    }
}