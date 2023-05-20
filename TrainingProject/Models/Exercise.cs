namespace TrainingProject.Models
{
    public enum MuscleGroup
    {
        all,
        Back,
        Chest,
        Legs,
        Shoulders,
        Arms,
    }
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
    }
}
