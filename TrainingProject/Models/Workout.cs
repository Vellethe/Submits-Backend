namespace TrainingProject.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Account Owner { get; set; }
        public virtual List<WorkoutExecise> WorkoutExecises { get; set; }


    }
}
