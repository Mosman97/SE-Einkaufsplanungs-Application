using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
//Nicht System aber was fehtl fuer EventArgs?
using System;

namespace EInkaufsplanerSEProject
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {

            Button btnentrar;

            //Wird automatisch generiert
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Reference Button
            btnentrar = FindViewById<Button>(Resource.Id.createlist);

            //Sprung in andere activity
            btnentrar.Click += btnentrar_Click;
            /*
            {
                StartActivity(new Intent(this, typeof(listeditorclass)));
            };
            */

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        void btnentrar_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ListEditorActivity));
            this.StartActivity(intent);
        }

    }
}