using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities
{
   public class DataInitilaizer:DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Yorum first = new Yorum() { Baslik = "İlk Yorum", Tarih = DateTime.Now, İcerik = "İlk yorum başarı ile oluşturuldu" };
            YasakliKelime ilkKelime = new YasakliKelime() { Kelime = "yasak" };
            context.Yorumlar.Add(first);
            context.YasakliKelimeler.Add(ilkKelime);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
