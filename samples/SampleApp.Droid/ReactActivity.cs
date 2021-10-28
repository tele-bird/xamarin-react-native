﻿using Android.App;
using Android.OS;
using Com.Facebook.React;
using Com.Facebook.React.Shell;
using Com.Facebook.React.Common;
using Android.Views;
using Com.Facebook.React.Modules.Core;
using Android.Content;
using Android.Provider;
using AndroidX.AppCompat.App;

namespace SampleApp.Droid
{
    [Activity(Label = "XamarinReactNative", Icon = "@mipmap/icon", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class ReactActivity : AppCompatActivity, IDefaultHardwareBackBtnHandler
    {
        ReactRootView mReactRootView;

        ReactInstanceManager mReactInstanceManager;

        private const int OVERLAY_PERMISSION_REQ_CODE = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            #region overlay permission request
            //if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            //{
            //    if (!Settings.CanDrawOverlays(this))
            //    {
            //        Intent intent = new Intent(Settings.ActionManageOverlayPermission, Uri.Parse("package:" + PackageName));
            //        StartActivityForResult(intent, OVERLAY_PERMISSION_REQ_CODE);
            //    }
            //}
            #endregion

            mReactRootView = new ReactRootView(this);
            mReactInstanceManager = ReactInstanceManager.Builder()
                    .SetApplication(Application)
                    .SetBundleAssetName("index.android.bundle")
                    .SetJSMainModulePath("index")
                    .AddPackage(new MainReactPackage())
                    .AddPackage(new ReactNativeModulePackage(this))
#if DEBUG
                    .SetUseDeveloperSupport(true)
#else
                    .SetUseDeveloperSupport(false)
#endif
                    .SetInitialLifecycleState(LifecycleState.Resumed)
                    .Build();

            mReactRootView.StartReactApplication(mReactInstanceManager, "RNOldVersion", savedInstanceState);

            SetContentView(mReactRootView);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Finish();
            OverridePendingTransition(Resource.Animation.Side_in_left, Resource.Animation.Side_out_right);
            return true;
        }


        public override void OnBackPressed()
        {
            this.Finish();
            OverridePendingTransition(Resource.Animation.Side_in_left, Resource.Animation.Side_out_right);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == OVERLAY_PERMISSION_REQ_CODE)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                {
                    if (!Settings.CanDrawOverlays(this))
                    {
                        // SYSTEM_ALERT_WINDOW permission not granted...
                    }
                }
            }
        }

        protected override void OnPause()
        {
            base.OnPause();

            if (mReactInstanceManager != null)
            {
                mReactInstanceManager.OnHostPause(this);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (mReactInstanceManager != null)
            {
                mReactInstanceManager.OnHostResume(this, this);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (mReactInstanceManager != null)
            {
                mReactInstanceManager.OnHostDestroy(this);
            }
        }

        //public override void OnBackPressed()
        //{
        //    if (mReactInstanceManager != null)
        //    {
        //        mReactInstanceManager.OnBackPressed();
        //    }
        //    else
        //    {
        //        base.OnBackPressed();
        //    }
        //}

        public void InvokeDefaultOnBackPressed()
        {
            base.OnBackPressed();
        }

        public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Menu && mReactInstanceManager != null)
            {
                mReactInstanceManager.ShowDevOptionsDialog();
                return true;
            }

            return base.OnKeyUp(keyCode, e);
        }
    }
}

