using System;

namespace DemoClarivate.Core
{
	public static class RunSettingsHelper
	{
		public static string SiteUrl { get; set; }
		public static string SearchItemOnGoogle { get; set; }
        public static string SearchItemOnProQuest { get; set; }

        public static void ReadRunSettings(TestContext testContext)
		{
			SiteUrl = Convert.ToString(testContext.Properties["SiteUrl"]);
			SearchItemOnGoogle = Convert.ToString(testContext.Properties["SearchItemOnGoogle"]);
			SearchItemOnProQuest = Convert.ToString(testContext.Properties["SearchItemOnProQuest"]);
        }
	}
}

