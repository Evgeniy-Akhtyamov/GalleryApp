using GalleryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalleryApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public Picture OpenedPicture { get; set; }
        public ImagePage(Picture picture)
        {
            InitializeComponent();

            OpenedPicture = picture;
            dataLabel.Text = $"Создано: {OpenedPicture.CreationDate}";

            BindingContext = this;
        }
    }
}