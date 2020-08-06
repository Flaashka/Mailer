using System;
using System.Net;
using System.Net.Mail;

namespace Mailer
{
    public class Mailbox
    {
        public string Host { get; }
        public int Port { get; }
        private readonly string _username;
        private readonly string _password;

        public Mailbox(string host, int port, string username = "", string password = "")
        {
            CheckArguments(host, port);
            Host = host;
            Port = port;
            _username = username;
            _password = password;
        }

        public void Send(Letter letter)
        {
            using (var smtpClient = new SmtpClient(Host, Port))
            {
                smtpClient.EnableSsl = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_username, _password);

                if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
                    smtpClient.UseDefaultCredentials = true;
                else
                    smtpClient.Credentials = new NetworkCredential(_username, _password);

                smtpClient.Send(letter.MailMessage);
            }
        }

        public async void SendAsync(Letter letter)
        {
            using (var smtpClient = new SmtpClient(Host, Port))
            {
                smtpClient.EnableSsl = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;

                if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
                    smtpClient.UseDefaultCredentials = true;
                else
                    smtpClient.Credentials = new NetworkCredential(_username, _password);

                await smtpClient.SendMailAsync(letter.MailMessage);
            }
        }

        private void CheckArguments(string host, int port)
        {
            if (host.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentException("Неверно указан хост");
            if (port < 0 || port > 65535)
                throw new ArgumentException("Неверно указан порт");
        }
    }
}
