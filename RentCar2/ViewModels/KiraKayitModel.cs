using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar2.ViewModels
{
    public class KiraKayitModel
    {
        public string kiraKayitId { get; set; }
        public string kimKiraladi { get; set; }
        public string kimeKiraladi { get; set; }
        public string kirTarih { get; set; }
        public string iadeTarih { get; set; }
        public string kirArabaId { get; set; }

        public ArabaModel kirArabaBilgisi { get; set; }
        public UyeModel kimeKiraladiBilgisi { get; set; }
        public UyeModel kimKiraladiBilgisi { get; set; }





    }
}