namespace Form_ModelDB_softeng.Models
{
    public class SubmitAnswer
    {
        public int Id { get; set; }
        public int SubmitId { get; set; }
        public Submit Submission { get; set; }

        public int AlternativeId { get; set; }
        public Alternative Alternative { get; set; }

        public int Score { get; set; }  //  1-5 range
    }
}
