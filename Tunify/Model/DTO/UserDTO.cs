﻿namespace Tunify.Model.DTO
{
    public class UserDTO
    {
        public string? Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}
