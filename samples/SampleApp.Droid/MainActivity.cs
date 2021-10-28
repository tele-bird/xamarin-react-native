using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;

namespace SampleApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Button navigateButton;
        EditText reactMessage_EditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            navigateButton = FindViewById<Button>(Resource.Id.navigate_button);
            navigateButton.Click += BtnNavigateToRN_Click;

            reactMessage_EditText = FindViewById<EditText>(Resource.Id.react_message);
        }

        private void BtnNavigateToRN_Click(object sender, System.EventArgs e)
        {
            var reactIntent = new Intent(this, typeof(ReactActivity));
            Bundle reactActivityBundle = new Bundle();
            reactActivityBundle.PutString("ReactActivityArgumentString", reactMessage_EditText.Text);
            StartActivity(reactIntent, reactActivityBundle);
            OverridePendingTransition(Resource.Animation.Side_in_right, Resource.Animation.Side_out_left);
        }
    }
}

