using System.Collections.Generic;

namespace GetFiveStars
{
	namespace Api
	{
		public class Request
		{
			protected string action;
			protected Dictionary<string, string> request;

			public Request (string action, Dictionary<string, string> request)
			{
				this.action = action;
				this.request = request;
			}

			public void Set(string key, string value) {
				this.request [key] = value;
			}

			public string Get(string key) {
				if (this.request.ContainsKey (key)) {
					return this.request [key];
				}
				return "";
			}

			public Dictionary<string, string> GetParameters() {
				return this.request;
			}

			public string GetAction() {
				return this.action;
			}
		}
	}
}



