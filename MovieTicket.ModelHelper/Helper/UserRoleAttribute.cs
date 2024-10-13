using MovieTicket.ModelHelper.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieTicket.ModelHelper.Helper
{
    public class UserRoleAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var role = value.ToString();
            return role.Equals(Roles.Admin) || role.ToLower().Equals(Roles.User);
        }
    }
}
