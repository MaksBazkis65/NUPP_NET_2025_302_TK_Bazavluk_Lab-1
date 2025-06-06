using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness.Infrastructure.Models
{
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<WorkoutModel> Workouts { get; set; }
    }
}