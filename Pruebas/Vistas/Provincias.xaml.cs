using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Mapsui.Tiling;
using Mapsui.Manipulations;
using System.Diagnostics;
using Mapsui.Widgets.ScaleBar;
using Mapsui.Widgets;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Utilities;
using DotSpatial.Projections.Transforms;
using Mapsui.Projections;

namespace Pruebas.Vistas
{
    public sealed partial class Provincias : Page
    {
        double _finalLongitude {  get; set; }
        double _finalLatitude { get; set; }

        public Provincias()
        {
            this.InitializeComponent();
            MyMap.Map.CRS = "EPSG:4326";
            MyMap.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
           
            
        }
        private void MyMap_Tapped(object sender, TappedRoutedEventArgs e)
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

            var prueba2 = SphericalMercator.ToLonLat(longitudeOnWorldPositionAxisX, latitudeOnWorldPositionAxisY);

            //dan valores inversos
            _finalLongitude = prueba2.lat;
            _finalLatitude = prueba2.lon;



            Debug.WriteLine("Latitud: " + _finalLongitude + ", Longitud: " + _finalLatitude);


        }

        public void addForecastEventByButtonPressed(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("entro");

            boton.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
        }

        private void boton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
