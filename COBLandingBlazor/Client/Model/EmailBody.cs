using System.ComponentModel.DataAnnotations;

namespace COBLandingBlazor.Client.Model
{
    public class EmailBody
    {
        [Required(ErrorMessage = "Ingresa tu Correo")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ingresa tu Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ingresa tus Apellidos")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Ingresa tu Teléfono")]
        public string Phone { get; set; }
        public string Text { get; set; } = "";
        public string Company { get; set; } = "";
        public string Demo { get; set; } = "";
    }
}
