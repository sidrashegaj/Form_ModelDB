namespace Form_ModelDB_softeng.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string question { get; set; }
        public bool isOptional {  get; set; }//handles required or not 

        public int SectionId { get; set; }
        public Section Section { get; set; }
        public ICollection<Alternative> Alternatives { get; set; }


    }
}
