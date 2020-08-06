using System;
using System.Net.Mail;

namespace Mailer
{
    public class Letter
    {
        public MailMessage MailMessage { get; }

        public Letter(string from, string to, bool isBodyHtml = false)
        {
            CheckArguments(from, to);
            MailMessage = new MailMessage(from, to) {Subject = string.Empty, Body = string.Empty, IsBodyHtml = isBodyHtml };
        }

        public Letter(string from, string to, string subject, string body, bool isBodyHtml = false)
        {
            CheckArguments(from, to);
            MailMessage = new MailMessage(from, to, subject, body) {IsBodyHtml = isBodyHtml };
        }

        public void AddAttachment(string attachmentPath)
        {
            MailMessage.Attachments.Add(new Attachment(attachmentPath));
        }

        private void CheckArguments(string from, string to)
        {
            if (from.IsNullOrEmptyOrWhiteSpace()) //можно еще добавить проверку по маске ...@...ru
                throw new ArgumentException("Неверно указан отправитель письма");
            if (to.IsNullOrEmptyOrWhiteSpace())
                throw new ArgumentException("Неверно указан получатель письма");
        }
    }
}
