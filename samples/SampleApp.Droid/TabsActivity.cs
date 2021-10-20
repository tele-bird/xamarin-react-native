using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;

namespace SampleApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class TabsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.tabs_activity);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.ItemSelected += Navigation_ItemSelected;

            LoadFragment(Resource.Id.navigation_home);
        }

        private void Navigation_ItemSelected(object sender, Google.Android.Material.Navigation.NavigationBarView.ItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        private void LoadFragment(int id)
        {
            AndroidX.Fragment.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.navigation_home:
                    fragment = HomeFragment.NewInstance();
                    break;
                case Resource.Id.navigation_recipes:
                    fragment = RecipesFragment.NewInstance();
                    break;
                case Resource.Id.navigation_account:
                    fragment = AccountFragment.NewInstance();
                    break;
            }
            if (null != fragment)
            {
                SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.content_frame, fragment)
                    .Commit();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

