
namespace Form_ModelDB_softeng.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FormId{ get; set; }
        public Forms Forms { get; set; }
        public ICollection<Question>Questions { get; set; }

    }
}
