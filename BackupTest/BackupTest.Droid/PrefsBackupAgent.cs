using System;
using Android.App.Backup;
using Android.Preferences;
namespace backuptest
{
	public class PrefsBackupAgent : BackupAgentHelper
	{
		public override void OnCreate()
		{
			// Create a new subclass of BackupHelper meant for shared preferences
			var helper = new SharedPreferencesBackupHelper(this, ApplicationContext.PackageName + "_preferences");

			// Add that class so BackupAgentHelper knows to back it up (and restore it)!
			AddHelper("prefs", helper);

			base.OnCreate();
		}
	}
}
