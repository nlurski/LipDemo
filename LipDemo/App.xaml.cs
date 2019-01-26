using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace LipDemo
{
    public partial class App : Application
    {
        readonly Image image = new Image();
        public App()
        {
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                new Button {
                    Text = "Take a picture!",
                    Command = new Command(o => ShouldTakePicture()),
                },
                image,
            },
                },
            };
        }
        public void ShowImage(string filepath)
        {
            image.Source = ImageSource.FromFile(filepath);
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public event Action ShouldTakePicture = () => { };
    }
}
