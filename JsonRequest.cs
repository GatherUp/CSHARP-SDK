using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetFiveStars
{
	namespace Api
	{
		public class JsonRequest : Request
		{

			public JsonRequest (string action, string json) : base(action, new Dictionary<string, string>())
			{
				var parameters = JsonConvert.DeserializeObject<Dictionary<string, string>> (json);
				foreach (var item in parameters) {
					this.Set (item.Key, item.Value);
				}
			}
		}
	}
}



