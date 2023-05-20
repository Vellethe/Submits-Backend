using System.Security.Policy;
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
                database.SaveChanges();
            }

            if (!database.Exercises.Any())
            {

                database.Exercises.Add(new Exercise
                {
                    Description = "An exercise that primarily targets the arms muscles, where you use your body weight to push up and down from the ground.",
                    MuscleGroup = MuscleGroup.Arms,
                    Name = "Push-up",
                    Instruction = "https://www.youtube.com/watch?v=SeCKUmcrWt0"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "A back and arms exercise that involves lifting your bodyweight by pulling your chin above a bar",
                    MuscleGroup = MuscleGroup.Back,
                    Name = "Chins/Pull-up",
                    Instruction = "https://www.youtube.com/watch?v=65NRu9mQfgQ"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "An exercise that focuses on building biceps muscles, where you lift weights by curling your arms up towards your shoulders",
                    MuscleGroup = MuscleGroup.Arms,
                    Name = "Bicep curls",
                    Instruction = "https://www.youtube.com/watch?v=Zjv0tiMjkJU&t=39s"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "An exercise that targets the triceps muscles, where you extend your arms to lift weights behind your head",
                    MuscleGroup = MuscleGroup.Arms,
                    Name = "Triceps extensions",
                    Instruction = "https://www.youtube.com/watch?v=_gsUck-7M74"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "A workout that targets the shoulder muscles, where you lift weights above your head",
                    MuscleGroup = MuscleGroup.Shoulders,
                    Name = "Shoulder press",
                    Instruction = "https://www.youtube.com/watch?v=qEwKCR5JCog"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "An exercise that primarily targets the chest and arms muscles, where you lift weights while lying on your back on a bench",
                    MuscleGroup = MuscleGroup.Chest,
                    Name = "Bench press",
                    Instruction = "https://www.youtube.com/watch?v=gRVjAtPip0Y"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "A weight training exercise that focuses on the lower back and leg muscles, where you lift weights from the ground to a standing position",
                    MuscleGroup = MuscleGroup.Back,
                    Name = "Deadlift",
                    Instruction = "https://www.youtube.com/watch?v=-4qRntuXBSc"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "A lower body exercise that targets the legs muscles, where you lower yourself down while holding weights and then stand up again",
                    MuscleGroup = MuscleGroup.Legs,
                    Name = "Squats",
                    Instruction = "https://www.youtube.com/watch?v=Dy28eq2PjcM"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "An exercise that targets the leg muscles, where you step forward and lower your body to a lunge position, then alternate legs",
                    MuscleGroup = MuscleGroup.Legs,
                    Name = "Lunges",
                    Instruction = "https://www.youtube.com/watch?v=wrwwXE_x-pQ"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "An exercise that targets the leg muscles, where you sit on a machine and push weight away from your body using your legs",
                    MuscleGroup = MuscleGroup.Legs,
                    Name = "Leg press",
                    Instruction = "https://www.youtube.com/watch?v=8EMbB0tCn7Q"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "An abdominal exercise where you lift your upper body off the ground while keeping your feet planted",
                    MuscleGroup = MuscleGroup.Chest,
                    Name = "Sit-ups",
                    Instruction = "https://www.youtube.com/watch?v=jDwoBqPH0jk"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "A core exercise where you hold yourself in a push-up position for a set amount of time to strengthen your abs and back muscles",
                    MuscleGroup = MuscleGroup.Chest,
                    Name = "Plank",
                    Instruction = "https://www.youtube.com/watch?v=kL_NJAkCQBg"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "An exercise that targets the oblique muscles, where you sit with your knees bent and twist your torso while holding weights",
                    MuscleGroup = MuscleGroup.Chest,
                    Name = "Russian twists",
                    Instruction = "https://www.youtube.com/watch?v=wkD8rjkodUI"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "An exercise that targets the core and leg muscles, where you alternate bringing your knees towards your chest while holding a push-up position",
                    MuscleGroup = MuscleGroup.Chest,
                    Name = "Mountain climbers",
                    Instruction = "https://www.youtube.com/watch?v=nmwgirgXLYM"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "A full-body exercise where you jump up, drop down to a push-up position, do a push-up, jump back up, and repeat",
                    MuscleGroup = MuscleGroup.Legs, //fullbody
                    Name = "Burpees",
                    Instruction = "https://www.youtube.com/watch?v=auBLPXO8Fww"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "An aerobic exercise where you jump and spread your arms and legs apart, then jump back together again",
                    MuscleGroup = MuscleGroup.Legs, //fullbody
                    Name = "Jumping jacks",
                    Instruction = "https://www.youtube.com/watch?v=nGaXj3kkmrU"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "An explosive power exercise that targets the legs muscles, where you jump onto a box or platform repeatedly",
                    MuscleGroup = MuscleGroup.Legs,
                    Name = "Box jumps",
                    Instruction = "https://www.youtube.com/watch?v=NBY9-kTuHEk"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "A workout that primarily targets the shoulders and arms muscles, where you wave long ropes up and down to build strength and endurance",
                    MuscleGroup = MuscleGroup.Shoulders, //Arms",
                    Name = "Battle ropes",
                    Instruction = "https://www.youtube.com/watch?v=_nkQ9ej1CFs"
                });

                database.Exercises.Add(new Exercise
                {
                    Description = "A full-body and explosive power exercise, where you swing a weight between your legs and then thrust it forward using your hips and legs",
                    MuscleGroup = MuscleGroup.Legs,
                    Name = "Kettlebell swing",
                    Instruction = "https://www.youtube.com/watch?v=sSESeQAir2M"
                });
                database.SaveChanges();
            }

            if (database.Workouts.Count() < 5)
            {
                var brad = database.Accounts.Single(a => a.Name == "Brad");
                var will = database.Accounts.Single(a => a.Name == "Will");
                var angelina = database.Accounts.Single(a => a.Name == "Angelina");

                var pushUp = database.Exercises.Single(a => a.Name == "Push-up");
                var pullUp = database.Exercises.Single(a => a.Name == "Chins/Pull-up");
                var squats = database.Exercises.Single(a => a.Name == "Squats");
                var boxJumps = database.Exercises.Single(a => a.Name == "Box jumps");
                var plank = database.Exercises.Single(a => a.Name == "Plank");
                var tricepsExtensions = database.Exercises.Single(a => a.Name == "Triceps extensions");
                var bicepCurls = database.Exercises.Single(a => a.Name == "Biceps curls");
                var deadlift = database.Exercises.Single(a => a.Name == "Deadlift");
                var legPress = database.Exercises.Single(a => a.Name == "Leg press");

                var workout = new Workout
                {
                    Name = "Full Body Workout",
                    AccessLevel = AccessLevel.Everyone,
                    Owner = (Account)brad,
                    WorkoutExecises = new List<WorkoutExecise>()
                };
                workout.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workout,
                    Exercise = (Exercise)pushUp,
                });
                workout.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workout,
                    Exercise = (Exercise)pullUp,
                });
                workout.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.medium,
                    Workout = workout,
                    Exercise = (Exercise)squats,
                });
                database.Workouts.Add(workout);

                var workoutOne = new Workout
                {
                    Name = "Bodyweight Workout",
                    AccessLevel = AccessLevel.Everyone,
                    Owner = (Account)brad,
                    WorkoutExecises = new List<WorkoutExecise>()
                };
                workoutOne.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutOne,
                    Exercise = (Exercise)plank,
                });
                workoutOne.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutOne,
                    Exercise = (Exercise)boxJumps,
                });
                database.Workouts.Add(workoutOne);

                var workoutTwo = new Workout
                {
                    Name = "Cardio",
                    AccessLevel = AccessLevel.Everyone,
                    Owner = (Account)will,
                    WorkoutExecises = new List<WorkoutExecise>()
                };
                workoutTwo.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.medium,
                    Workout = workoutTwo,
                    Exercise = (Exercise)squats,
                });
                workoutTwo.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.medium,
                    Workout = workoutTwo,
                    Exercise = (Exercise)boxJumps,
                });
                database.Workouts.Add(workoutTwo);

                var workoutThree = new Workout
                {
                    Name = "Arms Are Power",
                    AccessLevel = AccessLevel.Everyone,
                    Owner = (Account)will,
                    WorkoutExecises = new List<WorkoutExecise>()
                };
                workoutThree.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutThree,
                    Exercise = (Exercise)tricepsExtensions,
                });
                workoutThree.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutThree,
                    Exercise = (Exercise)bicepCurls,
                });
                database.Workouts.Add(workoutThree);

                var workoutFour = new Workout
                {
                    Name = "Legs Are Power",
                    AccessLevel = AccessLevel.Everyone,
                    Owner = (Account)angelina,
                    WorkoutExecises = new List<WorkoutExecise>()
                };
                workoutFour.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutFour,
                    Exercise = (Exercise)legPress,
                });
                workoutFour.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutFour,
                    Exercise = (Exercise)squats,
                });
                workoutFour.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutFour,
                    Exercise = (Exercise)deadlift,
                });
                database.Workouts.Add(workoutFour);

                var workoutFive = new Workout
                {
                    Name = "Super Cardio",
                    AccessLevel = AccessLevel.Everyone,
                    Owner = (Account)angelina,
                    WorkoutExecises = new List<WorkoutExecise>()
                };
                workoutFive.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutFive,
                    Exercise = (Exercise)squats,
                });
                workoutFive.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutFive,
                    Exercise = (Exercise)boxJumps,
                });
                workoutFive.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutFive,
                    Exercise = (Exercise)plank,
                });
                workoutFive.WorkoutExecises.Add(new WorkoutExecise
                {
                    Intensity = InetensityLevel.high,
                    Workout = workoutFive,
                    Exercise = (Exercise)pushUp,
                });
                database.Workouts.Add(workoutFive);
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