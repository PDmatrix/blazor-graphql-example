using System;
using System.Linq;
using GraphQL.Common.Response;
using Newtonsoft.Json.Linq;

namespace BlazorDB.App.Services
{
	public static class ExtClass
	{
		public static T ExtGetDataFieldAs<T>(this GraphQLResponse response, string value)
		{
			var vals = value.Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries);
			object data = response.Data as JObject;
			data = vals.Aggregate(data, (current, val) => (current as JObject)?.GetValue(val));
			return 
				data is JObject o ? o.ToObject<T>() 
				: throw new NullReferenceException();
		}
	}
}