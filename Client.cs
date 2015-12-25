namespace GetFiveStars
{
	namespace Api
	{
		public abstract class Client
		{
			public const string URL = "https://getfivestars.com/api";

			protected Request request;

			public Client (Request request)
			{
				this.request = request;
			}

			public abstract Response SendRequest();
		}
	}
}

