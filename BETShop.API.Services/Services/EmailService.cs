
using BETShop.API.Infrastructure.Logging;
using BETShop.API.Services.Abstract;
using BETShop.API.Utilities.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETShopAPI.Services
{
		public class EmailService : IEmailService
		{
				private readonly AppSettings _settings;
        private readonly ILoggerManager _logger;
        public EmailService(IOptions<AppSettings> settings, ILoggerManager logger)
				{
						_settings = settings.Value;
            _logger = logger;
				}
				public async Task<bool> SendEmailAsync(string email, string subject, string message)
				{
                var mimeMessage = new MimeMessage();

                mimeMessage.From.Add(new MailboxAddress(_settings.EmailSettings.SenderName, _settings.EmailSettings.Sender));

                mimeMessage.To.Add(MailboxAddress.Parse(email));

                mimeMessage.Subject = subject;

                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    // we would need to filter the accepted certificates for production 
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync(_settings.EmailSettings.MailServer, _settings.EmailSettings.MailPort, true);
                    await client.AuthenticateAsync(_settings.EmailSettings.Sender, _settings.EmailSettings.Password);
                    await client.SendAsync(mimeMessage);
                    await client.DisconnectAsync(true);
                }
                return true;
        }
		}
}
