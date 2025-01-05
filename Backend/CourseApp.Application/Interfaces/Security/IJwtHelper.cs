using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Interfaces.Security
{
    public interface IJwtHelper
    {
        string GenerateToken(string userId,string email, string role);
    }
}
