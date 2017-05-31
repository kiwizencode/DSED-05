using GreyHoundApp.Data.DogClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GreyHoundApp.WPF.Model
{
    public class DogModelClass : DogBaseClass
    {
        public int ID { get; private set; } = -1;
        public int Top;
        public int Left;
        public Image image { get; private set; }
        public delegate void processScreen(DogModelClass dog, int id);
        public processScreen callBackMethod = null;
        //
        public DogModelClass(DogBaseClass dog)
        {
            image = new Image();
            image.Width = 65;
            image.Height = 25;
            image.Source = new BitmapImage(new System.Uri(@"/dog.png", UriKind.Relative));

            ID = DogGeneratorClass.GenerateID();
            Breed_Type = dog.Breed_Type;
            Breed = dog.Breed;
            Steps = dog.Steps;
            Origin = dog.Origin;
            Size = dog.Size;
        }
        public void Move(object sender, EventArgs e)
        {
            if (callBackMethod != null)
                callBackMethod(this, this.ID);
        }
    }
}
