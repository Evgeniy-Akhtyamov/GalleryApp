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
    public partial class PinPage : ContentPage
    {
        public string UserPin { get; set; }
        public PinPage()
        {
            InitializeComponent();            
        }
        protected override void OnAppearing()
        {
            // Проверка установлен ли PIN-код
            if (App.Current.Properties.TryGetValue("Pin", out object pin))
            {
                UserPin = pin as string;
                pinMessage.Text = "Введите PIN-код";
                // Создание кнопки входа
                var inputButton = new Button
                {
                    BackgroundColor = Color.LightCyan,
                    Margin = new Thickness(30, 5),
                    Text = "Войти",
                    CornerRadius = 15,
                    Opacity = 0.6
                    
                };
                inputButton.Clicked += (sender, e) => inputButton_Clicked(sender, e);
                stackLayout.Children.Add(inputButton);
            }
            else
            {
                pinMessage.Text = "Установите PIN-код";
                // Создание кнопки установки Pin-кода
                var setPinButton = new Button
                {
                    BackgroundColor = Color.LightCyan,
                    Margin = new Thickness(30, 5),
                    Text = "Установить PIN",
                    CornerRadius = 15,
                    Opacity = 0.6
                };
                setPinButton.Clicked += (sender, e) => setPinButton_Clicked(sender, e);
                stackLayout.Children.Add(setPinButton);
            }
            base.OnAppearing();
        }

        private async void setPinButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(pinEntry.Text) || pinEntry.Text.Length != 4)
                infoMessage.Text = "Установите PIN-код в правильном формате";
            else
            {
                App.Current.Properties.Add("Pin", pinEntry.Text);
                infoMessage.Text = null;
                pinMessage.Text = "PIN-код установлен";

                await Task.Delay(700);  
                await Navigation.PushAsync(new ImagesListPage());
                
                stackLayout.Children.RemoveAt(stackLayout.Children.Count - 1);
                pinEntry.Text = null;
                infoMessage.Text = null;
            }
        }

        private async void inputButton_Clicked(object sender, EventArgs e)
        {
            if(pinEntry.Text == UserPin)
            {
                await Navigation.PushAsync(new ImagesListPage());
                stackLayout.Children.RemoveAt(stackLayout.Children.Count - 1);

                infoMessage.Text = null;
                pinEntry.Text = null;
            }
            else
            {
                infoMessage.Text = "Введите верный PIN-код";
            }
        }
    }
}