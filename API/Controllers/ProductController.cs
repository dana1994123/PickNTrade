using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helper;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public IActionResult GetAllProducts(){
        try{
            var data = _database.Products;
            return Ok(_database.Products); 
        }
        catch(System.Exception){
            return BadRequest();
        }
    }


    //add a product 
    [HttpPost]
    public async Task<IActionResult> CreatProductAsync( Product p)
    {
        try{  
            //add the product to the products and to the profile listing 
            var profile =await  _database.Profiles
            .Include(x=> x.MyListingProduct)
            .FirstOrDefaultAsync(x=> x.Name ==  "Aeiman Gadafi");

            profile.MyListingProduct.Append(p); 
            await _database.SaveChangesAsync(); 


            await _database.Products.AddAsync(p);
            

            await _database.SaveChangesAsync(); 

            return Ok(p); 

            //we return to the caller again to be able to figre out the Id so I can know which one to be added 
        }
        catch(System.Exception){
            return BadRequest();
        }

    }

    
//get specific products based on the profile id 
    [HttpGet("Listing")]
    public async Task<IActionResult> GetSpecificProducts( )
    {
        try{
            var profileProducts = _database.Products.Where(x=>x.Owner == "Aeiman Gadafi");

            return Ok(profileProducts); 
        }
        catch(System.Exception){
            return BadRequest();
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpecifyProduct(String id ){
        try{
            var product =await _database.Products.FindAsync(new Guid(id)); 
            if(product == null){
                return NotFound("There is no product with this id"); 
            }
            _database.Products.Remove(product); 
            _database.SaveChanges();
            return Ok("Product Removed Successfully");
        }
        catch(System.Exception){
            return BadRequest("wrong id.. Please try again!");
        }
    }




    [HttpGet("{id}")]
    public IActionResult getPRoductById(String id){
        try{
            var product = _database.Products.Include(x=> x.Requests).FirstOrDefaultAsync(x=> x.Id == new Guid(id));

            if(product == null){
                return NotFound("There is no product with this id");
            }
            return Ok(product);

        }
        catch(System.Exception){
            return BadRequest("wrong id.. Please try again!");
        }

    }

    }


    

}