using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using COBLandingBlazor.Client.Pages;
using COBLandingBlazor.Server.Utilities;
using COBLandingBlazor.Server.Model;

namespace COBLandingBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly MailFactory _mailFactory;

        public MailController(MailFactory mailFactory)
        {
            _mailFactory = mailFactory;
        }

        [HttpPost]
        public async Task<ActionResult<EmailBody>> PostMail(EmailBody emailBody)
        {
            try
            {
                MimeMessage mimeMessage = new();
                mimeMessage.To.Add(new MailboxAddress(emailBody.Name, "prosis.emendoza@gmail.com"));

                mimeMessage.Subject = "ProsisByte";

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = $"Nombre: {emailBody.Name} \nCorreo: {emailBody.Email} \nTeléfono: {emailBody.Phone} \nEmpresa: {emailBody.Company} \nMensaje: {emailBody.Text} \nDemostración: {emailBody.Demo}";

                mimeMessage.Body = bodyBuilder.ToMessageBody();
                _mailFactory.MailSender(mimeMessage);

                return Ok(emailBody);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}