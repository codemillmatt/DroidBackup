using Android.App;
using Android.Widget;
using Android.OS;

namespace BackupTest.Droid
{
	[Activity(Label = "BackupTest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += delegate {
				var sp = this.ApplicationContext.GetSharedPreferences("test", Android.Content.FileCreationMode.Private);
				var currentCount = sp.GetInt("clicked", 0);
				currentCount += 1;

				var edit = sp.Edit();
				edit.PutInt("clicked", currentCount);
				edit.Apply();

				button.Text = $"The current count is: {currentCount}";
			};

			var resetBtn = FindViewById<Button>(Resource.Id.resetPrefs);
			resetBtn.Click += (sender, e) =>
			{
				var sp = ApplicationContext.GetSharedPreferences("test", Android.Content.FileCreationMode.Private);
				var edit = sp.Edit();
				edit.PutInt("clicked", 0);
				edit.Apply();

				var currentCount = sp.GetInt("clicked", 0);
				button.Text = $"The current count is: {currentCount}";
			};
		}
	}
}

