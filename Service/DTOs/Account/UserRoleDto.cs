﻿using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Account
{
    public class UserRoleDto
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
