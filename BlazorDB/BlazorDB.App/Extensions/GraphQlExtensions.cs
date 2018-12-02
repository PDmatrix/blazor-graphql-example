using System;
using System.Linq;
using GraphQL.Common.Response;
using Newtonsoft.Json.Linq;

namespace BlazorDB.App.Extensions
{
	public static class GraphQlExtensions
	{
		public static T ExtGetDataFieldAs<T>(this GraphQLResponse response, string value)
		{
			var values = value.Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries);
			object data = response.Data as JObject;
			data = values.Aggregate(data, (current, val) => (current as JObject)?.GetValue(val));
			return
				data is JObject o ? o.ToObject<T>() 
					: throw new NullReferenceException();
		}
	}
}