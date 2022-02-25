using System;
using Microsoft.AspNetCore.Identity;

namespace DrumSpace.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string ImagePath { get; set; }

        public int VerificationCode { get; set; }

        public DateTime VerificationCodeCreatedAt { get; set; }
    }
}