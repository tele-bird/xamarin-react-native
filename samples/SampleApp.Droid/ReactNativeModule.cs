using System;
using System.Threading.Tasks;
using Com.Facebook.React.Bridge;
using Java.Interop;

namespace SampleApp.Droid
{
    public class ReactNativeModule : ReactContextBaseJavaModule
    {
        public ReactNativeModule(Android.Content.Context context)
            : base(new ReactApplicationContext(context))
        {
        }

        public override string Name => "XamarinModule";

        [Export]
        [ReactMethod]
        public void InvokeMeSynchronous(string arg)
        {
            Console.WriteLine($"InvokeMeSynchronous: arg = [{arg}]");
        }

        [Export]
        [ReactMethod]
        public void InvokeMeAsynchronousWithCallback(string delay, string arg, ICallback errorCallback, ICallback successCallback)
        {
            Console.WriteLine($"InvokeMeAsynchronousWithCallback: delay = [{delay}], arg = [{arg}]");
            try
            {
                Task.Delay(Int32.Parse(delay)).Wait();
                successCallback.Invoke($"InvokeMeAsynchronousWithCallback: delay = [{delay}], arg = [{arg}]");
            }
            catch (Exception exc)
            {
                errorCallback.Invoke($"InvokeMeAsynchronousWithCallback caught an {exc.GetType().Name} with Message: {exc.Message}");
            }
        }

        [Export]
        [ReactMethod]
        public void InvokeMeAsynchronousWithPromise(string delay, string arg, IPromise promise)
        {
            Console.WriteLine($"InvokeMeAsynchronousWithPromise: delay = [{delay}], arg = [{arg}]");
            try
            {
                Task.Delay(Int32.Parse(delay)).Wait();
                promise.Resolve($"InvokeMeAsynchronousWithPromise: delay = [{delay}], arg = [{arg}]");
            }
            catch (Exception exc)
            {
                promise.Reject($"InvokeMeAsynchronousWithPromise caught an {exc.GetType().Name}", exc.Message);
            }
        }
    }
}
