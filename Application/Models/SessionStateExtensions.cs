using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SLICKIce.Application.Controllers {
	// ISession extensions used to get and set session properties
	// from: ASP.NET Core Docs: Session and Application State
	// source: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?tabs=aspnetcore2x#working-with-session-state
	public static class SessionExtensions {
		public static void Set<T>(this ISession session, string key, T value) {
			session.SetString(key, JsonConvert.SerializeObject(value));
		}

		public static T Get<T>(this ISession session, string key) {
			var value = session.GetString(key);

			if (value == null) return default(T);
			else return JsonConvert.DeserializeObject<T>(value);
		}
	}
}