using System;
using System.Collections.Generic;
using GetFiveStars.Api;

namespace DotNetSdk
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string> ();
			Request request = new Request ("/test", parameters);
			WebRequestClient wrc = new WebRequestClient (request);
			Response response = wrc.SendRequest ();

			if (response.GetStatus ()) {

			} else {
				System.Console.WriteLine (response.GetErrorCode () + " " + response.GetErrorMessage ());
			}
		}
	}
}
