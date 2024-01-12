using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Newtonsoft.Json;
using RestSharp;

namespace API_Bitcoin.View
{
    /// <summary>
    /// Logique d'interaction pour Page_Information.xaml
    /// </summary>
    public partial class Page_Information : UserControl
    {
        public Page_Information()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            var client = new RestClient("https://openapiv1.coinstats.app/news/sources");
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("X-API-KEY", "0qSRvDzjqVmDWRMnBiHkx/2v/wefOSm6q8WIUguCrEE=");

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                string jsonResponse = response.Content;
                List<Root> rootData = JsonConvert.DeserializeObject<List<Root>>(jsonResponse);

                foreach (var item in rootData)
                {
                    item.logo = "https://zycrypto.com/wp-content/uploads/2023/09/Ripple-Continues-Its-Acquisitive-Streak-With-Deal-To-Acquire-Crypto-Infrastructure-Startup-Fortress-Trust.jpg";
                }

                DataContext = rootData;
            }
            else
            {
                // Gérez les erreurs ici si nécessaire
            }
        }

        public void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

        public class Root
        {
            public string sourcename { get; set; }
            public string logo { get; set; }
            public string sourceImg { get; set; }
            public string weburl { get; set; }
            public string feedurl { get; set; }
            public DateTime _created_at { get; set; }
            public DateTime? _updated_at { get; set; }
            public string coinid { get; set; }
        }
    }

    // Convertisseur pour gérer les liens nuls
    public class NullToUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new Uri("about:blank"); // URI par défaut pour les valeurs nulles
            return new Uri(value.ToString(), UriKind.RelativeOrAbsolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}