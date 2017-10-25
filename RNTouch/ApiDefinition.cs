﻿using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace RNTouch
{
    [BaseType(typeof(UIView))]
    interface RCTRootView
    {
        [ExportAttribute("initWithBundleURL:moduleName:initialProperties:launchOptions:")]
        IntPtr Constructor(NSUrl bundleUrl, NSString moduleName, NSDictionary initialProperties, NSDictionary launchOptions);
    }
}
