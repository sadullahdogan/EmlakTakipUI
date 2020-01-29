using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseAccessLayer.Entities
{
    public class Property
    {
        public int Id { get; set; }
        [Required, DisplayName("Metrekare")]
        public int SquareMeter { get; set; }
        [Required, DisplayName("Oda Sayısı")]
        public int RoomCount { get; set; }
        [Required, DisplayName("Salon Sayısı")]
        public int LivingRoomCount { get; set; }
        [DisplayName("Bulunduğu Kat")]
        public int Floor { get; set; }
        [DisplayName("Kat Sayısı")]
        public int NumberOfFloors { get; set; }
        [Required, DisplayName("Konut Türü")]
        public int PropertyTypeId { get; set; }
        [DisplayName("Konut Türü")]
        public virtual PropertyType PropertyType { get; set; }
        [DisplayName("Isınma Tipi")]
        public WarmingType WarmingType { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime Date { get; set; }
        [DisplayName("İlan Tipi")]
        public State State { get; set; }
        public string Username { get; set; }
        [Required, DisplayName("Açıklama")]
        public string Description { get; set; }
        [Required, DisplayName("Adres")]
        public string Adress { get; set; }
        public string ImageName { get; set; }
        public double Price { get; set; }
    }
    public enum WarmingType {
        [Display(Name = "Seçiniz")]
        Empty,
        [Display(Name ="Soba")]
        Stove,
        [Display(Name ="Kalorifer")]
        Heater,
        [Display(Name ="Klima")]
        AirConditioning
    }
    public enum State
    {
        [Display(Name = "Seçiniz")]
        Empty,
        [Display(Name ="Kiralık")]
        Rent,
        [Display(Name ="Satılık")]
        Sale,
        [Display(Name = "Günlük Kiralık")]
        RentForDaily
    }

}