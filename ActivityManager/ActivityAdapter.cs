using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace ActivityManager
{
    class ActivityAdapter : RecyclerView.Adapter
    {
        private List<ActivityItem> activityList;

        public ActivityAdapter(List<ActivityItem> activityList)
        {
            this.activityList = activityList;
        }

        public override int ItemCount
        {
            get
            {
                return activityList.Count;
            }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = (ActivityViewHolder)holder;

            vh.SetActivityItem(activityList[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.activity_item, parent, false);

            var vh = new ActivityViewHolder(itemView);

            return vh;
        }
    }
}