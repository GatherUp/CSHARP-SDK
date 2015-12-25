using System;
using System.Collections.Generic;

namespace GetFiveStars
{
	namespace Api
	{
		public class Response
		{
			protected Dictionary<string, string> response;
			protected string errorMessage;
			protected int errorCode;

			public Response (Dictionary<string, string> response)
			{
				if (!response.ContainsKey ("errorCode") || !response.ContainsKey("errorMessage")) {
					response ["errorCode"] = "-1";
					response ["errorMessage"] = "Unknown error";
				}

				this.errorCode = Int32.Parse(response ["errorCode"]);
				this.errorMessage = response ["errorMessage"];

				response.Remove ("errorCode");
				response.Remove ("errorMessage");

				this.response = response;
			}

			public bool GetStatus() {
				return this.GetErrorCode () == 0;
			}

			public int GetErrorCode() {
				return this.errorCode;
			}

			public string GetErrorMessage() {
				return this.errorMessage;
			}

			public Dictionary<string, string> GetResponse() {
				return this.response;
			}
		}
	}
}



