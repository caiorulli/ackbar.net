﻿namespace Ackbar.Api.Dto
{
    public class SignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string[] Reports { get; set; }
    }
}