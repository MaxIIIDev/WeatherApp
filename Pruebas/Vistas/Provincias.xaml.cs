using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Mapsui.Tiling;
using Mapsui.Manipulations;
using System.Diagnostics;
using Mapsui;
using Mapsui.Projections;
using Pruebas.Services;
using NetTopologySuite.Index.Bintree;
using System.Collections.Generic;
using Pruebas.Models;
using System;
using NetTopologySuite.Geometries;
using Mapsui.Layers;
using Mapsui.Styles;
using Mapsui.Nts;
using Microsoft.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace Pruebas.Vistas
{
    public partial class Provincias : Page
    {
        double? _finalLongitude {  get; set; }
        double? _finalLatitude { get; set; }

        ServiceGetAllCityInLocalData _ServiceGetAllCityInLocalData { get;}

        private ServiceGetDataWithForecastAPI _serviceGetDataWithForecastAPI = new ServiceGetDataWithForecastAPI();
        private GenericCollectionLayer<List<IFeature>> layer;
        public Provincias ()
        {
            _ServiceGetAllCityInLocalData = ((App)Application.Current).ServiceProvider.GetService<ServiceGetAllCityInLocalData>();

            this.InitializeComponent();
            
            MyMap.Map.CRS = "EPSG:4326";
            
            MyMap.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
            
            layer = new GenericCollectionLayer<List<IFeature>>
            {
                Style = SymbolStyles.CreatePinStyle()
            };
            
            MyMap.Map.Layers.Add(layer);
        }
        private void MyMap_Tapped(object sender, TappedRoutedEventArgs e)   //Event for when the user click the map
        {
            try
            {
                var position = e.GetPosition(this);

                ScreenPosition screenPosition = new ScreenPosition(position.X, position.Y);
                MapInfo mapPosition = MyMap.GetMapInfo
                (screenPosition, MyMap.Map.Layers.GetLayers());

                double longitudeOnWorldPositionAxisX = mapPosition.WorldPosition.X;
                double latitudeOnWorldPositionAxisY = mapPosition.WorldPosition.Y;

                //MPoint prueba = Mapsui.Projections.Mercator.ToLonLat(lon, lat); //Funciona pero es menos preciso
                //double nuevaLon = prueba.Y;
                //double nuevaLat = prueba.X;

                (double lon, double lat) sphericalCoordinates = SphericalMercator.ToLonLat(longitudeOnWorldPositionAxisX, latitudeOnWorldPositionAxisY);

                //dan valores inversos
                _finalLatitude = sphericalCoordinates.lat;
                _finalLongitude = sphericalCoordinates.lon;

                boton.IsEnabled = true;

                Debug.WriteLine("Latitud: " + _finalLatitude + ", Longitud: " + _finalLongitude);

                addPin(latitudeOnWorldPositionAxisY, longitudeOnWorldPositionAxisX);
            }catch(Exception ex)
            {
                Helpers.HelperForWriteErrorMessage.WriteCompleteError("MyMapp_Tapped", ex.Message, "Provincias", ex.HResult);
            }
            
            
        }

        public async void addForecastEventByButtonPressed(object sender, TappedRoutedEventArgs e)   //Event when user touch the add button
        {
            try
            {
                double latitudeReadyToWork = 0.0;
                double longitudeReadyToWork = 0.0;
                List<Root> forecastObtainWithApi = new();

                if (_finalLatitude == null || _finalLongitude == null )
                {
                    boton.IsEnabled = false;
                }
                else
                {
                    latitudeReadyToWork = (double)_finalLatitude;
                    longitudeReadyToWork = (double)_finalLongitude;
                }

                if (latitudeReadyToWork != 0.0 || longitudeReadyToWork != 0.0)
                {
                    forecastObtainWithApi = await _serviceGetDataWithForecastAPI.GetInfoFromForecastAPI(latitudeReadyToWork, longitudeReadyToWork);
                }

                _ServiceGetAllCityInLocalData.AddCity(forecastObtainWithApi);
                
                _finalLongitude = null;
                _finalLatitude = null;
                boton.IsEnabled = false;
                
            }
            catch(Exception ex)
            {
                Helpers.HelperForWriteErrorMessage.WriteCompleteError("addForecastEventByButtonPressed",ex.Message,"Provincias",ex.HResult);
            }
            
            

        }

        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args) //Event when the user search the city
        {
            try
            {
                if (boton.IsEnabled)
                {
                    boton.IsEnabled = false;
                }
                if (searchBox.Text == "")
                {
                    searchBox.PlaceholderText = "Our recommendation is the patron: City + Country";
                }
                else
                {
                    //sacar la info del servicio, utilizar el spericalmercator from, para convertir las latitudes y longitudes en posiciones del mapa y luego, añadir un pin con las mismas

                    List<Root> forecastList = await _serviceGetDataWithForecastAPI.GetInfoFromForecastAPI(searchBox.Text);

                    foreach (var forecast in forecastList)
                    {
                        Debug.WriteLine(forecast.ToString());

                    }

                    var ppp = SphericalMercator.FromLonLat(forecastList[0].longitude, forecastList[0].latitude);

                    var latitude = ppp.y;
                    var longitude = ppp.x;

                    addPin(latitude, longitude);

                }
            }
            catch(Exception ex)
            {
                Helpers.HelperForWriteErrorMessage.WriteCompleteError("AutoSuggestBox_QuerySubmitted", ex.Message, "Provincias", ex.HResult);
            }
            
        }
        public void addPin(double latitude, double longitude) //Method for add pin in map
        {
            try
            {
                layer.Features.Clear();
                var position = new Point(longitude, latitude);

                layer.Features.Add(new GeometryFeature
                {
                    Geometry = position
                });
                layer.DataHasChanged();
            }
            catch(Exception ex)
            {
                Helpers.HelperForWriteErrorMessage.WriteCompleteError("addPin", ex.Message, "Provincias", ex.HResult);
            }
            
        }
    }
    
}
