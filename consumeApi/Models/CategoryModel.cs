using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace consumeApi.Models
{
    public class CategoryModel
    {



        public int CategoryID { get; set; }

        [StringLength(15,ErrorMessage ="Category NAme cannot be greater than 15 chars")]
        public string CategoryName { get; set; }

        public string Description { get; set; }
        
        
        public byte[] Picture { get; set; }



    }
}