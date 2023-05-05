namespace TrainingProject.Models
{
    public enum InetensityLevel
    {
        low=1,
        medium,
        high,
    }
    public class WorkoutExecise
    {
        public int Id { get; set; }
        public InetensityLevel Intensity { get; set; }
        public Workout Workout { get; set; }
        public Exercise Exercise { get; set; }
    }
}
