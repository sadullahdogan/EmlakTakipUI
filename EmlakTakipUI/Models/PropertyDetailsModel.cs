using DatabaseAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EmlakTakipUI.Models
{
    public class PropertyDetailsModel
    {
        public int Id { get; set; }
        [ DisplayName("Metrekare")]
        public int SquareMeter { get; set; }
        [ DisplayName("Oda Sayısı")]
        public int RoomCount { get; set; }
        [ DisplayName("Salon Sayısı")]
        public int LivingRoomCount { get; set; }
        [DisplayName("Bulunduğu Kat")]
        public int Floor { get; set; }
        [DisplayName("Kat Sayısı")]
        public int NumberOfFloors { get; set; }
        [ DisplayName("Konut Türü")]
        public int PropertyTypeId { get; set; }
        [DisplayName("Konut Türü")]
        public virtual PropertyType PropertyType { get; set; }
        [DisplayName("Isınma Tipi")]
        public WarmingType WarmingType { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime Date { get; set; }
        [DisplayName("İlan Tipi")]
        public State State { get; set; }
        [DisplayName("İlanı Veren Kişi")]
        public string UserName { get; set; }
        [DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [DisplayName("E-Mail Adresi")]
        public string EMail { get; set; }
        [ DisplayName("Açıklama")]
        public string Description { get; set; }
        public string ImageName { get; set; }
        public double Price { get; set; }
    }
}