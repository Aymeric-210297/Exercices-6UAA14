using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _6TTI_WPFACT07_AY
{
    class Chien
    {
        private int _numero;
        private Image _image;
        private bool _isFinished;

        public int Numero
        {
            get { return _numero; }
        }

        public Image Image
        {
            get { return _image; }
        }

        public bool IsFinished
        {
            get { return _isFinished; }
            set { _isFinished = value; }
        }

        public Chien(int numero, Canvas canvasPiste)
        {
            _numero = numero;

            BitmapImage bitmapImageChien = new BitmapImage();
            bitmapImageChien.BeginInit();
            bitmapImageChien.UriSource = new Uri("/assets/dog.png", UriKind.Relative);
            bitmapImageChien.EndInit();

            _image = new Image();
            _image.Source = bitmapImageChien;
            _image.Height = 25;

            Canvas.SetLeft(_image, 40);
            Canvas.SetTop(_image, 65 * _numero);
            canvasPiste.Children.Add(_image);
        }

        public void ResetImage()
        {
            BitmapImage bitmapImageChien = new BitmapImage();
            bitmapImageChien.BeginInit();
            bitmapImageChien.UriSource = new Uri("/assets/dog.png", UriKind.Relative);
            bitmapImageChien.EndInit();

            _image.Source = bitmapImageChien;
            _image.Opacity = 1;
            _image.RenderTransform = null;
            Canvas.SetLeft(_image, 40);
        }

        public void FaireAvancer(int pas)
        {
            Canvas.SetLeft(_image, Canvas.GetLeft(_image) + pas);
        }
    }
}
