using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace FantasyFight
{
    /// <summary>
    /// Interaction logic for CharacterDescription.xaml
    /// </summary>
    public partial class CharacterDescription : Window
    {
        string characterName;

        public CharacterDescription(string name)
        {
            InitializeComponent();

            this.characterName = name;

            string currentDirectory = Environment.CurrentDirectory;
            DirectoryInfo descriptionsLocation = new DirectoryInfo(currentDirectory + "\\Images\\CharacterDescriptions");
            List<string> descriptionsSources = Directory.GetFiles(descriptionsLocation.FullName).ToList();

            foreach (string d in descriptionsSources)
            {
                if(d.Contains(characterName))
                {
                    ImageBrush brush = new ImageBrush();
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri(d, UriKind.Relative));
                    brush.ImageSource = image.Source;
                    this.Background = brush;
                }
            }
        }
    }
}
