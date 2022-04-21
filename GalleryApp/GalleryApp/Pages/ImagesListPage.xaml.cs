using GalleryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
//using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace GalleryApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagesListPage : ContentPage
    {
        /// <summary>
        /// Ссылка на выбранное изображение
        /// </summary>
        Picture SelectedPicture;

        /// <summary>
        /// Коллекция изображений в папке
        /// </summary>
        public ObservableCollection<Picture> Pictures { get; set; } = new ObservableCollection<Picture>();

        public ImagesListPage()
        {
            InitializeComponent();
             
            string ImagesPath = @"/storage/emulated/0/Pictures";
            var filePaths = Directory.GetFiles(ImagesPath);
            foreach (var path in filePaths)
            {
                var fileInfo = new FileInfo(path);
                Pictures.Add(new Picture(path, fileInfo.Name, fileInfo.CreationTime));
            }

            BindingContext = this;
        }        

        /// <summary>
        /// Обработчик выбора
        /// </summary>
        private void pictureList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {     
            if (e.SelectedItem != null)
                SelectedPicture = (Picture)e.SelectedItem; // распаковка модели изображения из объекта
            ((ListView)sender).SelectedItem = null; // снимаем выделение
        }

        private async void openButton_Clicked(object sender, EventArgs e)
        {
            // проверяем, выбрал ли пользователь изображение из списка
            if (SelectedPicture == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите изображение!", "OK");
                return;
            }

            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new ImagePage(SelectedPicture));
        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
            // проверяем, выбрал ли пользователь изображение из списка
            if (SelectedPicture == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите изображение!", "OK");
                return;
            }
            // удаляем файл из папки и изображение из коллекции
            File.Delete(SelectedPicture.Image);
            Pictures.Remove(SelectedPicture);
        }
    }
}