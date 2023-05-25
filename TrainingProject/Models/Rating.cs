namespace TrainingProject.Models
{
    public enum RatingEnum
    {
        NoRating = 0,
        Awful = 1,
        Bad = 2,
        Ok = 3,
        Good = 4,
        Amazing= 5
    }
    public class Rating
    {
        public int Id { get; set; }
        public Workout Workout { get; set; }
        public Account RatingAcount { get; set; }
        public RatingEnum ChosenRating { get; set; }
    }
}
