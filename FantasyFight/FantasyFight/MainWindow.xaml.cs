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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FantasyFight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DirectoryInfo> imagesFoldersLocations;
        List<string> images;
        List<Tuple<string, List<Tuple<string, List<string>>>>> charactersMovesLists 
        = new List<Tuple<string, List<Tuple<string, List<string>>>>>();
        List<string> dicesSources;
        List<Label> fighterPointsLabels = new List<Label>();
        List<Label> enemyPointsLabels = new List<Label>();
        ImageBrush brush;
        ScaleTransform flipTrans;
        DispatcherTimer timer;
        Storyboard storyBoard;
        DoubleAnimation doubleAnimation;
        Random generator;
        Image fighterImage;
        Image enemyImage;
        bool machineRoundOn;
        string UserFighterChoice;
        string UserEnemyChoice;
        int currentImageIndex = 0;
        int animationCount = 0;
        int fighter_Physical;
        int fighter_Astral;
        int fighter_Mental;
        int fighter_Vitality;
        int fighter_Wounding;
        int fighter_Wounding_New;
        int fighter_Protection;
        int enemy_Physical;
        int enemy_Astral;
        int enemy_Mental;
        int enemy_Vitality;
        int enemy_Wounding;
        int enemy_Wounding_New;
        int enemy_Protection;
        int totalRoundNumber;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        void CreateImageSources()
        {
            string currentDirectory = Environment.CurrentDirectory;

            DirectoryInfo backgroundLocation = new DirectoryInfo(currentDirectory + "\\FantasyFight\\Images");
            images = Directory.GetFiles(backgroundLocation.FullName).ToList();
            
            imagesFoldersLocations = new List<DirectoryInfo>();

            DirectoryInfo dicesLocation = new DirectoryInfo(currentDirectory + "\\Images\\Dices");
            imagesFoldersLocations.Add(dicesLocation);

            DirectoryInfo knight1AttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight1Attack");
            imagesFoldersLocations.Add(knight1AttackLocation);
            DirectoryInfo knight1DieLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight1Die");
            imagesFoldersLocations.Add(knight1DieLocation);
            DirectoryInfo knight1HurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight1Hurt");
            imagesFoldersLocations.Add(knight1HurtLocation);
            DirectoryInfo knight1WalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight1Walk");
            imagesFoldersLocations.Add(knight1WalkLocation);

            DirectoryInfo knight2AttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight2Attack");
            imagesFoldersLocations.Add(knight2AttackLocation);
            DirectoryInfo knight2DieLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight2Die");
            imagesFoldersLocations.Add(knight2DieLocation);
            DirectoryInfo knight2HurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight2Hurt");
            imagesFoldersLocations.Add(knight2HurtLocation);
            DirectoryInfo knight2WalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight2Walk");
            imagesFoldersLocations.Add(knight2WalkLocation);

            DirectoryInfo knight3AttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight3Attack");
            imagesFoldersLocations.Add(knight3AttackLocation);
            DirectoryInfo knight3DieLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight3Die");
            imagesFoldersLocations.Add(knight3DieLocation);
            DirectoryInfo knight3HurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight3Hurt");
            imagesFoldersLocations.Add(knight3HurtLocation);
            DirectoryInfo knight3WalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\Knight3Walk");
            imagesFoldersLocations.Add(knight3WalkLocation);

            DirectoryInfo warrior1AttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior1Attack");
            imagesFoldersLocations.Add(warrior1AttackLocation);
            DirectoryInfo warrior1DieLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior1Die");
            imagesFoldersLocations.Add(warrior1DieLocation);
            DirectoryInfo warrior1HurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior1Hurt");
            imagesFoldersLocations.Add(warrior1HurtLocation);
            DirectoryInfo warrior1WalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior1Walk");
            imagesFoldersLocations.Add(warrior1WalkLocation);

            DirectoryInfo warrior2AttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior2Attack");
            imagesFoldersLocations.Add(warrior2AttackLocation);
            DirectoryInfo warrior2DieLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior2Die");
            imagesFoldersLocations.Add(warrior2DieLocation);
            DirectoryInfo warrior2HurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior2Hurt");
            imagesFoldersLocations.Add(warrior2HurtLocation);
            DirectoryInfo warrior2WalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior2Walk");
            imagesFoldersLocations.Add(warrior2WalkLocation);

            DirectoryInfo warrior3AttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior3Attack");
            imagesFoldersLocations.Add(warrior3AttackLocation);
            DirectoryInfo warrior3DieLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior3Die");
            imagesFoldersLocations.Add(warrior3DieLocation);
            DirectoryInfo warrior3HurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior3Hurt");
            imagesFoldersLocations.Add(warrior3HurtLocation);
            DirectoryInfo warrior3WalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\Warrior3Walk");
            imagesFoldersLocations.Add(warrior3WalkLocation);

            DirectoryInfo orc1AttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\Orc1Attack");
            imagesFoldersLocations.Add(orc1AttackLocation);
            DirectoryInfo orc1DieLocation = new DirectoryInfo(currentDirectory + "\\Images\\Orc1Die");
            imagesFoldersLocations.Add(orc1DieLocation);
            DirectoryInfo orc1HurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\Orc1Hurt");
            imagesFoldersLocations.Add(orc1HurtLocation);
            DirectoryInfo orc1WalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\Orc1Walk");
            imagesFoldersLocations.Add(orc1WalkLocation);

            DirectoryInfo orc2AttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\Orc2Attack");
            imagesFoldersLocations.Add(orc2AttackLocation);
            DirectoryInfo orc2DieLocation = new DirectoryInfo(currentDirectory + "\\Images\\Orc2Die");
            imagesFoldersLocations.Add(orc2DieLocation);
            DirectoryInfo orc2HurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\Orc2Hurt");
            imagesFoldersLocations.Add(orc2HurtLocation);
            DirectoryInfo orc2WalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\Orc2Walk");
            imagesFoldersLocations.Add(orc2WalkLocation);

            DirectoryInfo troll1AttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\Troll1Attack");
            imagesFoldersLocations.Add(troll1AttackLocation);
            DirectoryInfo troll1DieLocation = new DirectoryInfo(currentDirectory + "\\Images\\Troll1Die");
            imagesFoldersLocations.Add(troll1DieLocation);
            DirectoryInfo troll1HurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\Troll1Hurt");
            imagesFoldersLocations.Add(troll1HurtLocation);
            DirectoryInfo troll1WalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\Troll1Walk");
            imagesFoldersLocations.Add(troll1WalkLocation);

            DirectoryInfo troll2AttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\Troll2Attack");
            imagesFoldersLocations.Add(troll2AttackLocation);
            DirectoryInfo troll2DieLocation = new DirectoryInfo(currentDirectory + "\\Images\\Troll2Die");
            imagesFoldersLocations.Add(troll2DieLocation);
            DirectoryInfo troll2HurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\Troll2Hurt");
            imagesFoldersLocations.Add(troll2HurtLocation);
            DirectoryInfo troll2WalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\Troll2Walk");
            imagesFoldersLocations.Add(troll2WalkLocation);

            dicesSources = Directory.GetFiles(imagesFoldersLocations[0].FullName).ToList();

            Tuple<string, List<string>> knight1AttackSources = new Tuple<string, List<string>>("Attack", Directory.GetFiles(imagesFoldersLocations[1].FullName).ToList());
            Tuple<string, List<string>> knight1DieSources = new Tuple<string, List<string>>("Die", Directory.GetFiles(imagesFoldersLocations[2].FullName).ToList());
            Tuple<string, List<string>> knight1HurtSources = new Tuple<string, List<string>>("Hurt", Directory.GetFiles(imagesFoldersLocations[3].FullName).ToList());
            Tuple<string, List<string>> knight1WalkSources = new Tuple<string, List<string>>("Walk", Directory.GetFiles(imagesFoldersLocations[4].FullName).ToList());

            List<Tuple<string, List<string>>> knight1Sources = new List<Tuple<string, List<string>>>();
            knight1Sources.Add(knight1AttackSources);
            knight1Sources.Add(knight1DieSources);
            knight1Sources.Add(knight1HurtSources);
            knight1Sources.Add(knight1WalkSources);

            Tuple<string, List<Tuple<string, List<string>>>> knight1Tuple = new Tuple<string, List<Tuple<string, List<string>>>>("Red Knight", knight1Sources);
            charactersMovesLists.Add(knight1Tuple);

            Tuple<string, List<string>> knight2AttackSources = new Tuple<string, List<string>>("Attack", Directory.GetFiles(imagesFoldersLocations[5].FullName).ToList());
            Tuple<string, List<string>> knight2DieSources = new Tuple<string, List<string>>("Die", Directory.GetFiles(imagesFoldersLocations[6].FullName).ToList());
            Tuple<string, List<string>> knight2HurtSources = new Tuple<string, List<string>>("Hurt", Directory.GetFiles(imagesFoldersLocations[7].FullName).ToList());
            Tuple<string, List<string>> knight2WalkSources = new Tuple<string, List<string>>("Walk", Directory.GetFiles(imagesFoldersLocations[8].FullName).ToList());
            
            List<Tuple<string, List<string>>> knight2Sources = new List<Tuple<string, List<string>>>();
            knight2Sources.Add(knight2AttackSources);
            knight2Sources.Add(knight2DieSources);
            knight2Sources.Add(knight2HurtSources);
            knight2Sources.Add(knight2WalkSources);

            Tuple<string, List<Tuple<string, List<string>>>> knight2Tuple = new Tuple<string, List<Tuple<string, List<string>>>>("Night Knight", knight2Sources);
            charactersMovesLists.Add(knight2Tuple);

            Tuple<string, List<string>> knight3AttackSources = new Tuple<string, List<string>>("Attack", Directory.GetFiles(imagesFoldersLocations[9].FullName).ToList());
            Tuple<string, List<string>> knight3DieSources = new Tuple<string, List<string>>("Die", Directory.GetFiles(imagesFoldersLocations[10].FullName).ToList());
            Tuple<string, List<string>> knight3HurtSources = new Tuple<string, List<string>>("Hurt", Directory.GetFiles(imagesFoldersLocations[11].FullName).ToList());
            Tuple<string, List<string>> knight3WalkSources = new Tuple<string, List<string>>("Walk", Directory.GetFiles(imagesFoldersLocations[12].FullName).ToList());

            List<Tuple<string, List<string>>> knight3Sources = new List<Tuple<string, List<string>>>();
            knight3Sources.Add(knight3AttackSources);
            knight3Sources.Add(knight3DieSources);
            knight3Sources.Add(knight3HurtSources);
            knight3Sources.Add(knight3WalkSources);

            Tuple<string, List<Tuple<string, List<string>>>> knight3Tuple = new Tuple<string, List<Tuple<string, List<string>>>>("Golden Knight", knight3Sources);
            charactersMovesLists.Add(knight3Tuple);

            Tuple<string, List<string>> warrior1AttackSources = new Tuple<string, List<string>>("Attack", Directory.GetFiles(imagesFoldersLocations[13].FullName).ToList());
            Tuple<string, List<string>> warrior1DieSources = new Tuple<string, List<string>>("Die", Directory.GetFiles(imagesFoldersLocations[14].FullName).ToList());
            Tuple<string, List<string>> warrior1HurtSources = new Tuple<string, List<string>>("Hurt", Directory.GetFiles(imagesFoldersLocations[15].FullName).ToList());
            Tuple<string, List<string>> warrior1WalkSources = new Tuple<string, List<string>>("Walk", Directory.GetFiles(imagesFoldersLocations[16].FullName).ToList());

            List<Tuple<string, List<string>>> warrior1Sources = new List<Tuple<string, List<string>>>();
            warrior1Sources.Add(warrior1AttackSources);
            warrior1Sources.Add(warrior1DieSources);
            warrior1Sources.Add(warrior1HurtSources);
            warrior1Sources.Add(warrior1WalkSources);

            Tuple<string, List<Tuple<string, List<string>>>> warrior1Tuple = new Tuple<string, List<Tuple<string, List<string>>>>("Valkyrie Warrior", warrior1Sources);
            charactersMovesLists.Add(warrior1Tuple);

            Tuple<string, List<string>> warrior2AttackSources = new Tuple<string, List<string>>("Attack", Directory.GetFiles(imagesFoldersLocations[17].FullName).ToList());
            Tuple<string, List<string>> warrior2DieSources = new Tuple<string, List<string>>("Die", Directory.GetFiles(imagesFoldersLocations[18].FullName).ToList());
            Tuple<string, List<string>> warrior2HurtSources = new Tuple<string, List<string>>("Hurt", Directory.GetFiles(imagesFoldersLocations[19].FullName).ToList());
            Tuple<string, List<string>> warrior2WalkSources = new Tuple<string, List<string>>("Walk", Directory.GetFiles(imagesFoldersLocations[20].FullName).ToList());

            List<Tuple<string, List<string>>> warrior2Sources = new List<Tuple<string, List<string>>>();
            warrior2Sources.Add(warrior2AttackSources);
            warrior2Sources.Add(warrior2DieSources);
            warrior2Sources.Add(warrior2HurtSources);
            warrior2Sources.Add(warrior2WalkSources);

            Tuple<string, List<Tuple<string, List<string>>>> warrior2Tuple = new Tuple<string, List<Tuple<string, List<string>>>>("Amazon Warrior", warrior2Sources);
            charactersMovesLists.Add(warrior2Tuple);

            Tuple<string, List<string>> warrior3AttackSources = new Tuple<string, List<string>>("Attack", Directory.GetFiles(imagesFoldersLocations[21].FullName).ToList());
            Tuple<string, List<string>> warrior3DieSources = new Tuple<string, List<string>>("Die", Directory.GetFiles(imagesFoldersLocations[22].FullName).ToList());
            Tuple<string, List<string>> warrior3HurtSources = new Tuple<string, List<string>>("Hurt", Directory.GetFiles(imagesFoldersLocations[23].FullName).ToList());
            Tuple<string, List<string>> warrior3WalkSources = new Tuple<string, List<string>>("Walk", Directory.GetFiles(imagesFoldersLocations[24].FullName).ToList());

            List<Tuple<string, List<string>>> warrior3Sources = new List<Tuple<string, List<string>>>();
            warrior3Sources.Add(warrior3AttackSources);
            warrior3Sources.Add(warrior3DieSources);
            warrior3Sources.Add(warrior3HurtSources);
            warrior3Sources.Add(warrior3WalkSources);

            Tuple<string, List<Tuple<string, List<string>>>> warrior3Tuple = new Tuple<string, List<Tuple<string, List<string>>>>("Elf Warrior", warrior3Sources);
            charactersMovesLists.Add(warrior3Tuple);

            Tuple<string, List<string>> orc1AttackSources = new Tuple<string, List<string>>("Attack", Directory.GetFiles(imagesFoldersLocations[25].FullName).ToList());
            Tuple<string, List<string>> orc1DieSources = new Tuple<string, List<string>>("Die", Directory.GetFiles(imagesFoldersLocations[26].FullName).ToList());
            Tuple<string, List<string>> orc1HurtSources = new Tuple<string, List<string>>("Hurt", Directory.GetFiles(imagesFoldersLocations[27].FullName).ToList());
            Tuple<string, List<string>> orc1WalkSources = new Tuple<string, List<string>>("Walk", Directory.GetFiles(imagesFoldersLocations[28].FullName).ToList());

            List<Tuple<string, List<string>>> orc1Sources = new List<Tuple<string, List<string>>>();
            orc1Sources.Add(orc1AttackSources);
            orc1Sources.Add(orc1DieSources);
            orc1Sources.Add(orc1HurtSources);
            orc1Sources.Add(orc1WalkSources);

            Tuple<string, List<Tuple<string, List<string>>>> orc1Tuple = new Tuple<string, List<Tuple<string, List<string>>>>("Soldier Orc", orc1Sources);
            charactersMovesLists.Add(orc1Tuple);

            Tuple<string, List<string>> orc2AttackSources = new Tuple<string, List<string>>("Attack", Directory.GetFiles(imagesFoldersLocations[29].FullName).ToList());
            Tuple<string, List<string>> orc2DieSources = new Tuple<string, List<string>>("Die", Directory.GetFiles(imagesFoldersLocations[30].FullName).ToList());
            Tuple<string, List<string>> orc2HurtSources = new Tuple<string, List<string>>("Hurt", Directory.GetFiles(imagesFoldersLocations[31].FullName).ToList());
            Tuple<string, List<string>> orc2WalkSources = new Tuple<string, List<string>>("Walk", Directory.GetFiles(imagesFoldersLocations[32].FullName).ToList());

            List<Tuple<string, List<string>>> orc2Sources = new List<Tuple<string, List<string>>>();
            orc2Sources.Add(orc2AttackSources);
            orc2Sources.Add(orc2DieSources);
            orc2Sources.Add(orc2HurtSources);
            orc2Sources.Add(orc2WalkSources);

            Tuple<string, List<Tuple<string, List<string>>>> orc2Tuple = new Tuple<string, List<Tuple<string, List<string>>>>("Pirate Orc", orc2Sources);
            charactersMovesLists.Add(orc2Tuple);

            Tuple<string, List<string>> troll1AttackSources = new Tuple<string, List<string>>("Attack", Directory.GetFiles(imagesFoldersLocations[33].FullName).ToList());
            Tuple<string, List<string>> troll1DieSources = new Tuple<string, List<string>>("Die", Directory.GetFiles(imagesFoldersLocations[34].FullName).ToList());
            Tuple<string, List<string>> troll1HurtSources = new Tuple<string, List<string>>("Hurt", Directory.GetFiles(imagesFoldersLocations[35].FullName).ToList());
            Tuple<string, List<string>> troll1WalkSources = new Tuple<string, List<string>>("Walk", Directory.GetFiles(imagesFoldersLocations[36].FullName).ToList());

            List<Tuple<string, List<string>>> troll1Sources = new List<Tuple<string, List<string>>>();
            troll1Sources.Add(troll1AttackSources);
            troll1Sources.Add(troll1DieSources);
            troll1Sources.Add(troll1HurtSources);
            troll1Sources.Add(troll1WalkSources);

            Tuple<string, List<Tuple<string, List<string>>>> troll1Tuple = new Tuple<string, List<Tuple<string, List<string>>>>("Mountain Troll", troll1Sources);
            charactersMovesLists.Add(troll1Tuple);

            Tuple<string, List<string>> troll2AttackSources = new Tuple<string, List<string>>("Attack", Directory.GetFiles(imagesFoldersLocations[37].FullName).ToList());
            Tuple<string, List<string>> troll2DieSources = new Tuple<string, List<string>>("Die", Directory.GetFiles(imagesFoldersLocations[38].FullName).ToList());
            Tuple<string, List<string>> troll2HurtSources = new Tuple<string, List<string>>("Hurt", Directory.GetFiles(imagesFoldersLocations[39].FullName).ToList());
            Tuple<string, List<string>> troll2WalkSources = new Tuple<string, List<string>>("Walk", Directory.GetFiles(imagesFoldersLocations[40].FullName).ToList());

            List<Tuple<string, List<string>>> troll2Sources = new List<Tuple<string, List<string>>>();
            troll2Sources.Add(troll2AttackSources);
            troll2Sources.Add(troll2DieSources);
            troll2Sources.Add(troll2HurtSources);
            troll2Sources.Add(troll2WalkSources);

            Tuple<string, List<Tuple<string, List<string>>>> troll2Tuple = new Tuple<string, List<Tuple<string, List<string>>>>("Cave Troll", troll2Sources);
            charactersMovesLists.Add(troll2Tuple);
        }

        void SetBackground(int imageNum)
        {
            brush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(images[imageNum], UriKind.Relative));
            brush.ImageSource = image.Source;
            this.Background = brush;
        }

        void StartGame()
        {
            CreateImageSources();

            SetBackground(3);
            diceButton_static.Tag = "Hidden";
            startButton_static.Tag = "Hidden";
            FinalButtons_1_static.Tag = "Hidden";
            FinalButtons_2_static.Tag = "Hidden";
            FinalButtons_3_static.Tag = "Hidden";

            mainLabel_static.Content = "ENTER THE DUNGEON OF DEATH AND FIGHT THE MONSTER!";
            descriptionLabel_static.Content =
            "\tCHOOSE YOUR CHARACTER AND TRY YOUR LUCK!" +
            "\n\t RIGHT-CLICK ON NAMES TO SEE DESCRIPTIONS," +
            "\nTHEN SELECT THE CHOOSEN ONE BY DOUBLE-CLICK CLICK TO START!";

            List<string> characters = charactersMovesLists
                                      .Where(x => !x.Item1.Contains("Orc") 
                                      && !x.Item1.Contains("Troll"))
                                      .Select(x => x.Item1).ToList();

            for (int i = 0; i < characters.Count; i++)
            {
                Button characterButton = new Button();
                characterButton.Content = characters[i];
                characterButton.Name = "Character_" + i.ToString();
                characterButton.Style = (Style)Application.Current.Resources["CharacterButton"];
                if (characters[i].Contains("Knight"))
                {
                    characterButton.Margin = new Thickness(400, 330 + i * 50, 0, 0);
                }
                else
                {
                    characterButton.Margin = new Thickness(600, 330 + (i-3) * 50, 0, 0);
                }
                canvas.Children.Add(characterButton);
                characterButton.MouseDoubleClick += UserFighterButton_Doublelick;
                characterButton.MouseRightButtonDown += characterButton_RightClick;
            }
        }

        private void UserFighterButton_Doublelick(object sender, MouseEventArgs e)
        {
            Button selectedButton = (Button)sender;
            UserFighterChoice = selectedButton.Content.ToString();
            descriptionLabel_static.Content =
            "\tCHOOSE YOUR CHARACTER AND TRY YOUR LUCK!\n\n\t\t\t YOUR CHOICE :\n";

            startButton_static.Tag = "Visible";
            startButton_static.Click += startButton_Click;

            smallLabel_static.Content = UserFighterChoice;
        }

        private void characterButton_RightClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            CharacterDescription newDescription = new CharacterDescription(button.Content.ToString());
            newDescription.ShowDialog();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            RemoveButtons();
            smallLabel_static.Content = "";
            startButton_static.Tag = "Hidden";
            descriptionLabel_static.Content =
            "\t      CHOOSE YOUR ENEMY AND TRY YOUR LUCK!" +
            "\n\t   RIGHT-CLICK ON NAMES TO SEE DESCRIPTIONS," +
            "\nTHEN SELECT THE CHOOSEN ONE BY DOUBLE-CLICK CLICK TO START!";

            SetBackground(2);

            PrepareFight();
        }

        void PrepareFight()
        {
            if (UserFighterChoice.Contains("Warrior"))
            {
                SetCharacterImage(fighterImage, UserFighterChoice, "Attack", 170, 20);
            }
            else
            {
                SetCharacterImage(fighterImage, UserFighterChoice, "Attack", 50, -150);
            }

            List<string> characters = charactersMovesLists.Where(x => x.Item1.Contains("Orc") 
                                      || x.Item1.Contains("Troll")).Select(x => x.Item1).ToList();
            for (int i = 0; i < characters.Count; i++)
            {
                Button characterButton = new Button();
                characterButton.Content = characters[i];
                characterButton.Name = "Character_" + i.ToString();
                characterButton.Style = (Style)Application.Current.Resources["CharacterButton"];
                characterButton.Margin = new Thickness(750, 330 + i * 50, 0, 0);
                canvas.Children.Add(characterButton);
                characterButton.MouseRightButtonDown += characterButton_RightClick;
                characterButton.MouseDoubleClick += UserEnemyButton_DoubleClick;
            }

            SetPoints(UserFighterChoice);
            CreatePointsLabels("fighter");
        }

        private void UserEnemyButton_DoubleClick(object sender, MouseEventArgs e)
        {
            Button selectedButton = (Button)sender;
            UserEnemyChoice = selectedButton.Content.ToString();

            descriptionLabel_static.Content = "";

            RemoveButtons();

            if (UserEnemyChoice.Contains("Orc"))
            {
                SetCharacterImage(enemyImage, UserEnemyChoice, "Attack", 150, 630);
            }
            else
            {
                SetCharacterImage(enemyImage, UserEnemyChoice, "Attack", -50, 560);
            }

            SetPoints(UserEnemyChoice);
            CreatePointsLabels("enemy");

            dice1Image_static.Tag = "Visible";
            dice1Image_static.Source = new BitmapImage(new Uri(images[0]));
            brush = new ImageBrush();
            brush.ImageSource = dice1Image_static.Source;

            dice2Image_static.Tag = "Visible";
            dice2Image_static.Source = new BitmapImage(new Uri(images[0]));
            brush = new ImageBrush();
            brush.ImageSource = dice2Image_static.Source;

            DecideWhoStarts();
        }

        void DecideWhoStarts()
        {
            smallLabel_static.Tag = "StartGameLabel";
            if (fighter_Astral >= enemy_Astral)
            {
                smallLabel_static.Content = "FIGHTER STARTS!";
            }
            else
            {
                smallLabel_static.Content = "MONSTER STARTS!";
            }

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
            timer.Tick += startFightTimer_Tick;

        }

        void startFightTimer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer = null;
            smallLabel_static.Content = "";
            TakeStarterPosition();
        }

        private void rollDicesButton_Click(object sender, EventArgs e)
        {
            diceButton_static.Tag = "Hidden";

            RollTheDice(dice1Image_static);
            RollTheDice(dice2Image_static);

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += fighterStartFight_Tick;
            timer.Start();
        }

        void fighterStartFight_Tick(object sender, EventArgs e)
        {
            Fight(UserFighterChoice);
        }

        void TakeStarterPosition()
        {
            storyBoard = new Storyboard();
            if (UserEnemyChoice.Contains("Troll"))
            {
                moveAnimation(storyBoard, fighterImage, 0, 160, 3);
            }
            else
            {
                moveAnimation(storyBoard, fighterImage, 0, 190, 3);
            }
            if (UserEnemyChoice.Contains("Troll"))
            {
                moveAnimation(storyBoard, enemyImage, 0, -145, 3);
            }
            else
            {
                moveAnimation(storyBoard, enemyImage, 0, -190, 3);
            }
            storyBoard.Completed += move_Completed;
            storyBoard.Begin();

            AnimationTimer(moveTimer_Tick, 40);
        }

        void moveAnimation(Storyboard sb, Image image, int FromValue, int ToValue, int FromSeconds)
        {
            doubleAnimation = new DoubleAnimation(FromValue, ToValue, TimeSpan.FromSeconds(FromSeconds));
            Storyboard.SetTarget(doubleAnimation, image);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.LeftProperty));
            sb.Children.Add(doubleAnimation);
        }

        private void move_Completed(object sender, EventArgs e)
        {
            animationCount = 0;
            currentImageIndex = 0;

            SetBasicCharacterPoses(fighterImage, UserFighterChoice, "Attack");
            SetBasicCharacterPoses(enemyImage, UserEnemyChoice, "Attack");

            timer.Stop();
            timer = null;

            StartFight();
        }

        void StartFight()
        {
            animationCount = 0;
            currentImageIndex = 0;
            doubleAnimation = null;
            storyBoard = null;
            timer = null;

            if(fighter_Astral >= enemy_Astral)
            {
                diceButton_static.Tag = "Visible";
                machineRoundOn = false;
            }
            else
            {
                machineRoundOn = true;
                RollTheDice(dice1Image_static);
                RollTheDice(dice2Image_static);

                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Tick += monsterStartFight_Tick;
                timer.Start();
            }
        }

        void monsterStartFight_Tick(object sender, EventArgs e)
        {
            Fight(UserEnemyChoice);
        }

        void Fight(string roundCharacter)
        {
            totalRoundNumber = CalculateRoundNumber();

            if(roundCharacter == UserFighterChoice)
            {
                List<string> fighterAttackSources = charactersMovesLists.First(x => x.Item1 == UserFighterChoice).Item2.First(y => y.Item1 == "Attack").Item2;
                List<string> enemyHurtSources = charactersMovesLists.First(x => x.Item1 == UserEnemyChoice).Item2.First(y => y.Item1 == "Hurt").Item2;

                if (animationCount < (totalRoundNumber * fighterAttackSources.Count))
                {
                    ImagesAnimation(fighterImage, fighterAttackSources);
                        
                    if(fighter_Physical + totalRoundNumber >= enemy_Protection)
                    {
                        ImagesAnimation(enemyImage, enemyHurtSources);
                    }
                    timer.Stop();
                    timer = null;

                    AnimationTimer(fightTimer_Tick, 45);
                }
                else
                {
                    UpdatePointsFighterRound();

                    timer.Stop();
                    timer = null;
                    animationCount = 0;
                    currentImageIndex = 0;

                    SetBasicCharacterPoses(fighterImage, UserFighterChoice, "Attack");
                    SetBasicCharacterPoses(enemyImage, UserEnemyChoice, "Attack");

                    if (fighter_Vitality > 0 && enemy_Vitality > 0 && CheckDifference(fighter_Astral, enemy_Astral) <= 5)
                    {
                        EnemyRound();
                    }
                    else
                    {
                        if (fighter_Vitality <= 0 || enemy_Vitality <= 0)
                        {
                            if (fighter_Vitality > enemy_Vitality)
                            {
                                machineRoundOn = false;
                            }
                            else
                            {
                                machineRoundOn = true;
                            }
                            GameOverSettings();
                            GameOverByDeath();
                        }
                        else if(CheckDifference(fighter_Astral, enemy_Astral) > 5)
                        {
                            if (fighter_Astral > enemy_Astral)
                            {
                                machineRoundOn = false;
                            }
                            else
                            {
                                machineRoundOn = true;
                            }
                            GameOverSettings();
                            GameOverByRun();
                        }
                    }
                }
            }
            else
            {
                List<string> enemyAttackSources = charactersMovesLists.First(x => x.Item1 == UserEnemyChoice).Item2.First(y => y.Item1 == "Attack").Item2;
                List<string> fighterHurtSources = charactersMovesLists.First(x => x.Item1 == UserFighterChoice).Item2.First(y => y.Item1 == "Hurt").Item2;

                if (animationCount < (totalRoundNumber * enemyAttackSources.Count))
                {
                    ImagesAnimation(enemyImage, enemyAttackSources);

                    if (enemy_Physical + totalRoundNumber >= fighter_Protection)
                    {
                        ImagesAnimation(fighterImage, fighterHurtSources);
                    }
                    timer.Stop();
                    timer = null;

                    AnimationTimer(fightTimer_Tick, 45);
                }
                else
                {
                    UpdatePointsEnemyRound();

                    timer.Stop();
                    timer = null;
                    animationCount = 0;
                    currentImageIndex = 0;

                    SetBasicCharacterPoses(fighterImage, UserFighterChoice, "Attack");
                    SetBasicCharacterPoses(enemyImage, UserEnemyChoice, "Attack");

                    if (fighter_Vitality > 0 && enemy_Vitality > 0 && CheckDifference(fighter_Astral, enemy_Astral) <= 5)
                    {
                        FighterRound();
                    }
                    else
                    {
                        if (fighter_Vitality <= 0 || enemy_Vitality <= 0)
                        {
                            if (fighter_Vitality > enemy_Vitality)
                            {
                                machineRoundOn = false;
                            }
                            else
                            {
                                machineRoundOn = true;
                            }
                            GameOverSettings();
                            GameOverByDeath();
                        }
                        else if(CheckDifference(fighter_Astral, enemy_Astral) > 5)
                        {
                            if (fighter_Astral > enemy_Astral)
                            {
                                machineRoundOn = false;
                            }
                            else
                            {
                                machineRoundOn = true;
                            }
                            GameOverSettings();
                            GameOverByRun();
                        }
                    }
                }
            }
        }

        void fightTimer_Tick(object sender, EventArgs e)
        {
            if (machineRoundOn == true)
            {
                Fight(UserEnemyChoice);
            }
            else
            {
                Fight(UserFighterChoice);
            }
        }

        void UpdatePointsFighterRound()
        {
            fighter_Physical = fighter_Physical + totalRoundNumber;
            Label fighterPhysical = fighterPointsLabels.First(x => x.Name == "fighter_Physical");
            fighterPhysical.Content = "";
            fighterPhysical.Content = fighterPhysical.Name.ToString().Split('_')[1] + " : " + fighter_Physical.ToString();

            if (fighter_Physical >= enemy_Protection)
            {
                if (totalRoundNumber == 12)
                {
                    enemy_Vitality = enemy_Vitality - (fighter_Wounding * 2);
                    enemy_Astral = enemy_Astral - 2;
                }
                else
                {
                    enemy_Vitality = enemy_Vitality - fighter_Wounding;
                    enemy_Astral = enemy_Astral - 1;
                }
                Label enemyVitality = enemyPointsLabels.First(x => x.Name == "enemy_Vitality");
                enemyVitality.Content = "";
                enemyVitality.Content = enemyVitality.Name.ToString().Split('_')[1] + " : " + enemy_Vitality.ToString();

                Label enemyAstral = enemyPointsLabels.First(x => x.Name == "enemy_Astral");
                enemyAstral.Content = "";
                enemyAstral.Content = enemyAstral.Name.ToString().Split('_')[1] + " : " + enemy_Astral.ToString();
            }

            fighter_Mental = fighter_Mental - 1;
            Label fighterMental = fighterPointsLabels.First(x => x.Name == "fighter_Mental");
            fighterMental.Content = "";
            fighterMental.Content = fighterMental.Name.ToString().Split('_')[1] + " : " + fighter_Mental.ToString();

            enemy_Mental = enemy_Mental - 1;
            Label enemyMental = enemyPointsLabels.First(x => x.Name == "enemy_Mental");
            enemyMental.Content = "";
            enemyMental.Content = enemyMental.Name.ToString().Split('_')[1] + " : " + enemy_Mental.ToString();

            if (fighter_Mental <= 0)
            {
                fighter_Wounding = fighter_Wounding_New;
                Label fighterWounding = fighterPointsLabels.First(x => x.Name == "fighter_Wounding");
                fighterWounding.Content = "";
                fighterWounding.Content = fighterWounding.Name.ToString().Split('_')[1] + " : " + fighter_Wounding.ToString();
            }
            if (enemy_Mental <= 0)
            {
                enemy_Wounding = enemy_Wounding_New;
                Label enemyWounding = enemyPointsLabels.First(x => x.Name == "enemy_Wounding");
                enemyWounding.Content = "";
                enemyWounding.Content = enemyWounding.Name.ToString().Split('_')[1] + " : " + enemy_Wounding.ToString();
            }

            fighter_Protection = fighter_Physical + fighter_Mental;
            Label fighterProtection = fighterPointsLabels.First(x => x.Name == "fighter_Protection");
            fighterProtection.Content = "";
            fighterProtection.Content = fighterProtection.Name.ToString().Split('_')[1] + " : " + fighter_Protection.ToString();

            enemy_Protection = enemy_Physical + enemy_Mental;
            Label enemyProtection = enemyPointsLabels.First(x => x.Name == "enemy_Protection");
            enemyProtection.Content = "";
            enemyProtection.Content = enemyProtection.Name.ToString().Split('_')[1] + " : " + enemy_Protection.ToString();
        }

        void UpdatePointsEnemyRound()
        {
            enemy_Physical = enemy_Physical + totalRoundNumber;
            Label enemyPhysical = enemyPointsLabels.First(x => x.Name == "enemy_Physical");
            enemyPhysical.Content = "";
            enemyPhysical.Content = enemyPhysical.Name.ToString().Split('_')[1] + " : " + enemy_Physical.ToString();

            if (enemy_Physical >= fighter_Protection)
            {
                if (totalRoundNumber == 12)
                {
                    fighter_Vitality = fighter_Vitality - (enemy_Wounding * 2);
                    fighter_Astral = fighter_Astral - 2;
                }
                else
                {
                    fighter_Vitality = fighter_Vitality - enemy_Wounding;
                    fighter_Astral = fighter_Astral - 1;
                }
                Label fighterVitality = fighterPointsLabels.First(x => x.Name == "fighter_Vitality");
                fighterVitality.Content = "";
                fighterVitality.Content = fighterVitality.Name.ToString().Split('_')[1] + " : " + fighter_Vitality.ToString();

                Label fighterAstral = fighterPointsLabels.First(x => x.Name == "fighter_Astral");
                fighterAstral.Content = "";
                fighterAstral.Content = fighterAstral.Name.ToString().Split('_')[1] + " : " + fighter_Astral.ToString();
            }

            fighter_Mental = fighter_Mental - 1;
            Label fighterMental = fighterPointsLabels.First(x => x.Name == "fighter_Mental");
            fighterMental.Content = "";
            fighterMental.Content = fighterMental.Name.ToString().Split('_')[1] + " : " + fighter_Mental.ToString();

            enemy_Mental = enemy_Mental - 1;
            Label enemyMental = enemyPointsLabels.First(x => x.Name == "enemy_Mental");
            enemyMental.Content = "";
            enemyMental.Content = enemyMental.Name.ToString().Split('_')[1] + " : " + enemy_Mental.ToString();

            if (fighter_Mental <= 0)
            {
                fighter_Wounding = fighter_Wounding_New;
                Label fighterWounding = fighterPointsLabels.First(x => x.Name == "fighter_Wounding");
                fighterWounding.Content = "";
                fighterWounding.Content = fighterWounding.Name.ToString().Split('_')[1] + " : " + fighter_Wounding.ToString();
            }
            if (enemy_Mental <= 0)
            {
                enemy_Wounding = enemy_Wounding_New;
                Label enemyWounding = enemyPointsLabels.First(x => x.Name == "enemy_Wounding");
                enemyWounding.Content = "";
                enemyWounding.Content = enemyWounding.Name.ToString().Split('_')[1] + " : " + enemy_Wounding.ToString();
            }

            enemy_Protection = enemy_Physical + enemy_Mental;
            Label enemyProtection = enemyPointsLabels.First(x => x.Name == "enemy_Protection");
            enemyProtection.Content = "";
            enemyProtection.Content = enemyProtection.Name.ToString().Split('_')[1] + " : " + enemy_Protection.ToString();

            fighter_Protection = fighter_Physical + fighter_Mental;
            Label fighterProtection = fighterPointsLabels.First(x => x.Name == "fighter_Protection");
            fighterProtection.Content = "";
            fighterProtection.Content = fighterProtection.Name.ToString().Split('_')[1] + " : " + fighter_Protection.ToString();
        }

        void FighterRound()
        {
            machineRoundOn = false;
            currentImageIndex = 0;

            dice1Image_static.Source = new BitmapImage(new Uri(images[0]));
            brush = new ImageBrush();
            brush.ImageSource = dice1Image_static.Source;

            dice2Image_static.Source = new BitmapImage(new Uri(images[0]));
            brush = new ImageBrush();
            brush.ImageSource = dice2Image_static.Source;

            diceButton_static.Tag = "Visible";
        }

        void EnemyRound()
        {
            machineRoundOn = true;
            currentImageIndex = 0;
            diceButton_static.Tag = "Hidden";

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += machineDiceRoll_Tick;
            timer.Start();
        }

        void GameOverByDeath()
        {
            AnimationTimer(gameOverDie_Tick, 60);
        }

        void GameOverByRun()
        {
            storyBoard = new Storyboard();
            if (machineRoundOn == true)
            {
                FlipImage(fighterImage, -1);
                runAwayAnimation(storyBoard, fighterImage, 190, -400, 4);
            }
            else
            {
                FlipImage(enemyImage, 1);
                runAwayAnimation(storyBoard, enemyImage, -190, 400, 4);
            }
            storyBoard.Completed += runAway_Completed;
            storyBoard.Begin();
            AnimationTimer(runAwayTimer_Tick, 60);
        }

        void GameOverSettings()
        {
            ResultToTxt();

            dice1Image_static.Tag = "Hidden";
            dice2Image_static.Tag = "Hidden";
            diceButton_static.Tag = "Hidden";

            smallLabel_static.Tag = "EndResultLabel";
            if (machineRoundOn == false)
            {
                smallLabel_static.Content = "CONGRATULATIONS, YOU WON!";
            }
            else
            {
                smallLabel_static.Content = "SORRY, NOW THE MONSTER WON!";
            }

            FinalButtons_1_static.Tag = "Visible";
            FinalButtons_2_static.Tag = "Visible";
            FinalButtons_3_static.Tag = "Visible";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fightAgainButton_Click(object sender, EventArgs e)
        {
            foreach(UIElement element in canvas.Children.OfType<UIElement>().ToList())
            {
                if(element != mainLabel_static && element != descriptionLabel_static && element != smallLabel_static
                   && element != dice1Image_static && element != dice2Image_static && element != startButton_static 
                   && element != diceButton_static && element != FinalButtons_1_static && element != FinalButtons_2_static
                   && element != FinalButtons_3_static)
                {
                    canvas.Children.Remove(element);
                }
            }

            foreach (Label element in canvas.Children.OfType<Label>().ToList())
            {
                if (element.Name.StartsWith("fighter_"))
                {
                    element.Content = "";
                    canvas.Children.Remove(element);
                }
            }

            smallLabel_static.Tag = "StartGameLabel";
            smallLabel_static.Content = "";

            charactersMovesLists.Clear();
            fighterPointsLabels.Clear();
            enemyPointsLabels.Clear();
            imagesFoldersLocations.Clear();
            dicesSources.Clear();
            images.Clear();

            UserEnemyChoice = null;
            UserFighterChoice = null;

            doubleAnimation = null;
            storyBoard = new Storyboard();

            machineRoundOn = false;

            totalRoundNumber = 0;
            fighter_Physical = 0;
            fighter_Astral = 0;
            fighter_Mental = 0;
            fighter_Vitality = 0;
            fighter_Wounding = 0;
            fighter_Wounding_New = 0;
            fighter_Protection = 0;
            enemy_Physical = 0;
            enemy_Astral = 0;
            enemy_Mental = 0;
            enemy_Vitality = 0;
            enemy_Wounding = 0;
            enemy_Wounding_New = 0;
            enemy_Protection = 0;
            currentImageIndex = 0;
            animationCount = 0;

            StartGame();
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics();
            statistics.ShowDialog();
        }

        void runAwayAnimation(Storyboard sb, Image image, int FromValue, int ToValue, int FromSeconds)
        {
            doubleAnimation = new DoubleAnimation(FromValue, ToValue, TimeSpan.FromSeconds(FromSeconds));
            Storyboard.SetTarget(doubleAnimation, image);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.LeftProperty));
            sb.Children.Add(doubleAnimation);
        }

        private void runAway_Completed(object sender, EventArgs e)
        {
            animationCount = 0;
            currentImageIndex = 0;

            if (machineRoundOn == false)
            {
                SetBasicCharacterPoses(fighterImage, UserFighterChoice, "Attack");
            }
            else
            {
                SetBasicCharacterPoses(enemyImage, UserEnemyChoice, "Attack");
            }

            timer.Stop();
            timer = null;
        }

        void gameOverDie_Tick(object sender, EventArgs e)
        {
            if(machineRoundOn == false)
            {
                List<string> enemyDieSources = charactersMovesLists.First(x => x.Item1 == UserEnemyChoice).Item2.First(y => y.Item1 == "Die").Item2;

                if (animationCount < enemyDieSources.Count-1)
                {
                    ImagesAnimation(enemyImage, enemyDieSources);

                    timer.Stop();
                    timer = null;

                    GameOverByDeath();
                }
                else
                {
                    timer.Stop();
                    timer = null;
                }
            }
            else
            {
                List<string> fighterDieSources = charactersMovesLists.First(x => x.Item1 == UserFighterChoice).Item2.First(y => y.Item1 == "Die").Item2;

                if (animationCount < fighterDieSources.Count-1)
                {
                    ImagesAnimation(fighterImage, fighterDieSources);

                    timer.Stop();
                    timer = null;

                    GameOverByDeath();
                }
                else
                {
                    timer.Stop();
                    timer = null;
                }
            }
        }

        void machineDiceRoll_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer = null;

            RollTheDice(dice1Image_static);
            RollTheDice(dice2Image_static);
            
            AnimationTimer(fightTimer_Tick, 60);
        }

        int CheckDifference(int nr1, int nr2)
        {
            if(nr1 > nr2)
            {
                return nr1 - nr2;
            }
            else
            {
                return nr2 - nr1;
            }
        }

        void CreatePointsLabels(string character)
        {
            List<string> points = new List<string>() { "Physical", "Astral", "Mental", "Vitality", "Wounding", "Protection" };

            Label characterNameLabel = new Label();
            characterNameLabel.Style = (Style)Application.Current.Resources["NameLabel"];
            canvas.Children.Add(characterNameLabel);

            if (character.ToLower() == "fighter")
            {
                List<int> fighterPoints = new List<int>() { fighter_Physical, fighter_Astral, fighter_Mental, 
                                                            fighter_Vitality, fighter_Wounding, fighter_Protection };

                characterNameLabel.Name = "fighter_Name";
                characterNameLabel.Margin = new Thickness(0,50, 0, 0);
                characterNameLabel.Content = UserFighterChoice;

                for (int i = 0; i < points.Count; i++)
                {
                    Label fighterLabel = new Label();
                    fighterLabel.Name = "fighter_" + points[i];
                    fighterLabel.Style = (Style)Application.Current.Resources["PointsLabel"];
                    fighterLabel.Margin = new Thickness(0, 90 + i * 30, 0, 0);
                    fighterLabel.Content = points[i] + " : " + fighterPoints[i].ToString();
                    canvas.Children.Add(fighterLabel);
                    fighterPointsLabels.Add(fighterLabel);
                }
            }
            else
            {
                List<int> enemyPoints = new List<int>() { enemy_Physical, enemy_Astral, enemy_Mental,
                                                          enemy_Vitality, enemy_Wounding, enemy_Protection };

                characterNameLabel.Name = "enemy_Name";
                characterNameLabel.Margin = new Thickness(1000, 50, 0, 0);
                characterNameLabel.Content = UserEnemyChoice;

                for (int i = 0; i < points.Count; i++)
                {
                    Label enemyLabel = new Label();
                    enemyLabel.Name = "enemy_" + points[i];
                    enemyLabel.Style = (Style)Application.Current.Resources["PointsLabel"];
                    enemyLabel.Margin = new Thickness(1000, 90 + i * 30, 0, 0);
                    enemyLabel.Content = points[i] + " : " + enemyPoints[i].ToString();
                    canvas.Children.Add(enemyLabel);
                    enemyPointsLabels.Add(enemyLabel);
                }
            }
        }

        void SetPoints(string characterName)
        {
            switch (characterName)
            {
                case "Red Knight":
                    fighter_Physical = 12;
                    fighter_Astral = 6;
                    fighter_Mental = 7;
                    fighter_Vitality = 13;
                    fighter_Wounding = 3;
                    fighter_Wounding_New = 2;
                    fighter_Protection = fighter_Physical + fighter_Mental;
                    break;
                case "Night Knight":
                    fighter_Physical = 8;
                    fighter_Astral = 11;
                    fighter_Mental = 6;
                    fighter_Vitality = 9;
                    fighter_Wounding = 3;
                    fighter_Wounding_New = 2;
                    fighter_Protection = fighter_Physical + fighter_Mental;
                    break;
                case "Golden Knight":
                    fighter_Physical = 7;
                    fighter_Astral = 8;
                    fighter_Mental = 10;
                    fighter_Vitality = 8;
                    fighter_Wounding = 2;
                    fighter_Wounding_New = 1;
                    fighter_Protection = fighter_Physical + fighter_Mental;
                    break;
                case "Valkyrie Warrior":
                    fighter_Physical = 11;
                    fighter_Astral = 9;
                    fighter_Mental = 5;
                    fighter_Vitality = 12;
                    fighter_Wounding = 3;
                    fighter_Wounding_New = 2;
                    fighter_Protection = fighter_Physical + fighter_Mental;
                    break;
                case "Amazon Warrior":
                    fighter_Physical = 6;
                    fighter_Astral = 10;
                    fighter_Mental = 9;
                    fighter_Vitality = 7;
                    fighter_Wounding = 2;
                    fighter_Wounding_New = 1;
                    fighter_Protection = fighter_Physical + fighter_Mental;
                    break;
                case "Elf Warrior":
                    fighter_Physical = 7;
                    fighter_Astral = 7;
                    fighter_Mental = 11;
                    fighter_Vitality = 8;
                    fighter_Wounding = 2;
                    fighter_Wounding_New = 1;
                    fighter_Protection = fighter_Physical + fighter_Mental;
                    break;
                case "Soldier Orc":
                    enemy_Physical = 7;
                    enemy_Astral = 9;
                    enemy_Mental = 9;
                    enemy_Vitality = 8;
                    enemy_Wounding = 2;
                    enemy_Wounding_New = 1;
                    enemy_Protection = enemy_Physical + enemy_Mental;
                    break;
                case "Pirate Orc":
                    enemy_Physical = 10;
                    enemy_Astral = 10;
                    enemy_Mental = 5;
                    enemy_Vitality = 11;
                    enemy_Wounding = 3;
                    enemy_Wounding_New = 2;
                    enemy_Protection = enemy_Physical + enemy_Mental;
                    break;
                case "Mountain Troll":
                    enemy_Physical = 12;
                    enemy_Astral = 8;
                    enemy_Mental = 5;
                    enemy_Vitality = 13;
                    enemy_Wounding = 2;
                    enemy_Wounding_New = 1;
                    enemy_Protection = enemy_Physical + enemy_Mental;
                    break;
                default:
                    enemy_Physical = 10;
                    enemy_Astral = 8;
                    enemy_Mental = 7;
                    enemy_Vitality = 11;
                    enemy_Wounding = 2;
                    enemy_Wounding_New = 1;
                    enemy_Protection = enemy_Physical + enemy_Mental;
                    break;
            }
        }

        void RemoveButtons()
        {
            foreach (Button b in canvas.Children.OfType<Button>().ToList())
            {
                if(b.Name.Contains("Character_"))
                {
                    canvas.Children.Remove(b);
                }
            }
        }

        void SetCharacterImage(Image image, string sourceCharName, string sourceMoveName, int top, int left)
        {
            string reference = charactersMovesLists.First(x => x.Item1 == sourceCharName).Item2.First(x => x.Item1 == sourceMoveName).Item2[0];

            if(image == fighterImage)
            {
                fighterImage = new Image();
                fighterImage.Margin = new Thickness(left, top, 0, 0);

                if (reference.Contains("Warrior"))
                {
                    fighterImage.Width = 480;
                    fighterImage.Height = 480;
                }
                else if (reference.Contains("Knight"))
                {
                    fighterImage.Width = 800;
                    fighterImage.Height = 800;
                }

                fighterImage.Source = new BitmapImage(new Uri(reference));
                fighterImage.Name = "fighterImage";
                brush = new ImageBrush();
                brush.ImageSource = fighterImage.Source;

                foreach (Image i in canvas.Children.OfType<Image>().ToList())
                {
                    if(i.Name == "fighterImage")
                    {
                        canvas.Children.Remove(i);
                    }    
                }
                canvas.Children.Add(fighterImage);
            }
            else
            {
                enemyImage = new Image();
                enemyImage.Margin = new Thickness(left, top, 0, 0);

                if (reference.Contains("Orc"))
                {
                    enemyImage.Width = 480;
                    enemyImage.Height = 480;
                }
                else if (reference.Contains("Troll"))
                {
                    enemyImage.Width = 800;
                    enemyImage.Height = 800;
                }

                enemyImage.Source = new BitmapImage(new Uri(reference));
                enemyImage.Name = "enemyImage";
                brush = new ImageBrush();
                brush.ImageSource = enemyImage.Source;

                FlipImage(enemyImage, -1);

                if (!canvas.Children.Contains(enemyImage))
                {
                    canvas.Children.Add(enemyImage);
                }
            }
        }

        void SetBasicCharacterPoses(Image image, string sourceCharName, string sourceMoveName)
        {
            string reference = charactersMovesLists.First(x => x.Item1 == sourceCharName).Item2.First(x => x.Item1 == sourceMoveName).Item2[0];

            image.Source = new BitmapImage(new Uri(reference));
            brush = new ImageBrush();
            brush.ImageSource = image.Source;

            if(image == enemyImage)
            {
                FlipImage(image, -1);
            }
        }

        void ImagesAnimation(Image image, List<string> imagesMove)
        {
            if (currentImageIndex + 1 >= imagesMove.Count)
            {
                currentImageIndex = 0;
            }
            else
            {
                currentImageIndex++;
            }

            image.Source = new BitmapImage(new Uri(imagesMove[currentImageIndex]));

            animationCount++;
        }

        void AnimationTimer(EventHandler tick, int milliSeconds)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, milliSeconds);
            timer.Tick += tick;
            timer.Start();
        }

        void FlipImage(Image image, int scaleX)
        {
            flipTrans = new ScaleTransform();
            flipTrans.ScaleX = scaleX;
            image.RenderTransformOrigin = new Point(0.5, 0.5);
            image.RenderTransform = flipTrans;
        }

        void RollTheDice(Image diceImage)
        {
            generator = new Random();
            int diceNum = generator.Next(0, dicesSources.Count);
            diceImage.Source = new BitmapImage(new Uri(dicesSources[diceNum]));
            brush = new ImageBrush();
            brush.ImageSource = diceImage.Source;
        }

        int CalculateRoundNumber()
        {
            int roundNumber1 = Convert.ToInt32(dice1Image_static.Source.ToString().Split('/').Last().Split('.').First());
            int roundNumber2 = Convert.ToInt32(dice2Image_static.Source.ToString().Split('/').Last().Split('.').First());

            return roundNumber1 + roundNumber2;
        }

        void moveTimer_Tick(object sender, EventArgs e)
        {
            List<string> fighterSources = charactersMovesLists.First(x => x.Item1 == UserFighterChoice).Item2.First(y => y.Item1 == "Walk").Item2;
            List<string> enemySources = charactersMovesLists.First(x => x.Item1 == UserEnemyChoice).Item2.First(y => y.Item1 == "Walk").Item2;

            ImagesAnimation(fighterImage, fighterSources);
            ImagesAnimation(enemyImage, enemySources);
            timer.Stop();
            timer = null;
            AnimationTimer(moveTimer_Tick, 60);
        }

        void runAwayTimer_Tick(object sender, EventArgs e)
        {
            if(machineRoundOn == true)
            {
                List<string> fighterSources = charactersMovesLists.First(x => x.Item1 == UserFighterChoice).Item2.First(y => y.Item1 == "Walk").Item2;

                ImagesAnimation(fighterImage, fighterSources);
                timer.Stop();
                timer = null;
                AnimationTimer(runAwayTimer_Tick, 60);
            }
            else
            {
                List<string> enemySources = charactersMovesLists.First(x => x.Item1 == UserEnemyChoice).Item2.First(y => y.Item1 == "Walk").Item2;

                ImagesAnimation(enemyImage, enemySources);
                timer.Stop();
                timer = null;
                AnimationTimer(runAwayTimer_Tick, 60);
            }
        }
        
        void ResultToTxt()
        {
            using(TextWriter writer = new StreamWriter("statistics.txt", append:true))
            {
                if (machineRoundOn == false)
                {
                    writer.WriteLine(string.Format("Fighter : " + UserFighterChoice.ToString() 
                                                  + " / Monster : " + UserEnemyChoice.ToString() 
                                                  + " => Winner : Fighter = " + UserFighterChoice.ToString()));
                }
                else
                {
                    writer.WriteLine(string.Format("Fighter : " + UserFighterChoice.ToString() 
                                                  + " / Monster : " + UserEnemyChoice.ToString() 
                                                  + " => Winner : Monster = " + UserEnemyChoice.ToString()));
                }
            }
        }
    }
}
