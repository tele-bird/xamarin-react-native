using AndroidX.Fragment.App;
using Android.OS;
using Android.Views;

namespace SampleApp.Droid
{
    public class RecipesFragment : Fragment
    {
        private RecipesFragment()
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static RecipesFragment NewInstance()
        {
            var frag = new RecipesFragment { Arguments = new Bundle() };
            return frag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.recipes_fragment, null);
        }
    }
}
