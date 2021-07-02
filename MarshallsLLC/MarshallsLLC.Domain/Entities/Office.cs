using System.ComponentModel.DataAnnotations.Schema;

namespace MarshallsLLC.Domain.Entities
{
    public class Office
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(2)")]
        public string Name { get; set; }
    }
}
