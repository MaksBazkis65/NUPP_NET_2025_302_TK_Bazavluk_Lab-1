using Fitness.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Common
{
    public class Workout : Identifiable
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int DurationMinutes { get; set; }
        public int CaloriesBurned { get; set; }

        public Workout() { }

        public Workout(string name, string category, int durationMinutes, int caloriesBurned)
        {
            Name = name;
            Category = category;
            DurationMinutes = durationMinutes;
            CaloriesBurned = caloriesBurned;
        }

        public override string ToString()
        {
            return $"{Name} ({Category}) - {DurationMinutes} хв, {CaloriesBurned} ккал";
        }
    }
}
