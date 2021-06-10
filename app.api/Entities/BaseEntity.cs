using System.ComponentModel.DataAnnotations;

namespace app.api.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
