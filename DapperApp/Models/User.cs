using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApp.Models
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
        public string Name { get; set; }
		public string EmailId { get; set; }
		public string Mobile	{get; set;}
		public string Address { get; set;}

		public bool IsActive { get; set; }
	}
}
