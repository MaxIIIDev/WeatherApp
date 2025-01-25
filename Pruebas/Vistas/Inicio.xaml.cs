using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Pruebas.Services;
using Microsoft.Extensions.DependencyInjection;
using Pruebas.Models;
using Microsoft.UI.Xaml.Media.Imaging;
using Pruebas.Helpers;
using BruTile.Wms;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pruebas.Vistas
{
    /// <summary>
    /// 
    /// </summary>
    public partial  class Inicio : Page
    {
        ServiceGetAllCityInLocalData? _ServiceGetAllCityInLocalData { get; }
        int count { get; set; } = 0; //count for iterate a list
        public Inicio()
        {
            _ServiceGetAllCityInLocalData = ((App)Application.Current).ServiceProvider.GetService<ServiceGetAllCityInLocalData>(); //Service for obtain all local data with forecast city
            this.InitializeComponent();
            setEmptyAllPanels(); //local method for set empty all panels
        }

        public  void completeInfoForPrincipalPanel(List<Root> forecastCity) //local method for complete the principal panel, his contains the city name, image, and hour
        {
            try
            {
                CityNameTextBlock.Text = forecastCity[0].name;                   //Set the city name
                principalForecastImage.ImageSource = HelperForInicioClass.buildImageSourceByUrl(forecastCity[0], "Now").ImageSource; // Build source for principal image

                forecastImageText.Text = forecastCity[0].conditionTextNow;      // Set the text below the image 
                Hour.Text = $"Hour: {DateTime.Now.ToString()}";
            }
            catch(System.Exception  ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("Complete Info For Principal Panel", ex.Message, "Inicio", ex.HResult);
            }
        }
        public void completeInfoForSecondaryPanel(List<Root> forecastCity) //Local method for complete the secondary panel, his contains the forecast in three days
        {
            try
            {
                //First Ellipse
                ImageBrush imageToSet = new();
                imageToSet.ImageSource = new BitmapImage(new Uri($"https:{forecastCity[0].image}"));
             
                FirstCircleForecastImage.ImageSource = HelperForInicioClass.buildImageSourceByUrl(forecastCity[0], "Forecast").ImageSource; //Create and set the image source with help of helper

                FirstCircleDayName.Text = "Today";                                                              //set text for day name in first circle 
                FirstCircleTemperatureMax.Text = forecastCity[0].maxTemperature.ToString();                     //set temperature Max in first circle 
                FirstCircleTemperatureMin.Text = forecastCity[0].minTemperature.ToString();                     //set temperature Min in first circle

                //Second Ellipse
                SecondCircleForecastImage.ImageSource = HelperForInicioClass.buildImageSourceByUrl(forecastCity[1], "Forecast").ImageSource; //Create and set the image source with help of helper
                SecondCircleDayName.Text = Helpers.HelperForInicioClass.WhatDayIsByDate(forecastCity[1].date);  //Set day name in second circle
                SecondCircleTemperatureMax.Text = forecastCity[1].maxTemperature.ToString();                    //Set temperature Max in second circle
                SecondCircleTemperatureMin.Text = forecastCity[1].minTemperature.ToString();                    //Set temperature Min in second circle

                //Third Ellipse
                ThirdCircleForecastImage.ImageSource = HelperForInicioClass.buildImageSourceByUrl(forecastCity[2], "Forecast").ImageSource; //Create and set the image source with help of helper
                ThirdCircleDayName.Text = Helpers.HelperForInicioClass.WhatDayIsByDate(forecastCity[2].date);    //Set day name in third circle
                ThirdCircleTemperatureMax.Text = forecastCity[2].maxTemperature.ToString();                      //Set temperature Max in third circle
                ThirdCircleTemperatureMin.Text = forecastCity[2].minTemperature.ToString();                      //Set temperature Min in third circle
            }
            catch (System.Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("Complete Info For Secondary Panel", ex.Message, "Inicio", ex.HResult);
            }
        }

        public void completeInfoForTemperaturePanel(List<Root> forecastCity)                     //Method for set the info in Temperature Panel
        {
            try
            {
                principalNowTemperature.Text = $"{forecastCity[0].temperatureNow.ToString()}°"; //This set the text into textblock for actually temperature
            } catch (System.Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("Complete Info For Temperature Panel" ,ex.Message ,"Inicio" ,ex.HResult );
            }
        }
        public void completeInfoForPrecipitationPanel(List<Root> forecastCity)                   //Method for set the info in Precipitation Panel
        {
            try
            {
                nowPrecipitation.Text = $"{forecastCity[0].precipitation.ToString()}mm";        //Set the text into text block for precipitation
            }
            catch(System.Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("Complete Info For Precipitation Panel", ex.Message, "Inicio", ex.HResult);
            }
        }
        public void completeForWindPanel(List<Root> forecastCity)                                //Method for set the info in Wind Panel
        {
            try
            {       
                nowWind.Text = forecastCity[0].wind.ToString();                                 //Set the text into text block for wind
            }
            catch (System.Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("Complete Info For Wind Panel", ex.Message, "Inicio", ex.HResult);
            }
        }
        public void setEmptyAllPanels() //Local method for set all panels empty at inicialice
        {
            try
            {
                //Principal Panel
                CityNameTextBlock.Text = string.Empty;      //Set city name empty
                principalForecastImage.ImageSource = null;  //set forecast image empty
                forecastImageText.Text = string.Empty;      //Set image text empty
                Hour.Text = string.Empty;                   //Set the hour empty

                //Secondary Panel (Ellipse multiples)

                //First Ellipse

                FirstCircleDayName.Text = "Have a";             //Set actual name day empty
                FirstCircleTemperatureMax.Text = string.Empty;  //Set max temperature in actual day empty
                FirstCircleTemperatureMin.Text = string.Empty;  //Set min temperature in actual day empty

                //Second Ellipse
                SecondCircleDayName.Text = "Nice";              //Set city name empty in Second day
                SecondCircleTemperatureMax.Text = string.Empty; //Set max temperature in second day empty
                SecondCircleTemperatureMin.Text = string.Empty; //Set min temperature in second day empty

                //Third Ellipse
                ThirdCircleDayName.Text = "Day :)";             //Set city name empty in Third day
                ThirdCircleTemperatureMax.Text = string.Empty;  //Set max temperature in Third day empty
                ThirdCircleTemperatureMin.Text = string.Empty;  //Set min temperature in Third day empty

                //Temperature Panel
                principalNowTemperature.Text = string.Empty;    //Set actual temperature empty

                //Precipitation Panel
                nowPrecipitation.Text = string.Empty;           //Set precipitation text empty

                //Wind Panel
                nowWind.Text = string.Empty;                    //Set wind text empty
            }
            catch (System.Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("Set empty all panels", ex.Message, "Inicio", ex.HResult);
            }

        }

        private void completeAllPanels(List<Root> forecastCity) //Method for complete all panels by other methods
        {
            try
            {
                if (forecastCity.Count > 0 && forecastCity != null)
                {
                    completeInfoForPrincipalPanel(forecastCity);        //call method for complete principal panel
                    completeInfoForSecondaryPanel(forecastCity);        //call method for complete secondary panel
                    completeInfoForTemperaturePanel(forecastCity);      //call method for complete temperature panel
                    completeInfoForPrecipitationPanel(forecastCity);    //call method for complete precipitation panel
                    completeForWindPanel(forecastCity);                 //call method for complete wind panel
                }
            }
            catch(System.Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("Complete all panels", ex.Message, "Inicio", ex.HResult);
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e) //Event for move to before city
        {
            try
            {
                if (count > 0)
                {
                    count--;
                    completeAllPanels(_ServiceGetAllCityInLocalData._allCity[count]);   //call method for complete all panels with count
                }
                else
                {
                    count = _ServiceGetAllCityInLocalData._allCity.Count - 1;
                    completeAllPanels(_ServiceGetAllCityInLocalData._allCity[count]);   //call method for complete all panels with count
                }
            }
            catch(System.Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("ButtonBack_Click", ex.Message, "Inicio", ex.HResult);
            }
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e) //Event for move to the next city
        {
            try
            {

                if (count < _ServiceGetAllCityInLocalData._allCity.Count - 1)
                {
                    count++;
                    completeAllPanels(_ServiceGetAllCityInLocalData._allCity[count]);   //call method for complete all panels with count
                }
                else
                {
                    count = 0;
                    completeAllPanels(_ServiceGetAllCityInLocalData._allCity[count]);   //call method for complete all panels with count
                }
            }
            catch (System.Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("ButtonNext_Click", ex.Message, "Inicio", ex.HResult);
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e) //Event for when page is loaded, this function is for update data for panels
        {
            try
            {
                if (_ServiceGetAllCityInLocalData._allCity.Count != 0)
                {
                    completeAllPanels(_ServiceGetAllCityInLocalData._allCity[0]);   //call method for complete all panels with first city
                }
            }
            catch (System.Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("Page_Loaded", ex.Message, "Inicio", ex.HResult);
            }
        }

        private void ButtonDeleteCity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_ServiceGetAllCityInLocalData._allCity.Count >0)
                {
                    _ServiceGetAllCityInLocalData._allCity.RemoveAt(count);
                    Frame.Navigate(typeof(Inicio));
                }
            }catch(System.Exception ex)
            {
                HelperForWriteErrorMessage.WriteCompleteError("ButtonDeleteCity_Click",ex.Message,"Inicio",ex.HResult);
            }
        }
    }
}
