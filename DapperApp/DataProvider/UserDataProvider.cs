using Dapper;
using DapperApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.DataProvider
{
	public class UserDataProvider : IUserDataProvider
	{
		private readonly string connectionstring = "Server=INGUEUCLP000778;Database=RaviDb;Trusted_Connection=True";
		private SqlConnection sqlConnection;
		//ADD USER
		public async Task AddUser(User user)
		{

			using (var sqlConnection = new SqlConnection(connectionstring))
			{
				await sqlConnection.OpenAsync();
				var parameters = new DynamicParameters();
				parameters.Add("@Name", user.Name);
				parameters.Add("@EmailId", user.EmailId);
				parameters.Add("@Mobile", user.Mobile);
				parameters.Add("@Address", user.Address);
				await sqlConnection.ExecuteAsync("SaveUser", parameters, commandType: CommandType.StoredProcedure);
				//var useid = new SqlParameter("@UserId", user.UserId);
				//var username = new SqlParameter("@UserName", user.UserName);
				//var email = new SqlParameter("@Email", user.Email);
				//var password = new SqlParameter("@Password", user.Password);
				//_logincontext.User.FromSql("spAddUser").ToArrayAsync();

			}

		}
		//DELETE USER
		public async Task DeleteUser(int UserId)
		{
			using (var sqlConnection = new SqlConnection(connectionstring))
			{
				await sqlConnection.OpenAsync();
				var parameters = new DynamicParameters();
				parameters.Add("@UserId", UserId);
				await sqlConnection.ExecuteAsync("DeleteUser", parameters, commandType: CommandType.StoredProcedure);
			}

		}

		//GET USER BY ID
		public async Task<User> GetUser(int UserId)
		{
			using (var sqlConnection = new SqlConnection(connectionstring))
			{
				await sqlConnection.OpenAsync();
				var parameters = new DynamicParameters();
				parameters.Add("@UserId", UserId);
				return await sqlConnection.QuerySingleOrDefaultAsync<User>("spGetUser",
					parameters,
					commandType: CommandType.StoredProcedure);

			}
		}

		//GET ALL USERS
		public async Task<IEnumerable<User>> GetUsers()
		{
			using (var sqlConnection = new SqlConnection(connectionstring))
			{
				await sqlConnection.OpenAsync();
				return await sqlConnection.QueryAsync<User>(
					"GetUsers",
					null,
					commandType: CommandType.StoredProcedure);
				//return await _logincontext.User.FromSql("spGetUsers").ToArrayAsync();

			}
		}

		//UPDATE USER
		public async Task UpdateUser(User user)
		{
			using (var sqlConnection = new SqlConnection(connectionstring))
			{
				await sqlConnection.OpenAsync();
				var parameters = new DynamicParameters();
				parameters.Add("@UserId", user.UserId);
				parameters.Add("@Name", user.Name);
				parameters.Add("@EmailId", user.EmailId);
				parameters.Add("@Mobile", user.Mobile);
				parameters.Add("@Address", user.Address);

				await sqlConnection.ExecuteAsync(
					"SaveUser",
					parameters,
					commandType: CommandType.StoredProcedure);
			}
		}



	}

}

