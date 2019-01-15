using System;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace ActivityManager.Activities
{
    [Activity(Label = "Material Design", Theme = "@style/MyTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.main);

            var activityList = FindViewById<ListView>(Resource.Id.activityList);

            var activityService = new ActivityService();
            var activities = activityService.FetchActivityList();
            activityList.Adapter = new ActivityAdapter(activities, this);

            activityList.Touch += ListItemTouch;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetStatusBarColor(new Android.Graphics.Color(ContextCompat.GetColor(Application, Resource.Color.primary_dark)));
            }

            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab_add);
            fab.Click += Fab_Click;

            fab.Visibility = ViewStates.Invisible;

        }

        void ListItemTouch(object sender, View.TouchEventArgs e)
        {
            var currentNightMode = (int)Resources.Configuration.UiMode & (int)UiMode.NightYes;

            if (currentNightMode == (int)UiMode.NightNo)
            {
                Delegate.SetLocalNightMode(AppCompatDelegate.ModeNightYes);
            }
            else
            {
                Delegate.SetLocalNightMode(AppCompatDelegate.ModeNightNo);
            }
            Recreate();
        }

        void Fab_Click(object senser, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddActivity));

            StartActivity(intent, null);
        }

        private void AnimateShow(View view)
        {
            var anim = new ScaleAnimation(0, 1, 0, 1, .5f, .5f);
            anim.FillBefore = true;
            anim.FillAfter = true;
            anim.FillEnabled = true;
            anim.Duration = 300;
            anim.StartOffset = 500;

            anim.Interpolator = new OvershootInterpolator();
            view.StartAnimation(anim);
        }

        protected override void OnResume()
        {
            base.OnRestart();
            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab_add);
            if (fab.Visibility == ViewStates.Invisible)
            {
                AnimateShow(fab);
            }
        }
    }
}

