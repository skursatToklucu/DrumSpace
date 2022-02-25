using System.Collections.Generic;
using DrumSpace.Application.Roles.Queries.Dtos;

namespace DrumSpace.Application.Users.Queries.Dtos
{
    public class UserWithRoleDto 
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public List<RoleDto> Roles { get; set; }
    }
}