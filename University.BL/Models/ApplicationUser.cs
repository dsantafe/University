using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace University.BL.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Cookie Authentication Options
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
