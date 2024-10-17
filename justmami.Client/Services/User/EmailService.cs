using System.Net;
using System.Net.Mail;

namespace justmami.Client.Services.User;

public class EmailService
{
    private MailAddress _senderAdress { get; set; }

    public EmailService()
    {
        //example adress
        _senderAdress = new MailAddress("justmamai@gmail.com");
    }

    public int SendEmail(string receiver, string subject, string body)
    {
        MailAddress receiveraddr = new MailAddress(receiver);

        MailMessage email = new MailMessage(_senderAdress, receiveraddr);

        email.Subject = subject;
        email.Body = body;

        using(var client = new SmtpClient("serveradress", 25))
        {
            client.Credentials = new NetworkCredential("username", "password");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        return 0;
    }
}
