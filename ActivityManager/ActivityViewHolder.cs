using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace ActivityManager
{
    class ActivityViewHolder : RecyclerView.ViewHolder
    {
        private TextView activityDescription;
        private TextView activityMisc;
        private ActivityItem activity;

        public ActivityViewHolder(View itemView) : base(itemView)
        {
            activityDescription = itemView.FindViewById<TextView>(Resource.Id.activityDescription);
            activityMisc = itemView.FindViewById<TextView>(Resource.Id.activityMisc);
        }

        public void SetActivityItem(ActivityItem activityItem)
        {
            activity = activityItem;
            activityDescription.Text = activity.EventDescription;
            activityMisc.Text = $"{activity.PersonName} - {activity.Date.toShortString()} {activity.activityLenght} minutes";
        }
    }
}