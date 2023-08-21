using BusinessLayer.Abstract;
using System.Net;
using System.Net.Mail;

namespace BusinessLayer.Concrete
{
    public class EmailSender : IEmailSender
    {
        private string _host;
        private string _port;
        private string _enableSSl;
        private string _username;
        private string _password;

        public EmailSender(string host, string port, string enableSSl, string username, string password)
        {
            _host = host;
            _port = port;
            _enableSSl = enableSSl;
            _username = username;
            _password = password;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_host, int.Parse(_port))
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = bool.Parse(_enableSSl)
            };
            return client.SendMailAsync(new MailMessage(_username, email, subject, htmlMessage)
            {
                IsBodyHtml = true
            });
        }
    }
}
