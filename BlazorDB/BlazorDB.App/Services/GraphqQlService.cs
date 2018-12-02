using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;
using GraphQL.Client.Http;
using GraphQL.Common.Request;
using GraphQL.Common.Response;

namespace BlazorDB.App.Services
{
	public class GraphqQlService
	{
		private static async Task<ICollection<T>> GetAll<T>(string query, string name) 
		{
			var req = new GraphQLRequest
			{
				Query = query
			};
			
			var client = new GraphQLHttpClient($"{Environment.GetEnvironmentVariable("ASPNETCORE_API_URL")}");
			var res = await client.SendQueryAsync(req);
			return res.GetDataFieldAs<ConnectionGraphQl<T>>(name).Nodes;
		}
		
		public static async Task<ICollection<Lecturer>> GetLecturersAsync()
		{
			const string query = 
				@"
				{
				  allLecturers {
					nodes {
					  lecturerName
					  surname
					  lecturerType
					  gender
					  birthYear
					  children
					  salary
					}
				  }
				}";

			return await GetAll<Lecturer>(query, "allLecturers");
		}
	}
}