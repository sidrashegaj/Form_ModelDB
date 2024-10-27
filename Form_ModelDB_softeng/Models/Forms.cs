namespace Form_ModelDB_softeng.Models
{
    public class Forms
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public Users Creator { get; set; }
        public ICollection<Section>Sections{ get; set; }       }
}
