using AndroidX.Fragment.App;
using Android.OS;
using Android.Views;

namespace SampleApp.Droid
{
    public class HomeFragment : Fragment
    {
        private HomeFragment()
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static HomeFragment NewInstance()
        {
            var frag = new HomeFragment { Arguments = new Bundle() };
            return frag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.home_fragment, null);
        }
    }
}
