
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;

namespace AndroidLearningDemo.Droid
{          
    public class CustomSupportMapFragment : SupportMapFragment
    {
        public Action MapViewCreated;
            
        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            View view = base.OnCreateView(inflater, container, savedInstanceState);
            // Notify the view has been created
            if( MapViewCreated != null ) {
                MapViewCreated ();
            }
            return view;
        }
    }
}

