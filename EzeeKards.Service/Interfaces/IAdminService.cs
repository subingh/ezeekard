using EzeeKards.Service.Models.Users;
using LogBook.Common.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Service.Interfaces
{
    public interface IAdminService
    {
        string LogIn(LoginRequest request);
    }
}
