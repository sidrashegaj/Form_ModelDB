namespace Form_ModelDB_softeng.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Pic { get; set; } //string bcs url/file path are string
    }
}
