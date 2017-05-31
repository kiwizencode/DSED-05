using GreyHoundApp.Data.DogClass;
using GreyHoundApp.Data.PunterClass;
using GreyHoundApp.WPF.Model;
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
using System.Windows.Threading;

namespace GreyHoundApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        List<DogModelClass> myListOfDogs = new List<DogModelClass>();
        bool winflag = false;

        public MainWindow()
        {
            InitializeComponent();

            ClearLabel();

            InitializeTimer();

            CreateDogModel();

            CreatePunterObject();

            InitializeDogModelPosition();

            for( int i =0; i < myListOfDogs.Count; i++)
            {
                ComboBoxDogList.Items.Add($"Dog {i+1}");
            }
        }

        private void CreatePunterObject()
        {
            List<PunterBaseClass> items = new List<PunterBaseClass>();
            items.Add(PunterGeneratorClass.FactoryMethod(PunterGeneratorClass.JOE_CLASS));
            items.Add(PunterGeneratorClass.FactoryMethod(PunterGeneratorClass.BOB_CLASS));
            items.Add(PunterGeneratorClass.FactoryMethod(PunterGeneratorClass.AI_CLASS));
            PunterList.ItemsSource = items;
        }

        private void ClearLabel()
        {
            LabelPunterName.Content = string.Empty;
            LabelAmount.Content = string.Empty;
            LabelBet.Content = string.Empty;

            ComboBoxDogList.SelectedIndex = -1;
        }

        private void CreateDogModel()
        {
            DogBaseClass dog = DogGeneratorClass.FactoryMethod(DogGeneratorClass.BEAGLE, "Be");
            CreateDogModel(3, 7, dog);

            dog = DogGeneratorClass.FactoryMethod(DogGeneratorClass.BULLDOG, "Bull");
            CreateDogModel(45, 7, dog);

            dog = DogGeneratorClass.FactoryMethod(DogGeneratorClass.GERMAN_SHEPHARD, "GS");
            CreateDogModel(90, 7, dog);
            //

            dog = DogGeneratorClass.FactoryMethod(DogGeneratorClass.GREAT_PYTENEES, "BIG");
            CreateDogModel(130, 7, dog);
        }

        /// <summary>
        /// Initialize the timer control
        /// </summary>
        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
        }

        private void CreateDogModel(int Top, int Left, DogBaseClass dog)
        {
            DogModelClass dogmodel;
            dogmodel = new DogModelClass(dog);
            dogmodel.callBackMethod = displayImage;
            dogmodel.Top = Top;
            dogmodel.Left = Left;

            //Canvas.SetTop(dogmodel.image, Top);
            //Canvas.SetLeft(dogmodel.image, Left);
            myCanvas.Children.Add(dogmodel.image);

            timer.Tick += new EventHandler(dogmodel.Move);

            myListOfDogs.Add(dogmodel);
        }

        private void InitializeDogModelPosition()
        {
             foreach (DogModelClass model in myListOfDogs)
             {
                Canvas.SetTop(model.image, model.Top);
                Canvas.SetLeft(model.image, model.Left);
             }

            winflag = false;
        }

        void displayImage(DogModelClass dog, int id)
        {
            if (winflag)
            {
                timer.Stop();
                return;
            }


            Image image = dog.image;
            long dogPos = Convert.ToInt64(image.GetValue(Canvas.LeftProperty));//calculating the dog postion with respect to left property

            if (dogPos >= RaceTrack.Width - image.Width) //800 is the width of the panel
            {
                timer.Stop();
                if (!winflag)
                {
                    MessageBox.Show($"Dog {id} has won!!!");
                    CheckForWinner(id);
                    winflag = true;
                    InitializeDogModelPosition();
                    PunterList.Items.Refresh();
                }
            }
            else
            {
                int pace = DogGeneratorClass.GenerateSteps(dog as DogBaseClass);
                Canvas.SetLeft(image, dogPos + pace);

            }
        }

        private void CheckForWinner(int winer_id)
        {
            foreach(dynamic punter in PunterList.Items)
            {
                if(punter.DogID != PunterBaseClass.NO_DOG_SELECTED)
                {
                    if (punter.DogID == winer_id)
                        punter.WinGame();
                    else
                        punter.LoseGame();
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //InitializeDogModelPosition();
            timer.Start();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PunterList_Click(object sender, MouseButtonEventArgs e)
        {
            if (PunterList.SelectedIndex < 0) return;

            int i = PunterList.SelectedIndex;
            dynamic item = PunterList.Items[i];
            LabelPunterName.Content = item.Name;
            LabelAmount.Content = item.Amount;
            LabelBet.Content = 0;
            BetSlider.Maximum = item.Amount;
            BetSlider.Value = item.Bet;

            if (item.DogID == PunterBaseClass.NO_DOG_SELECTED)
                ComboBoxDogList.SelectedIndex = PunterBaseClass.NO_DOG_SELECTED;
            else
                ComboBoxDogList.SelectedIndex = item.DogID-1;

        }

        private void BetSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelBet.Content = BetSlider.Value;
        }

        private void BetButton_Click(object sender, RoutedEventArgs e)
        {
            int i = PunterList.SelectedIndex;
            dynamic item = PunterList.Items[i];

            if (ComboBoxDogList.SelectedIndex < 0)
            {
                item.DogID = PunterBaseClass.NO_DOG_SELECTED;
                item.Bet = 0;
                return;
            }

            item.DogID = ComboBoxDogList.SelectedIndex + 1;
            item.Bet = Convert.ToInt32(BetSlider.Value);

            ClearLabel();
        }
    }
}
