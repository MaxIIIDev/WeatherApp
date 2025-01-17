//using Pruebas.Models;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Pruebas.Services
//{
//    public class ServiceToParseForecastAPIInformationToClimaClass
//    {

//        public  ServiceToParseForecastAPIInformationToClimaClass() { }

//        public List<ClimaProvincia> ParseInformationFromAPIToClimaClass(List<Root> apiDataOpenToWork)
//        {
//            List<ClimaProvincia> listWithForecastDay = new List<ClimaProvincia>();
//            try
//            {
//                foreach (Root day in apiDataOpenToWork)
//                {

//                    ClimaProvincia climaProvincia = new ClimaProvincia();

//                    climaProvincia.date = day.date;
//                    climaProvincia.name = day.name;
//                    climaProvincia.latitude = day.latitude;
//                    climaProvincia.longitude = day.longitude;
//                    climaProvincia.maxTemperature = day.maxTemperature;
//                    climaProvincia.minTemperature = day.minTemperature;
//                    climaProvincia.precipitation = day.precipitation;
//                    climaProvincia.wind = day.wind;
//                    climaProvincia.image = day.image;
//                    climaProvincia.textImage = day.textImage;

//                    //listWithForecastDay.Add(climaProvincia);

//                }
//            }
//            catch(Exception ex)
//            {
//                Debug.WriteLine(ex.Message);
//            }
//            return listWithForecastDay;
//        }

//    }
//}
