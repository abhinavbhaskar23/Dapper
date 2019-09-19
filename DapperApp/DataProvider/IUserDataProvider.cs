using DapperApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.DataProvider
{
	public interface IUserDataProvider
	{
		Task<IEnumerable<User>> GetUsers();

		Task<User> GetUser(int UserID);

		Task AddUser(User user);

		Task UpdateUser(User user);

		Task DeleteUser(int UserID);
	}
}
