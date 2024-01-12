using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace API_Bitcoin.View
{
    public partial class Page_Index : UserControl
    {
        public Page_Index()
        {
            InitializeComponent();

        }



        private void BTN_7d_Click(object sender, RoutedEventArgs e)
        {
            // Charger l'image correspondante pour le bouton 7d
            IMG_Index.Source = new BitmapImage(new Uri("D:\\Mirza ALJIC\\SUBRAMANI\\C#\\API_Bitcoin\\API_Bitcoin\\Ressources\\Image\\Index_7d.jpeg"));
        }

        private void BTN_1m_Click(object sender, RoutedEventArgs e)
        {
            // Charger l'image correspondante pour le bouton 1m
            IMG_Index.Source = new BitmapImage(new Uri("D:\\Mirza ALJIC\\SUBRAMANI\\C#\\API_Bitcoin\\API_Bitcoin\\Ressources\\Image\\Index_1m.jpeg"));
        }

        private void BTN_1y_Click(object sender, RoutedEventArgs e)
        {
            // Charger l'image correspondante pour le bouton 1y
            IMG_Index.Source = new BitmapImage(new Uri("D:\\Mirza ALJIC\\SUBRAMANI\\C#\\API_Bitcoin\\API_Bitcoin\\Ressources\\Image\\Index_1y.jpeg"));
        }

        private void BTN_All_Click(object sender, RoutedEventArgs e)
        {
            // Charger l'image correspondante pour le bouton All
            IMG_Index.Source = new BitmapImage(new Uri("D:\\Mirza ALJIC\\SUBRAMANI\\C#\\API_Bitcoin\\API_Bitcoin\\Ressources\\Image\\Index_All.jpeg"));
        }


    }
}

