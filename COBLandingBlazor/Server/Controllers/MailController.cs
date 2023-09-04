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
                MimeMessage mimeMessageAutoReplay = new();
                mimeMessage.To.Add(new MailboxAddress(emailBody.Name, "info@cob123.com"));
                mimeMessageAutoReplay.To.Add(new MailboxAddress(emailBody.Name, emailBody.Email));

                mimeMessage.Subject = "Nuevo Cliente";
                mimeMessageAutoReplay.Subject = "Solicitud Recibida";

                var bodyBuilder = new BodyBuilder();
                var bodyBuilderAutoReplay = new BodyBuilder();

                bodyBuilder.TextBody = $"Nombre: {emailBody.Name} \nApellidos: {emailBody.LastName} \nCorreo: {emailBody.Email} \nTeléfono: {emailBody.Phone} \nEmpresa: {emailBody.Company} \nMensaje: {emailBody.Text} \nDemostración: {emailBody.Demo}";
                bodyBuilderAutoReplay.HtmlBody = $"<div style=\"width: 100%; height: 5rem; background-color: #162d4e;\"><img style=\"width: 6rem; height: 100%; margin-left: 0.5rem;\" src=\"https://cobgatewaytest.azurewebsites.net/assets/img/logoCOBnuevoFRONT.png\"></div>\r\n<p><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\">Hola <span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\">{emailBody.Name} 🏢</span></span></span></span></p>\r\n<p><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\">Hemos recibido tu solitud de contacto.</span></span></span></span></p>\r\n<p><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\">Muchas gracias por tu inter&eacute;s en el aplicativo COB (Cierre de Obra Blanca).</span></span></span></span></p>\r\n<p><span style=\"font-size: 14pt;\"><strong><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\">&iquest;Cu&aacute;l es el siguiente paso?</span></span></span></span></strong></span></p>\r\n<p><span style=\"font-size: 12pt;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\">A la brevedad uno de nuestros agentes se pondr&aacute; en contacto contigo para agendar una demostraci&oacute;n y encontrar la soluci&oacute;n que se ajuste a las necesidades de su equipo.</span></span></span></span></span></p>\r\n<p><span style=\"font-size: 12pt;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\">__________________________________</span></span></span></span></span></p>\r\n<p><span style=\"font-size: 8pt;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\"><span style=\"vertical-align: inherit;\">Copyright <strong>&copy;&nbsp;</strong>2023 COB, CIERRE DE OBRA BLANCA.</span></span></span></span></span></p>";

                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessageAutoReplay.Body = bodyBuilderAutoReplay.ToMessageBody();
                _mailFactory.MailSender(mimeMessage);
                _mailFactory.MailSender(mimeMessageAutoReplay);

                return Ok(emailBody);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}