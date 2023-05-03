namespace TrainingProject.Models
{
    public class WorkoutExecise
    {
        public int Id { get; set; }
        public int Intensity { get; set; }
        public Workout Workout { get; set; }
        public Exercise Exercise { get; set; }


    }
}
