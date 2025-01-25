using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Media;
using Pruebas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Helpers
{
    internal class HelperForInicioClass
    {

        public static string WhatDayIsByDate(DateTime date)
        {
            int dayOfTheWeek = (int)date.DayOfWeek;
            string returnDayName = "";
            if (dayOfTheWeek == 0) dayOfTheWeek = 7;

            switch(dayOfTheWeek)
            {
                case 1: 
                    returnDayName = "Monday";
                    break;
                case 2:
                    returnDayName = "Thursday";
                        break;
                case 3:
                    returnDayName = "Wednesday";
                    break;
                case 4:
                    returnDayName = "Thuesday";
                    break;
                case 5:
                    returnDayName = "Friday";
                    break;
                case 6:
                    returnDayName = "Saturday";
                    break;
                case 7:
                    returnDayName = "Sunday";
                    break;
            }
            return returnDayName;
        }
        public static ImageBrush buildImageSourceByUrl(Root forecastCity, string validation )
        {
            ImageBrush imageToSet = new();
            if (validation == "Forecast")
            {
                imageToSet.ImageSource = new BitmapImage(new Uri($"https:{forecastCity.image}"));
            }
           
            if(validation == "Now")
            {
                imageToSet.ImageSource = new BitmapImage(new Uri($"https:{forecastCity.imageNow}"));         
            }
            return imageToSet;
        }
    }
}
