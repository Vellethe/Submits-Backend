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

    }
}
