using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.UserManagement.Api.Models
{
	public class TokenDetails
	{
		public string Token { get; set; }
		public string UserName { get; set; }
		public bool IsAdminUser { get; set; }

	}
}
