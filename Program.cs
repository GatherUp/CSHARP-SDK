using System;
using System.Collections.Generic;
using GetFiveStars.Api;

namespace DotNetSdk
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Request request = new JsonRequest ("/test", "{'test1':'test2','test3':'test4'}");
			AuthToken token = new AuthToken ("1221414", "2134215325325");

			token.signRequest (request);

			WebRequestClient wrc = new WebRequestClient (request);
			Response response = wrc.SendRequest ();

			if (response.GetStatus ()) {
				foreach(var item in response.GetResponse())
				{
					Console.WriteLine (item.Key + " " + item.Value);
				}
			} else {
				System.Console.WriteLine (response.GetErrorCode () + " " + response.GetErrorMessage ());
			}
		}
	}
}
