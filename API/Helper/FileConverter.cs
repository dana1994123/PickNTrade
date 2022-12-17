using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helper
{
    public static class FileConverter
    {
        public static async  Task<String> ConvertByteToString(IFormFile imageFile){
            using(var ms = new MemoryStream()){
                imageFile.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);
                return s ; 
            }



        }
        
    }
}