using System.Collections.Generic;
using System.Configuration;
using Xamarin.UITest;

namespace AutomationFramework
{
    public class TestBase
    {
		protected static string deviceIdentifiers;
		protected static string bundleId = ConfigurationManager.AppSettings["bundleId"];

		/// <summary>
		/// Sets up the App on the appropriate device
		/// </summary>
		/// <param name="deviceIdentifier">The Device Identifier to install the app</param>
		public void Setup(string deviceIdentifier)
		{
			App.app = ConfigureApp
				.iOS
				.DeviceIdentifier(deviceIdentifier)
				.InstalledApp(bundleId)
				.StartApp();
		}

		/// <summary>
		/// Gets each Device Identifier from the App.config
		/// </summary>
		/// <returns>Each Device Identifier from the App.config</returns>
		public static IEnumerable<string> GetDevices()
		{
			// Get BaseUrl from App.config
			if (deviceIdentifiers == null)
			{
				deviceIdentifiers = ConfigurationManager.AppSettings["deviceIdentifiers"];
			}
			// Split the list of devices
			string[] deviceIdentifiersArray = deviceIdentifiers.Split(',');
			// Return each browser
			foreach (string deviceSerial in deviceIdentifiersArray)
			{
				yield return deviceSerial;
			}
		}
    }
}
