using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar2.ViewModels
{
    public class ArabaModel
    {
        public string arabaId { get; set; }
        public string arabaadi { get; set; }
        public string arabakategori { get; set; }
        public string arabakategoriAdi { get; set; }
        public Nullable<int> kiralikdurum { get; set; }
        public string vites { get; set; }
        public string imgUrl { get; set; }
        public int arabaModel { get; set; }
        public int kirUcret { get; set; }
    }
}