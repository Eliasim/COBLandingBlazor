using MimeKit;

namespace COBLandingBlazor.Server.Utilities
{
    public class MailFactory
    {
        public bool MailSender(MimeMessage mimeMessage)
        {
            try
            {
                mimeMessage.From.Add(new MailboxAddress("Aplicativo COB", "prosis.ssandoval@gmail.com"));

                //Configuration
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("prosis.ssandoval@gmail.com", "gwrjquswyjpypaup");
                    var temp = client.Send(mimeMessage);
                    client.Disconnect(true);
                }

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}