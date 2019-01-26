using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Provider;
using Android.Net;
using Java.IO;

namespace LipDemo.Droid

{
    [Activity(Label = "LipDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly File file = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                                Android.OS.Environment.DirectoryPictures), "tmp.jpg");

        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            (Xamarin.Forms.Application.Current as App).ShouldTakePicture += () => {
                var intent = new Intent(MediaStore.ActionImageCapture);
                intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));
                StartActivityForResult(intent, 0);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            (Xamarin.Forms.Application.Current as App).ShowImage(file.Path);
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}