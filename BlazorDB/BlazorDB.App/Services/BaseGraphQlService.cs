using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Extensions;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using GraphQL.Client.Http;
using GraphQL.Common.Request;

namespace BlazorDB.App.Services
{
	public abstract class BaseGraphQlService<T> : IBaseGraphQlService<T>
	{
		public async Task<ICollection<T>> GetAll(string query, string name) 
		{
			var req = new GraphQLRequest
			{
				Query = query
			};
			
			var client = new GraphQLHttpClient($"{Environment.GetEnvironmentVariable("ASPNETCORE_API_URL")}");
			var res = await client.SendQueryAsync(req);
			
			return res.GetDataFieldAs<ConnectionGraphQl<T>>(name).Nodes;
		}
		
		public async Task<T> GetOne(string query, string name, int id) 
		{
			var req = new GraphQLRequest
			{
				Query = query,
				Variables = new { id }
			};
			
			var client = new GraphQLHttpClient($"{Environment.GetEnvironmentVariable("ASPNETCORE_API_URL")}");
			var res = await client.SendQueryAsync(req);
			return res.ExtGetDataFieldAs<T>(name);
		}
		
		public async Task<T> Mutate(string query, string name, object variables) 
		{
			var req = new GraphQLRequest
			{
				Query = query,
				Variables = variables
			};
			
			var client = new GraphQLHttpClient($"{Environment.GetEnvironmentVariable("ASPNETCORE_API_URL")}");
			var res = await client.SendQueryAsync(req);
			return res.ExtGetDataFieldAs<T>(name);
		}
	}
}