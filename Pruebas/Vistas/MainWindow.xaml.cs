using System;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
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
            
            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new Windows.Graphics.SizeInt32(1400,700));
            var presenter = appWindow.Presenter as OverlappedPresenter;
            presenter.IsResizable = false;
            presenter.IsMaximizable = false;
            if(navegador.Content == null)
            {
                navegador.Navigate(typeof(Inicio));
            }
            

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
