using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace YorumTakipRubikTekUI.Models
{
    public class RegisterModel
    {
        [Required, DisplayName("Adınız")]
        public string Name { get; set; }
        [Required, DisplayName("Soy Adınız")]
        public string Surname { get; set; }
    }
}