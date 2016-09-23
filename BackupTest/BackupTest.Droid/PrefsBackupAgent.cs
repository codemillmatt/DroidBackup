using System;
using Android.App.Backup;
namespace backuptest
{
	public class PrefsBackupAgent : BackupAgentHelper
	{
		public override void OnCreate()
		{
			var helper = new SharedPreferencesBackupHelper(this, "test");

			AddHelper("prefs", helper);

			base.OnCreate();
		}
	}
}
