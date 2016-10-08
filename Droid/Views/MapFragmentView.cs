
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.Views.InputMethods;

namespace AndroidLearningDemo.Droid
{
	public class MapFragmentView : MvxFragment
	{
		private SupportMapFragment _mapFragment;
		private GoogleMap _map;
		private LocationManager _locMgr;
		private View _infoWindowContent;

		private LatLng _currentLocation;
		public LatLng CurrentLocation { 
			get { 
				return _currentLocation = _currentLocation ?? new LatLng (0.0, 0.0);
			}
			set { 
				_currentLocation = value;
			}
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = this.BindingInflate (Resource.Layout.MapFragment, null);
//			_locMgr = (LocationManager)this.Activity.GetSystemService (Android.Content.Context.LocationService);

			var fragmentTx = FragmentManager.BeginTransaction ();

			_mapFragment = new SupportMapFragment ();
//			_mapFragment.MapViewCreated += () => {
//				SetupMapIfNeeded();
//			};

			fragmentTx.Replace (Resource.Id.MyMapFragment, _mapFragment, "map");
			fragmentTx.AddToBackStack (null);
			fragmentTx.Commit ();

			return view;
		}

		public override void OnResume ()
		{
			base.OnResume ();

//			bool isGpsEnabled = _locMgr.IsProviderEnabled (Android.Locations.LocationManager.GpsProvider);
//			bool isWIFIEnabled = _locMgr.IsProviderEnabled (Android.Locations.LocationManager.NetworkProvider);
//
//			Location location = null;
//			if (isGpsEnabled) {
//				location = _locMgr.GetLastKnownLocation (Android.Locations.LocationManager.GpsProvider);
//			}
//			if (location == null && isWIFIEnabled) {
//				location = _locMgr.GetLastKnownLocation (Android.Locations.LocationManager.NetworkProvider);
//			}
//			if (location != null) {
//				CurrentLocation.Latitude = location.Latitude;
//				CurrentLocation.Longitude = location.Longitude;
//			} else {
//				System.Diagnostics.Debug.WriteLine ("Fail to locate.");
//			}
		}            

		public override void OnPause ()
		{
			base.OnPause ();
	
			//キーボードを閉じる
//			CloseKeyboard();
		}
		public override void OnDestroyView ()
		{
			base.OnDestroyView ();

//			if (_infoWindowContent != null) {
//				var parent = (ViewGroup)_infoWindowContent.Parent;
//				if (parent != null)
//					parent.RemoveView (_infoWindowContent);
//			}
		}

		private void SetupMapIfNeeded()
		{                        
			if (_mapFragment.Map != null) {
				_map = _mapFragment.Map;
			}
			if (_map == null)
				return;
			_map.MyLocationEnabled = true;
		    
			CameraPosition.Builder builder = CameraPosition.InvokeBuilder ();
			builder.Target (CurrentLocation);
			builder.Zoom (15);
			builder.Bearing (155);
			builder.Tilt (25);
			CameraPosition cameraPosition = builder.Build ();

			_map.MoveCamera(CameraUpdateFactory.NewCameraPosition(cameraPosition));
		}

		//キーボードを閉じる
		private void CloseKeyboard()
		{
			var im = (InputMethodManager)this.Activity.GetSystemService (Context.InputMethodService);
			var view = this.Activity.Window.PeekDecorView ();
			if (im != null && view != null) {
				im.HideSoftInputFromWindow (view.WindowToken, 0);
			}
		}
	}
}

