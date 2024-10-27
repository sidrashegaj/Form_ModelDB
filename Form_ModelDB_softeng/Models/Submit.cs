namespace Form_ModelDB_softeng.Models
{
    public class Submit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public int FormId { get; set; }
        public Forms Form { get; set; }
        public ICollection<SubmitAnswer> SubmitAnswers { get; set; }
    }
}
