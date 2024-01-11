using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using API_Bitcoin.View;

namespace API_Bitcoin
{


    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();

        }



        private void BTN_Tendance_Click(object sender, RoutedEventArgs e)
        {
            Windows_Container.Children.Clear();
            Page_Tendance tendance = new Page_Tendance();
            Windows_Container.Children.Add(tendance);
        }

        private void BTN_IndexFear_Click(object sender, RoutedEventArgs e)
        {

            Windows_Container.Children.Clear();
            Page_Index index = new Page_Index();
            Windows_Container.Children.Add(index);
        }

        private void BTN_Crypto_Click(object sender, RoutedEventArgs e)
        {
            Windows_Container.Children.Clear();
            PageCrypto pageCrypto = new PageCrypto();
            Windows_Container.Children.Add(pageCrypto);

        }

        private void BTN_Courbe_Click(object sender, RoutedEventArgs e)
        {
            Windows_Container.Children.Clear();
            Page_Graphique graphique = new Page_Graphique();
            Windows_Container.Children.Add(graphique);
        }
    }
}
