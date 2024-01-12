using RestSharp;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using RestSharp;

namespace API_Bitcoin.View
{
    /// <summary>
    /// Logique d'interaction pour Page_Graphique.xaml
    /// </summary>
    public partial class Page_Graphique : UserControl
    {
        public Page_Graphique()
        {
            InitializeComponent();

            MakeApiRequest();
        }



        private async void MakeApiRequest()
        {
            var options = new RestClientOptions("https://openapiv1.coinstats.app/coins/coinId/charts");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("X-API-KEY", "0qSRvDzjqVmDWRMnBiHkx/2v/wefOSm6q8WIUguCrEE=");

            try
            {
                var response = await client.GetAsync(request);
                Console.WriteLine("{0}", response.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la requête : {ex.Message}");
            }
        }

        private List<string> ParseImageUrlsFromResponse(string responseContent)
        {
            // Code pour extraire les URLs des images de la réponse JSON
            // (Dépend de la structure de la réponse de l'API)
            // Retourne une liste d'URLs d'images
            // Exemple simplifié :
            // var imageUrls = new List<string>();
            // ... (code d'extraction des URLs)
            // return imageUrls;

            // Remplacez cette partie du code par votre logique spécifique à l'API


            throw new NotImplementedException();
        }

        private void DisplayImages(List<string> imageUrls)
        {
            // Ajoutez des images à votre interface utilisateur (par exemple, à une pile d'images)
            foreach (var imageUrl in imageUrls)
            {
                // Créez une image à partir de l'URL
                var image = new Image();
                var bitmapImage = new BitmapImage(new Uri(imageUrl));

                // Définissez l'image source
                image.Source = bitmapImage;

                // Ajoutez l'image à votre interface utilisateur (par exemple, à une pile d'images)
               // Img_Courbe1.Children.Add(image);
            }
        }

    }
}
