using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MimeKit;
using COBLandingBlazor.Client.Interfaces;
using COBLandingBlazor.Client.Model;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace COBLandingBlazor.Client.Pages
{
    public partial class Index
    {
        EmailBody Form = new EmailBody();

        [Inject]
        private IMailService _mailService { get; set; }
        public async void ActivateDemoButton()
        {
            Form.Demo = "Solicita Demostración";
            await JSRuntime.InvokeVoidAsync("GoContact");
        }
        public async Task SendEMail()
        {

            var res = await _mailService.Email(Form);

            if(Form.Name == null || Form.Email == null || Form.Phone == null)
            {
                return;
            }
            else if (res != null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Hemos recibido su solicitud de contacto");
            }
        }
    }

}
