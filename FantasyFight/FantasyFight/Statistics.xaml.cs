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
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        Canvas canvas;
        List<Tuple<string, Tuple<string, string>>> battles = new List<Tuple<string, Tuple<string, string>>>();

        public Statistics()
        {
            InitializeComponent();

            canvas = new Canvas();
            canvas.Margin = MainGrid.Margin;
            canvas.Height = MainGrid.Height;
            canvas.Width = MainGrid.Width;
            canvas.AllowDrop = true;
            MainGrid.Children.Add(canvas);

            string currentDirectory = Environment.CurrentDirectory;
            DirectoryInfo backgroundLocation = new DirectoryInfo(currentDirectory + "\\FantasyFight\\Images");
            string imageLocation = Directory.GetFiles(backgroundLocation.FullName).ToList().Last();

            ImageBrush brush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(imageLocation, UriKind.Relative));
            brush.ImageSource = image.Source;
            this.Background = brush;

            ReadIn("statistics.txt");

            if (battles != null)
            {
                List<string> fighters = battles.Select(x => x.Item2.Item1).Distinct().ToList();
                List<string> monsters = battles.Select(x => x.Item2.Item2).Distinct().ToList();
                List<string> characters = fighters.Concat(monsters).ToList();
                List<Tuple<string, Tuple<int, int>>> charactersWinsDefeatsCount = new List<Tuple<string, Tuple<int, int>>>();
                foreach (string c in characters)
                {
                    int countBattles = battles.Count(x => x.Item2.Item1 == c || x.Item2.Item2 == c);
                    int countWins = battles.Count(x => x.Item1 == c);
                    int countDefeats = countBattles - countWins;
                    Tuple<string, Tuple<int, int>> newTuple = new Tuple<string, Tuple<int, int>>(c, new Tuple<int, int>(countWins, countDefeats));
                    charactersWinsDefeatsCount.Add(newTuple);
                }

                List<Tuple<string, Tuple<int, int>>> charactersWinsDefeatsCountOrdered = charactersWinsDefeatsCount.OrderByDescending(x => x.Item2.Item1).ToList();

                for (int i = 0; i < charactersWinsDefeatsCountOrdered.Count; i++)
                {
                    Label character = new Label();
                    character.FontFamily = new FontFamily("Algerian");
                    character.Foreground = Brushes.White;
                    character.FontSize = 20;
                    character.HorizontalContentAlignment = HorizontalAlignment.Center;
                    character.Width = 600;
                    character.Height = 35;
                    character.Margin = new Thickness(0, 10 + i * 35, 0, 0);
                    character.Content =
                    charactersWinsDefeatsCountOrdered[i].Item1 + " : " + charactersWinsDefeatsCountOrdered[i].Item2.Item1 + " wins / " + charactersWinsDefeatsCountOrdered[i].Item2.Item2 + " defeats";
                    canvas.Children.Add(character);
                }
            }
        }

        void ReadIn(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string text = reader.ReadToEnd();

            if (text != null && text != "")
            {
                string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    string[] array = line.Split('>').ToArray();
                    string winner = array[1].Split('=')[1].Trim();
                    string fighter = array[0].Split('/')[0].Split(':')[1].Trim();
                    string enemy = array[0].Split('/')[1].Split(':')[1].Split('=')[0].Trim();

                    Tuple<string, Tuple<string, string>> newTuple = new Tuple<string, Tuple<string, string>>(winner, new Tuple<string, string>(fighter, enemy));
                    battles.Add(newTuple);
                }
                reader.Close();
            }
            else
            {
                battles = null;
            }
        }
    }
}
