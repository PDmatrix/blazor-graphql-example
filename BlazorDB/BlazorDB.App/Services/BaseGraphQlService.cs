using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;
using GraphQL.Client.Http;
using GraphQL.Common.Request;

namespace BlazorDB.App.Services
{
	public abstract class BaseGraphQlService<T>
	{
		public abstract Task<ICollection<T>> GetAsync();
		public abstract Task<T> GetAsync(int id);
		public abstract Task<T> UpdateAsync(T update);
		public abstract Task<T> DeleteAsync(int id);
		public abstract Task<T> AddAsync(T add);
		
		protected static async Task<ICollection<T>> GetAll(string query, string name) 
		{
			var req = new GraphQLRequest
			{
				Query = query
			};
			
			var client = new GraphQLHttpClient($"{Environment.GetEnvironmentVariable("ASPNETCORE_API_URL")}");
			var res = await client.SendQueryAsync(req);
			return res.GetDataFieldAs<ConnectionGraphQl<T>>(name).Nodes;
		}
		
		protected static async Task<T> GetOne(string query, string name, int id) 
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
		
		protected static async Task<T> Mutate(string query, string name, object variables) 
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