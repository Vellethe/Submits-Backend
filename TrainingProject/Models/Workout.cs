using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingProject.Data;

namespace TrainingProject.Models
{
    public enum AccessLevel
    {
        Owner,
        // later friends,
        Everyone,
    }

    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public Account Owner { get; set; }
        public virtual List<WorkoutExecise> WorkoutExecises { get; set; }
        public virtual List<Rating> Ratings { get; set; }

        public MuscleGroup MostCommonMucleGroup
        {
            get
            {
                var temp = new Dictionary<MuscleGroup, int>();

                if (!WorkoutExecises.Any())
                {
                    return MuscleGroup.all;
                }

                foreach(var exercise in WorkoutExecises )
                {
                    var mucleGroupToFind = exercise.Exercise.MuscleGroup;

                    if (temp.ContainsKey(mucleGroupToFind)){
                        temp[mucleGroupToFind]++;
                    }
                    else
                    {
                        temp[mucleGroupToFind] = 1;
                    }
                }

                return temp.Select(x => new { x.Key, x.Value }).OrderByDescending(x => x.Value).First().Key;
            }
            
        }

        public string GetAvrageRating()
        {
            int listLen = Ratings.Count();

            if(listLen == 0)
            {
                return "no ratings submited yet";
            }

            int sumRating = Ratings.Sum(x => (int)x.ChosenRating);
            return (sumRating / listLen).ToString();
        }

    }

}
