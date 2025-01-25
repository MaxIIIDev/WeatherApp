using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Pruebas.Services;
using Microsoft.Extensions.DependencyInjection;
using Pruebas.Models;
using Microsoft.UI.Xaml.Media.Imaging;
using Pruebas.Helpers;

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
        int count { get; set; } = 0; 
        public Inicio()
        {
            _ServiceGetAllCityInLocalData = ((App)Application.Current).ServiceProvider.GetService<ServiceGetAllCityInLocalData>();
            this.InitializeComponent();
            setEmptyAllPanels();
        }

        public  void completeInfoForPrincipalPanel(List<Root> forecastCity)
        {
            CityNameTextBlock.Text = forecastCity[0].name;
          
            //VER SI FUNCIONA
            
            principalForecastImage.ImageSource = HelperForInicioClass.buildImageSourceByUrl(forecastCity[0], "Now").ImageSource;
            ////////////

            forecastImageText.Text = forecastCity[0].conditionTextNow;
            Hour.Text = $"Hour: {DateTime.Now.ToString()}";

        }
        public void completeInfoForSecondaryPanel(List<Root> forecastCity)
        {
            //First Ellipse
            ImageBrush imageToSet = new();
            imageToSet.ImageSource = new BitmapImage(new Uri($"https:{forecastCity[0].image}"));
            //ver si funca
            FirstCircleForecastImage.ImageSource = HelperForInicioClass.buildImageSourceByUrl(forecastCity[0],"Forecast").ImageSource;

            FirstCircleDayName.Text = "Today";
            FirstCircleTemperatureMax.Text = forecastCity[0].maxTemperature.ToString();
            FirstCircleTemperatureMin.Text = forecastCity[0].minTemperature.ToString();

            //Second Ellipse
            SecondCircleForecastImage.ImageSource = HelperForInicioClass.buildImageSourceByUrl(forecastCity[1], "Forecast").ImageSource;
            SecondCircleDayName.Text = Helpers.HelperForInicioClass.WhatDayIsByDate(forecastCity[1].date);
            SecondCircleTemperatureMax.Text = forecastCity[1].maxTemperature.ToString();
            SecondCircleTemperatureMin.Text = forecastCity[1].minTemperature.ToString();

            //Third Ellipse
            ThirdCircleForecastImage.ImageSource = HelperForInicioClass.buildImageSourceByUrl(forecastCity[2], "Forecast").ImageSource;
            ThirdCircleDayName.Text = Helpers.HelperForInicioClass.WhatDayIsByDate(forecastCity[2].date);
            ThirdCircleTemperatureMax.Text = forecastCity[2].maxTemperature.ToString() ;
            ThirdCircleTemperatureMin.Text = forecastCity[2].minTemperature.ToString();
        }

        public void completeInfoForTemperaturaPanel(List<Root> forecastCity)
        {
            //principalMaxTemperature.Text = forecastCity[0].maxTemperature.ToString();
            principalNowTemperature.Text = $"{forecastCity[0].temperatureNow.ToString()}°";
            //principalMinTemperature.Text = forecastCity[0].minTemperature.ToString();
        }
        public void completeInfoForPrecipitationPanel(List<Root> forecastCity)
        {
            nowPrecipitation.Text = $"{forecastCity[0].precipitation.ToString()}mm";
        }
        public void completeForWindPanel(List<Root> forecastCity)
        {
            nowWind.Text = forecastCity[0].wind.ToString();
        }
        public void setEmptyAllPanels()
        {
            //Principal Panel
            CityNameTextBlock.Text = string.Empty;
            principalForecastImage.ImageSource = null;
            forecastImageText.Text = string.Empty;
            Hour.Text = string.Empty;

            //Secondary Panel (Ellipse multiples)

                //First Ellipse
            
            FirstCircleDayName.Text = "Have a";
            FirstCircleTemperatureMax.Text = string.Empty;
            FirstCircleTemperatureMin.Text = string.Empty;

                //Second Ellipse
            SecondCircleDayName.Text = "Nice";
            SecondCircleTemperatureMax.Text = string.Empty;
            SecondCircleTemperatureMin.Text = string.Empty;

                //Third Ellipse
            ThirdCircleDayName.Text = "Day :)";
            ThirdCircleTemperatureMax.Text = string.Empty;
            ThirdCircleTemperatureMin.Text = string.Empty;

            //Temperature Panel
            //principalMaxTemperature.Text = string.Empty;
            principalNowTemperature.Text = string.Empty;
            //principalMinTemperature.Text = string.Empty;

            //Precipitation Panel
            nowPrecipitation.Text = string.Empty;

            //Wind Panel
            nowWind.Text = string.Empty;


        }

        private void completeAllPanels(List<Root> forecastCity)
        {
            if(forecastCity.Count > 0 && forecastCity != null)
            {
                completeInfoForPrincipalPanel(forecastCity);
                completeInfoForSecondaryPanel(forecastCity);
                completeInfoForTemperaturaPanel(forecastCity);
                completeInfoForPrecipitationPanel(forecastCity);
                completeForWindPanel(forecastCity);
            } 
           
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if(count > 0 )
            {
                count--;
                completeAllPanels(_ServiceGetAllCityInLocalData._allCity[count]);
            }
            else
            {
                count = _ServiceGetAllCityInLocalData._allCity.Count - 1;
                completeAllPanels(_ServiceGetAllCityInLocalData._allCity[count]);
            }
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if(count < _ServiceGetAllCityInLocalData._allCity.Count - 1)
            {
                count++;
                completeAllPanels(_ServiceGetAllCityInLocalData._allCity[count]);
            }
            else
            {
                count = 0;
                completeAllPanels(_ServiceGetAllCityInLocalData._allCity[count]);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(_ServiceGetAllCityInLocalData._allCity.Count != 0)
            {
                completeAllPanels(_ServiceGetAllCityInLocalData._allCity[0]);
            }
            
        }
    }
}
