using System;
using System.Threading.Tasks;
using Com.Facebook.React.Bridge;
using Java.Interop;

namespace SampleApp.Droid
{
    public class ReactNativeModule : ReactContextBaseJavaModule
    {
        public ReactNativeModule(Android.Content.Context context, ReactActivity reactActivity)
            : base(new ReactApplicationContext(context))
        {
            ReactActivity = reactActivity;
        }

        public override string Name => "XamarinModule";

        public ReactActivity ReactActivity { get; }

        [Export]
        [ReactMethod]
        public void InvokeMeSynchronous(string arg)
        {
            Console.WriteLine($"InvokeMeSynchronous: arg = [{arg}]");
            ReactActivity.Finish();
            ReactActivity.OverridePendingTransition(Resource.Animation.Side_in_left, Resource.Animation.Side_out_right);
        }

        [Export]
        [ReactMethod]
        public void InvokeMeAsynchronousWithCallback(string delay, string arg, ICallback errorCallback, ICallback successCallback)
        {
            Console.WriteLine($"InvokeMeAsynchronousWithCallback: delay = [{delay}], arg = [{arg}]");
            try
            {
                Task.Delay(Int32.Parse(delay)).Wait();
                successCallback.Invoke(delay, arg);
            }
            catch (Exception exc)
            {
                errorCallback.Invoke($"Caught a {exc.GetType().FullName}: {exc.Message}");
            }
        }

        [Export]
        [ReactMethod]
        public void InvokeMeAsynchronousWithPromise(string delay, string arg, IPromise promise)
        {
            Console.WriteLine($"InvokeMeAsynchronousWithPromise: delay = [{delay}], arg = [{arg}]");
            try
            {
                int delayInt = Int32.Parse(delay);
                Task.Delay(delayInt).Wait();
                IWritableMap result = Arguments.CreateMap();
                result.PutInt("delayInt", delayInt);
                result.PutString("argString", arg);
                promise.Resolve((Java.Lang.Object)result);
            }
            catch (Exception exc)
            {
                promise.Reject(new JSApplicationIllegalArgumentException($"Caught a {exc.GetType().FullName}: {exc.Message}"));
            }
        }
    }
}
