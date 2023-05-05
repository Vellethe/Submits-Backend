using TrainingProject.Models;

namespace TrainingProject.Data
{
    public class SampleData
    {
        public static void Create(AppDbContext database)
        {
            // If there are no fake accounts, add some.
            string fakeIssuer = "https://example.com";
            if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
            {
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1111111111",
                    Name = "Brad"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "2222222222",
                    Name = "Angelina"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "3333333333",
                    Name = "Will"
                });
            }
            if (!database.Exercises.Any())
            {
                database.Exercises.Add(new Exercise
                {
                    Description = "armhävning",
                    MuscleGroup = "armar",
                    Name = "armhävning"
                });
                database.Exercises.Add(new Exercise
                {
                    Description = "testing",
                    MuscleGroup = "armar",
                    Name = "testing"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Push-up",
                    MuscleGroup = "Arms",
                    Name = "armhävning"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Pull-up",
                    MuscleGroup = "Back and Arms",
                    Name = "chins"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Bicep curl",
                    MuscleGroup = "Biceps",
                    Name = "bicepscurl"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Tricep extension",
                    MuscleGroup = "Triceps",
                    Name = "tricepspress"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Shoulder press",
                    MuscleGroup = "Shoulders",
                    Name = "skulderpress"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Bench press",
                    MuscleGroup = "Chest and Arms",
                    Name = "bänkpress"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Deadlift",
                    MuscleGroup = "Lower back and Legs",
                    Name = "marklyft"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Squat",
                    MuscleGroup = "Legs",
                    Name = "knäböj"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Lunges",
                    MuscleGroup = "Legs",
                    Name = "utfall"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Leg press",
                    MuscleGroup = "Legs",
                    Name = "benpress"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Sit-up",
                    MuscleGroup = "Abs",
                    Name = "situps"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Plank",
                    MuscleGroup = "Core",
                    Name = "plankan"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Russian twist",
                    MuscleGroup = "Obliques",
                    Name = "russisk twist"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Mountain climbers",
                    MuscleGroup = "Core and Legs",
                    Name = "bergsklättrare"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Burpees",
                    MuscleGroup = "Full Body",
                    Name = "burpees"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Jumping jacks",
                    MuscleGroup = "Full Body",
                    Name = "hoppande jacks"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Box jumps",
                    MuscleGroup = "Legs and Explosive Power",
                    Name = "boxhopp"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Battle ropes",
                    MuscleGroup = "Shoulders and Arms",
                    Name = "slagrep"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "Kettlebell swing",
                    MuscleGroup = "Full Body and Explosive Power",
                    Name = "kettlebellsving"
                });
            }

            database.SaveChanges();
        }
    }
}
//{
//    "text": "Barbell Curl",
//    "muscleType": "Arms",
//    "muscle": "Bicep",
//    "iconUrl": "img/arms.png",
//    "tips": "If you have to swing at the hips to lift the weight, its too heavy."
//},
//{
//"text": "Cable Extension",
//    "muscleType": "Arms",
//    "muscle": "Triceps",
//    "iconUrl": "img/arms.png",
//    "tips": "Keeping your upper body straight, pull the bar down so that your arms reach a 90-degree angle."
//},
//{
//"text": "Hammer Curl",
//    "muscleType": "Arms",
//    "muscle": "Bicep",
//    "iconUrl": "img/arms.png",
//    "tips": "Bend at the elbow, lifting the lower arms to pull the weights toward the shoulders. Your upper arms are stationary and the wrists are in line with the forearms."
//},
//{
//"text": "Skull Crusher",
//    "muscleType": "Arms",
//    "muscle": "Triceps",
//    "iconUrl": "img/arms.png",
//    "tips": "As you move the weight, keep your shoulder joint stable, your elbows narrow, and your wrists straight."
//},
//{
//"text": "Reverse Curl",
//    "muscleType": "Arms",
//    "muscle": "Flexor",
//    "iconUrl": "img/arms.png",
//    "tips": "Hold a pair of dumbbells or EZ-curl bar with a pronated grip (palms facing away from your body and toward the floor)."
//},
//{
//"text": "Behind-Back Barbell Wrist Curl",
//    "muscleType": "Arms",
//    "muscle": "Flexor",
//    "iconUrl": "img/arms.png",
//    "tips": "Bending only at the wrists, let the barbell drop as far as possible."
//},
//{
//"text": "Leg Extension",
//    "muscleType": "Legs",
//    "muscle": "Quadriceps",
//    "iconUrl": "img/legs.png",
//    "tips": "Adjust the seat so that the knees are directly in line with the axis of the machine."
//},
//{
//"text": "Squats",
//    "muscleType": "Legs",
//    "muscle": "Posterior Chain",
//    "iconUrl": "img/legs.png",
//    "tips": "Stand straight with feet hip-width apart. Lower down, as if sitting in an invisible chair."
//},
//{
//"text": "Hip Thrust",
//    "muscleType": "Legs",
//    "muscle": "Glutes",
//    "iconUrl": "img/legs.png",
//    "tips": "Use a slight posterior pelvic tilt to enhance glute activation."
//},
//{
//"text": "Leg Curl",
//    "muscleType": "Legs",
//    "muscle": "Hamstrings",
//    "iconUrl": "img/legs.png",
//    "tips": "Dont allow the back to arch, keep your hips pressed into the pad."
//},
//{
//"text": "Standing Calf Raises",
//    "muscleType": "Legs",
//    "muscle": "Calves",
//    "iconUrl": "img/legs.png",
//    "tips": "Raise your heels slowly, keeping your knees extended (but not locked)."
//},
//{
//"text": "Cable Hip Adductor",
//    "muscleType": "Legs",
//    "muscle": "Adductors",
//    "iconUrl": "img/legs.png",
//    "tips": "This is not a maximal strength focused movement. Use a challenging weight but do not strain to perform the movement."
//},
//{
//"text": "Dumbbell Crunch",
//    "muscleType": "Abs",
//    "muscle": "Upper Abdominis",
//    "iconUrl": "img/abs.png",
//    "tips": "Grab a dumbbell, weight plate, or medicine ball and hold it close to your chest as you lie face-up on an exercise mat with your knees bent and your feet on the floor."
//},
//{
//"text": "Hanging Leg Raise",
//    "muscleType": "Abs",
//    "muscle": "Lower Abdominis",
//    "iconUrl": "img/abs.png",
//    "tips": "Work your way up to it. The hanging leg raise is an advanced ab exercise that requires upper body strength and stability."
//},
//{
//"text": "Bicycle Crunches",
//    "muscleType": "Abs",
//    "muscle": "Abdominis",
//    "iconUrl": "img/abs.png",
//    "tips": "Twist your body to touch your elbow to the opposite knee with each pedal motion."
//},
//{
//"text": "Seated Military Press",
//    "muscleType": "Shoulder",
//    "muscle": "Rear Deltoid",
//    "iconUrl": "img/shoulders.png",
//    "tips": "If you have heavy dumbbells, raise your thighs one at a time to help lift the dumbbells."
//},
//{
//"text": "Plank Dumbbell Shoulder Raise",
//    "muscleType": "Shoulder",
//    "muscle": "Rear Deltoid",
//    "iconUrl": "img/shoulders.png",
//    "tips": "Bring the feet in as close to each other as you can while maintaining a good flat back position and not shifting your hips."
//},
//{
//"text": "Dumbbell Front Raise",
//    "muscleType": "Shoulder",
//    "muscle": "Anterior Deltoid",
//    "iconUrl": "img/shoulders.png",
//    "tips": "Lower the dumbbells to the starting position (at the thighs) with a slow and controlled motion while exhaling."
//},
//{
//"text": "Overhead Press",
//    "muscleType": "Shoulder",
//    "muscle": "Anterior Deltoid",
//    "iconUrl": "img/shoulders.png",
//    "tips": "As you press the weight up, let your head move forward slightly. Some people resist this natural motion, and that's a mistake."
//},
//{
//"text": "Lat Pulldown",
//    "muscleType": "Back",
//    "muscle": "Latissimus Dorsi",
//    "iconUrl": "img/back.png",
//    "tips": "Resist the temptation to use momentum to pull the bar towards your chest."
//},
//{
//"text": "Reverse Fly",
//    "muscleType": "Back",
//    "muscle": "Trapezius",
//    "iconUrl": "img/back.png",
//    "tips": "Raise both arms out to your side on an exhale. Keep a soft bend in your elbows."
//},
//{
//"text": "Seated Row",
//    "muscleType": "Back",
//    "muscle": "Latissimus Dorsi",
//    "iconUrl": "img/back.png",
//    "tips": "Avoid lifting your elbows up and out, which engages the biceps instead of the lats and rhomboids."
//},
//{
//"text": "Deadlift",
//    "muscleType": "Back",
//    "muscle": "Back",
//    "iconUrl": "img/back.png",
//    "tips": "Check your form before you start the lift: neutral spine, chest up, knees out."
//},
//{
//"text": "Superman",
//    "muscleType": "Back",
//    "muscle": "Erector Spinae",
//    "iconUrl": "img/back.png",
//    "tips": "Lie facedown with arms and legs outstretched, forehead on the mat. Your neck should be in a neutral position."
//},
//{
//"text": "Bench Press",
//    "muscleType": "Chest",
//    "muscle": "Pectoralis Major",
//    "iconUrl": "img/chest.png",
//    "tips": "Keep a tight grip on the bar at all times, a tighter grip equates to more tension in the lower arms, upper back and chest."
//},
//{
//"text": "Incline Bench Press",
//    "muscleType": "Chest",
//    "muscle": "Pectoralis Major",
//    "iconUrl": "img/chest.png",
//    "tips": "Keep the bar in line with your wrist and elbows and ensure it travels in a straight line."
//},
//{
//"text": "Cable Chest Flys",
//    "muscleType": "Chest",
//    "muscle": "Pectoralis Major & Minor",
//    "iconUrl": "img/chest.png",
//    "tips": "Stand between two cables positioned above shoulder level, gripping them with your palms facing forward."
//},
//{
//"text": "Decline Press",
//    "muscleType": "Chest",
//    "muscle": "Pectoralis Minor",
//    "iconUrl": "img/chest.png",
//    "tips": "Unrack a weighted barbell with a grip slightly wider than shoulder-width apart."
//}