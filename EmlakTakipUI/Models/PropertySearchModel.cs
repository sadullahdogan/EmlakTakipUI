using DatabaseAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EmlakTakipUI.Models
{
    public class PropertySearchModel
    {

        [DisplayName("Metrekare")]
        public int? SquareMeter { get; set; }
        [DisplayName("Oda Sayısı")]
        public int? RoomCount { get; set; }
        [DisplayName("Salon Sayısı")]
        public int? LivingRoomCount { get; set; }
        [DisplayName("Bulunduğu Kat")]
        public int? Floor { get; set; }
        [DisplayName("Kat Sayısı")]
        public int? NumberOfFloors { get; set; }
        [DisplayName("Konut Türü")]
        public int? PropertyTypeId { get; set; }
        [DisplayName("Adres")]
        public string Adress { get; set; }
        [DisplayName("Isınma Tipi")]
        public WarmingType WarmingType { get; set; }
        [DisplayName("En düşük Fiyat")]
        public int? MinPrice { get; set; }
        [DisplayName("En Yüksek Fiyat")]
        public int? MaxPrice { get; set; }
        [DisplayName("İlan Tipi")]
        public State State { get; set; }





    }
}