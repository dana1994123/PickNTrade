using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

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
            var profile =  _database.Profiles.FirstOrDefault(x=> x.Name == "Aeiman Gadafi");
            return Ok(profile); 
        }
         catch(System.Exception){
             return BadRequest();
        }
    }


    //add one Profile whenever we run the app 
    [HttpPost]
    public async Task<IActionResult> AddNewProfile(Profile newProfile){
        try{
            if(_database.Profiles.FirstOrDefault(x=> x.Name == "Aeiman Gadafi") == null ){
                 var p = new Profile{
                Name = "Aeiman Gadafi",
                Bio = "Professor Faculty of App'd Science &Tech",
                Email ="AeimanGadafi@gmail.com",
                Mobile = "905-449-4423",
                Avatar  ="data:image/jpeg;base64,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",
                PhoneNumber="647-888-4567",
                FacebookLink ="https://www.facebook.com/aeiman.gadafi",
                LinkinLink="https://www.linkedin.com/in/aeiman/",
                InstaLink ="https://www.instagram.com/aeimangadafi/"
            };
            await _database.Profiles.AddAsync(newProfile);
            _database.SaveChanges();
            }
            return Ok (newProfile); 
        }
        catch(System.Exception){
             return BadRequest();
        }
    }


    // [HttpDelete]
    // public async Task<IActionResult> deleteProfileAsync(){
    //     var p =  await  _database.Profiles.FindAsync(new Guid("36b328ff-85fe-4baf-99bf-d304f30cb964"));
    //     _database.Profiles.Remove(p);
    //      _database.SaveChanges();
    //     return Ok("gjkn");
    // }


    [HttpPut("update")]
    public async Task<IActionResult> updateProfileAsync(Profile newProfile ){
        //we only have one profile so
        try{
            var currentProfile = _database.Profiles.FirstOrDefault(x => x.Id == new Guid("36b328ff-85fe-4baf-99bf-d304f30cb964") );
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
        
    }
}