using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class PlanService : BaseGraphQlService<Plan>, IPlanService
	{
		public async Task<ICollection<Plan>> GetAsync()
		{
			const string query = 
				@"
				{
				  allPlans {
					nodes {
					  disciplineId
					  lecturerId
					  hourCount
					  id
					  occupationType
					  formControl
					  dateStart
					  dateEnd
					  discipline: disciplineByDisciplineId {
						id
						disciplineName
					  }
					  lecturer: lecturerByLecturerId {
						surname
						id
					  }
					}
				  }
				}
				";

			return await GetAll(query, "allPlans");
		}
		
		public async Task<Plan> GetAsync(int id)
		{
			const string query = 
				@"
				query GetPlanById($id: Int!) {
				  planById(id: $id) {
					  disciplineId
					  lecturerId
					  hourCount
					  id
					  occupationType
					  formControl
					  dateStart
					  dateEnd
					  discipline: disciplineByDisciplineId {
						id
						disciplineName
					  }
					  lecturer: lecturerByLecturerId {
						surname
						id
					  }
				  }
				}
				";

			return await GetOne(query, "planById", id);
		}
		
		public async Task<Plan> UpdateAsync(Plan plan)
		{
			const string query = 
				@"
				mutation UpdatePlan($input: UpdatePlanByIdInput!) {
				  updatePlanById(input: $input) {
					plan {
					  disciplineId
					  lecturerId
					  hourCount
					  id
					  occupationType
					  formControl
					  dateStart
					  dateEnd
					  discipline: disciplineByDisciplineId {
						id
						disciplineName
					  }
					  lecturer: lecturerByLecturerId {
						surname
						id
					  }
					}
				  }
				}
				";

			return await Mutate(query, "updatePlanById.plan", new
			{
				input = new {
					id = plan.Id,
					planPatch = new {
						disciplineId = plan.DisciplineId,
						lecturerId = plan.LecturerId,
						hourCount = plan.HourCount,
						occupationType = plan.OccupationType,
						formControl = plan.FormControl,
						dateStart = plan.DateStart,
						dateEnd = plan.DateEnd
					}
				}
			});
		}
		
		public async Task<Plan> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeletePlan($input: DeletePlanByIdInput!) {
				  deletePlanById(input: $input) {
					plan {
					  disciplineId
					  lecturerId
					  hourCount
					  id
					  occupationType
					  formControl
					  dateStart
					  dateEnd
					  discipline: disciplineByDisciplineId {
						id
						disciplineName
					  }
					  lecturer: lecturerByLecturerId {
						surname
						id
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deletePlanById.plan", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<Plan> AddAsync(Plan plan)
		{
			const string query = 
				@"
				mutation AddPlan($input: CreatePlanInput!) {
				  createPlan(input: $input) {
					plan {
					  disciplineId
					  lecturerId
					  hourCount
					  id
					  occupationType
					  formControl
					  dateStart
					  dateEnd
					  discipline: disciplineByDisciplineId {
						id
						disciplineName
					  }
					  lecturer: lecturerByLecturerId {
						surname
						id
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createPlan.plan", new
			{
				input = new {
					plan = new {
						disciplineId = plan.DisciplineId,
						lecturerId = plan.LecturerId,
						hourCount = plan.HourCount,
						occupationType = plan.OccupationType,
						formControl = plan.FormControl,
						dateStart = plan.DateStart,
						dateEnd = plan.DateEnd
					}
				}
			});
		}
	}
}