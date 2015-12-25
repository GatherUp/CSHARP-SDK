using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GetFiveStars
{
	namespace Api
	{
		public class AuthToken
		{
			protected string clientId;
			protected string privateKey;

			public AuthToken (string clientId, string privateKey)
			{
				this.clientId = clientId;
				this.privateKey = privateKey;
			}

			public void signRequest (Request request)
			{
				request.Set ("clientId", this.clientId);

				var parameters = request.GetParameters ();
				var list = parameters.Keys.ToList ();
				list.Sort ();

				var hash = "";
				foreach (var key in list) {
					hash += key + parameters [key];
				}

				request.Set ("hash", sha256 (this.privateKey + hash));
			}

			private string sha256 (string text)
			{
				byte[] bytes = Encoding.UTF8.GetBytes (text);
				SHA256Managed hashstring = new SHA256Managed ();
				byte[] hash = hashstring.ComputeHash (bytes);
				string hashString = string.Empty;

				foreach (byte x in hash) {
					hashString += String.Format ("{0:x2}", x);
				}

				return hashString;
			}
		}
	}
}

