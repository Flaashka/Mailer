# Mailer
Простая самописная библиотека для отправки писем

Пример использования:  
var host = "127.0.0.1";  
var port = 35;  
var box = new Mailbox(host, port);  

var from = "ben@contoso.com";  
var to = "tash@contoso.com";  
var subject = "Some subject";  
var body = "Some information";  
var letter = new Letter(from, to, subject, body);  

box.Send(letter);
