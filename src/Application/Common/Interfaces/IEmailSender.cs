﻿using System.Threading.Tasks;

namespace DrumSpace.Application.Common.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}