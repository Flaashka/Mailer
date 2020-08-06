using Mailer;
using System;

namespace ConsoleSend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите любую клавишу для отправки письма");
            Console.ReadLine();

            try
            {
                var host = "";
                var port = 25;

                var box = new Mailbox(host, port);

                var from = "ben@contoso.com";
                var to = "tash@contoso.com";

                var letter = new Letter(from, to);

                box.Send(letter);
                Console.WriteLine("Письмо отправлено успешно");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
