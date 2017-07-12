using Android.App;
using Android.Widget;
using Android.OS;

namespace CustomCircularProgressBarBar
{
    [Activity(Label = "CustomCircularProgressBarBar", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        private CircularProgressBar circularProgressBar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            circularProgressBar = FindViewById<CircularProgressBar>(Resource.Id.circularProgressBar);
            var increaseBtn = FindViewById<Button>(Resource.Id.increaseBtn);
            var decreaseBtn = FindViewById<Button>(Resource.Id.decreaseBtn);

            increaseBtn.Click += delegate
            {
                circularProgressBar.Progress += 10;
            };

            decreaseBtn.Click += delegate
            {
                circularProgressBar.Progress -= 10;
            };
        }
    }
}

