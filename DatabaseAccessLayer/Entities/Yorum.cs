using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities
{
    public class Yorum
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        [Required]
        public string İcerik { get; set; }
        public DateTime Tarih { get; set; }
        public string Kullanici { get; set; }
    }
}
