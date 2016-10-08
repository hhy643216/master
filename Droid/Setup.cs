using Android.Content;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;

namespace AndroidLearningDemo.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
			return new App ();
        }

		protected override void InitializeLastChance ()
		{
			base.InitializeLastChance ();

			Mvx.RegisterSingleton<IErrorHandler> (new ErrorHandler ());
		}

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}