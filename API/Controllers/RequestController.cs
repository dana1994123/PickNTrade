using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {

        private Database _database;

        public  RequestController(Database database){
            _database = database; 
        }

        //get requests for specific product 
        [HttpGet("{id}")]
        public async Task<IActionResult> getRequestsForSpecificProductsAsync(String id ){
            try{
                var product = await _database.Products
                .Include( x=> x.Requests)
                .SingleOrDefaultAsync(x=> x.Id == new Guid(id));
                return Ok(product.Requests);
            }
             catch(System.Exception){
             return BadRequest();
            }

        }
        //add a request for a specific product
        [HttpPost("{id}")]
        public async Task<IActionResult> AddRequestToProductAsync(string id , Request r ){
            try{
                var product = await _database.Products.Include(x=>x.Requests).SingleOrDefaultAsync(x=> x.Id == new Guid(id));

                if(product == null){
                    return NotFound("No product found");
                }

                product.Requests.Add(r);
                await _database.SaveChangesAsync();
                return Ok(r);
            }
             catch(System.Exception){
                return BadRequest();
            }

        }
        
    }
}