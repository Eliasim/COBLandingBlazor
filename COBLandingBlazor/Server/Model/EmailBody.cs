namespace COBLandingBlazor.Server.Model
{
    public class EmailBody
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Text { get; set; }
        public string Phone { get; set; } = "";
        public string Company { get; set; } = "";
        public string Demo { get; set; } = "";
    }
}
