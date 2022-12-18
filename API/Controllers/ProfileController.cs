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
    public class ProfileController : ControllerBase
    {
         private Database _database;
    public  ProfileController(Database database){
        _database = database; 

    }

    [HttpGet("AllProfile")]
    public IActionResult getAllProfile(){
        try{
            return Ok(_database.Profiles);

        }
        catch(System.Exception){
             return BadRequest();
        }
    }

     //get specific profile
    [HttpGet]
    public async Task<IActionResult> GetSpecificProfileAsync()
    {
        try{
        //get specific profile based on the id 
            var profile =  _database.Profiles.Include(x=> x.MyListingProduct)
            .FirstOrDefault(x=> x.Name == "Aeiman Gadafi");
            return Ok(profile); 
        }
         catch(System.Exception){
             return BadRequest();
        }
    }


    //add one Profile whenever we run the app 
    [HttpPost]
    public async Task<IActionResult> AddNewProfile(){
        try{
            if(_database.Profiles.FirstOrDefault(x=> x.Name == "Aeiman Gadafi") == null ){
                 var p = new Profile{
                Name = "Aeiman Gadafi",
                Bio = "Professor Faculty of App'd Science &Tech",
                Email ="AeimanGadafi@gmail.com",
                Mobile = "905-449-4423",
                Avatar  ="https://cdn-icons-png.flaticon.com/512/2490/2490505.png",
                PhoneNumber="647-888-4567",
                FacebookLink ="https://www.facebook.com/aeiman.gadafi",
                LinkinLink="https://www.linkedin.com/in/aeiman/",
                InstaLink ="https://www.instagram.com/aeimangadafi/"
            };
            await _database.Profiles.AddAsync(p);
            _database.SaveChanges();
            return Ok (p); 
            }
            return Ok("there is a profile");
            
        }
        catch(System.Exception){
             return BadRequest();
        }
    }


    [HttpDelete]
    public async Task<IActionResult> deleteProfileAsync(){
        var p =  await  _database.Profiles.FindAsync(new Guid("4f4f8320-6ae5-41aa-bd1e-efe680a13fcd"));
        _database.Profiles.Remove(p);
         _database.SaveChanges();
        return Ok("delete");
    }


    [HttpPut("update")]
    public async Task<IActionResult> updateProfileAsync(Profile newProfile ){
        //we only have one profile so
        try{
            var currentProfile = _database.Profiles.FirstOrDefault(x=> x.Name == "Aeiman Gadafi");;
            //var currentProfile = await _database.Profiles.FindAsync(new Guid("36b328ff-85fe-4baf-99bf-d304f30cb964"));
            currentProfile.Name = newProfile.Name;
            currentProfile.Avatar = newProfile.Avatar;
            currentProfile.Bio = newProfile.Bio;
            currentProfile.Email = newProfile.Email;
            currentProfile.FacebookLink = newProfile.FacebookLink;
            currentProfile.InstaLink = newProfile.InstaLink;
            currentProfile.LinkinLink = newProfile.LinkinLink;
            currentProfile.PhoneNumber = newProfile.PhoneNumber;
            currentProfile.Mobile = newProfile.Mobile;
            _database.SaveChanges();
            return Ok (currentProfile);
        }
         catch(System.Exception){
            return BadRequest();
        }
    }

//get a specific product for a specific profile 
    [HttpGet("specificProfileProduct")]
    public IActionResult getSpecificProductProfile(){
        var productForSpecificProfile = _database.Products.Where(x=> x.Owner == "Aeiman Gadafi");
        return Ok(productForSpecificProfile);
    }
        
    }
}