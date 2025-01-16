using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Pruebas.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Pruebas.Vistas
    ;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pruebas
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "Pruebas";
          
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void cambiarPagina(object sender, NavigationViewSelectionChangedEventArgs args)
        {
            var itemSeleccionado = args.SelectedItem as NavigationViewItem;
            if(itemSeleccionado != null)
            {
                string nombreDeLaPagina = itemSeleccionado.Tag.ToString();
                Type pageType = Type.GetType($"Pruebas.Vistas.{nombreDeLaPagina}");
                if(pageType != null)
                {
                    navegador.Navigate(pageType);
                }
                else
                { 
                    System.Diagnostics.Debug.WriteLine($"No se encontró el tipo para: {nombreDeLaPagina}"); }
                }
        }
    }
}
