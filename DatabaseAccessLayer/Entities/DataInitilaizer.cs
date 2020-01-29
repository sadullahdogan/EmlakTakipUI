using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Entities
{
    public class DataInitilaizer: DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            List<PropertyType> types = new List<PropertyType>() {
            new PropertyType(){ Ad="Daire"},
            new PropertyType(){ Ad="Rezidans"},
            new PropertyType(){ Ad="Villa"},
            new PropertyType(){ Ad="İş Yeri"}


            };
            context.PropertyTypes.AddRange(types);
            context.SaveChanges();
            Array states = Enum.GetValues(typeof(State));
            Array warmingTypes = Enum.GetValues(typeof(WarmingType));
            List<Property> properties = new List<Property>();
            for (int i = 0; i < 15; i++) { 
           Property p= new Property(){
                Adress=FakeData.PlaceData.GetAddress(),
                Date=FakeData.DateTimeData.GetDatetime(),
                Description=FakeData.TextData.GetSentence(),
                Floor=FakeData.NumberData.GetNumber(1,10),
                ImageName="villa.jpg",
                LivingRoomCount=FakeData.NumberData.GetNumber(1,3),
                NumberOfFloors=FakeData.NumberData.GetNumber(1,3),
                Price=FakeData.NumberData.GetNumber(100000,1000000),
           //     PropertyType=types[FakeData.NumberData.GetNumber(types.Count)],
                PropertyTypeId=types[FakeData.NumberData.GetNumber(types.Count)].Id,
                RoomCount=FakeData.NumberData.GetNumber(1,7),
                SquareMeter=FakeData.NumberData.GetNumber(100,500), 
                State =(State)states.GetValue(FakeData.NumberData.GetNumber(states.Length-1)+1),
                WarmingType=(WarmingType)warmingTypes.GetValue(FakeData.NumberData.GetNumber(warmingTypes.Length-1)+1),
                Username="deneme"
 
            };
                properties.Add(p);
                
            }
            context.Properties.AddRange(properties);
            context.SaveChanges();
             var model = new Company();
            model.Adress = "CompanyAdress";
            model.EMail = "company.company@company.com";
            model.Fax = "11111111111";
            model.Logo = "logo.png";
            model.ManagerName = "Manager";
            model.ManagerSurname = "ManagerLAstname";
            model.Phone = "222222222222";
            context.Companies.Add(model);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
