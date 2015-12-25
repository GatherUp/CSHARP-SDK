using System.IO;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetFiveStars
{
	namespace Api
	{
		public class WebRequestClient : Client
		{
			public WebRequestClient (Request request) : base(request)
			{
			}

			// http://stackoverflow.com/questions/9145667/how-to-post-json-to-the-server#answer-16380064
			public override Response SendRequest ()
			{
				Dictionary<string, string> response = new Dictionary<string, string> ();

				try {
					var httpWebRequest = (HttpWebRequest)WebRequest.Create (Client.URL + request.GetAction ());
					httpWebRequest.ContentType = "text/json";
					httpWebRequest.Method = "POST";

					using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
						string json = JsonConvert.SerializeObject(this.request.GetParameters(), Formatting.Indented);

						streamWriter.Write (json);
						streamWriter.Flush ();
						streamWriter.Close ();
					}
					var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse ();
					using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
						var result = streamReader.ReadToEnd ();
						response = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
					}
				} catch {
				}

				return new Response (response);
			}
		}
	}
}