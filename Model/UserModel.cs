using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.UserModel

{
    public class User
    {   
        [Key]
        [Required]
        public string username{get;set;}
        [Required]
        public string password{get;set;}

    }
}