using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness.Infrastructure.Models
{
    public class WorkoutModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public int ClientId { get; set; }
        public ClientModel Client { get; set; }
    }
}