using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
namespace Form_ModelDB_softeng.Models
{
    public class FormContext: DbContext
    {
        public FormContext(DbContextOptions<FormContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Forms> Forms { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Submit> Submit { get; set; }
        public DbSet<SubmitAnswer> SubmitAnswer { get; set; }



    }
}
