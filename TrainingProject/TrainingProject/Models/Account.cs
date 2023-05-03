namespace TrainingProject.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string OpenIDIssuer { get; set; }
        public string OpenIDSubject { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int CurentWeight {get; set; }
        public bool IsMale { get; set; }


    }
}
