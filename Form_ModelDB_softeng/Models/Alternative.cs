namespace Form_ModelDB_softeng.Models
{
    public class Alternative
    {
        public int Id { get; set; }
        public string answer { get; set; }
        public bool IsCorrect {  get; set; }//for single and multiple correct answ
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
