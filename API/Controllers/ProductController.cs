using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helper;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private Database _database;

    public  ProductController(Database database){
        _database = database; 

    }


    //get all the products and paging at the same time to show in the home page 
    [HttpGet]
    public IActionResult GetAllProducts([FromQuery] int pagenumber , int pagesize){
        try{
            var data = _database.Products.Skip((pagenumber-1)*pagesize).Take(pagesize);
            return Ok(_database.Products); 
        }
        catch(System.Exception){
            return BadRequest();
        }
    }


    //add a list of product at the beg product 
    [HttpPost]
    public async Task<IActionResult> CreatProductAsync( Product p)
    {
        try{  
            await _database.Products.AddAsync(p);

            await _database.SaveChangesAsync(); 

            return Ok(p); 

            //we return to the caller again to be able to figre out the Id so I can know which one to be added 
        }
        catch(System.Exception){
            return BadRequest();
        }

    }



  


//get specific product based on the id 
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpecifyProduct(String id )
    {
        try{
            var product =await _database.Products.FindAsync(new Guid(id)); 
            return Ok(product); 
        }
        catch(System.Exception){
            return BadRequest();
        }
    }

    }
}