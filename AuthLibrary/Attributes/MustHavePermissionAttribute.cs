using AuthLibrary.Constants.Authentication;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Attributes
{
    //hhhhhh//ahdgdf
    public class MustHavePermissionAttribute : AuthorizeAttribute
    {
        public MustHavePermissionAttribute(string service, string feature, string action)
        {
            Policy = AppPermission.NameFor(service,feature,action);
        }
    }
}
