using System;
using System.Collections.Generic;
using Com.Facebook.React;
using Com.Facebook.React.Bridge;
using Com.Facebook.React.Uimanager;
using Java.Interop;
using SampleApp.Common;

namespace SampleApp.Droid
{
    public class ReactNativeModulePackage : Java.Lang.Object, IReactPackage
    {
        public ReactNativeModulePackage(ReactActivity reactActivity)
        {
            ReactActivity = reactActivity;
        }

        public ReactActivity ReactActivity { get; }

        public IList<INativeModule> CreateNativeModules(ReactApplicationContext context)
        {
            return new List<INativeModule> { new ReactNativeModule(context, ReactActivity) };
        }

        public IList<ViewManager> CreateViewManagers(ReactApplicationContext context)
        {
            return new List<ViewManager> { };
        }
    }
}
