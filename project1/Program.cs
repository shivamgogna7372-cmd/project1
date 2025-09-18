using System;

namespace VirtualPetSimulator
{
    /// <summary>
    /// Represents the Pet with stats and actions.
    /// </summary>
    class Pet
    {
        public string Type { get; private set; }
        public string Name { get; private set; }

        // Stats on a scale of 1..10
        public int Hunger { get; private set; }     // 1 = Full, 10 = Starving
        public int Happiness { get; private set; }  // 1 = Very Sad, 10 = Very Happy
        public int Health { get; private set; }     // 1 = Poor, 10 = Excellent

        private Random random = new Random();

        /// <summary>
        /// Constructor initializes pet type, name, and balanced starting stats.
        /// </summary>
        public Pet(string type, string name)
        {
            Type = Capitalize(type);
            Name = Capitalize(name);

            Hunger = 5;
            Happiness = 6;
            Health = 8;

            Console.WriteLine($"\n🎉 Welcome {Name} the {Type}! Your new pet is ready.\n");
        }

        /// <summary>
        /// Feed action decreases hunger and increases health slightly.
        /// </summary>
        public void Feed()
        {
            Console.WriteLine($"\nYou feed {Name}...");

            if (Hunger <= 2)
            {
                Console.WriteLine($"{Name} is already quite full and only eats a little.");
            }
            else
            {
                Hunger = Clamp(Hunger - 3);
                Health = Clamp(Health + 1);
                Console.WriteLine($"{Name} enjoyed the food! Hunger decreased, health improved.");
            }

            HourPasses();
        }

        /// <summary>
        /// Play action increases happiness but also increases hunger.
        /// If the pet is too hungry or too weak, it refuses to play.
        /// </summary>
        public void Play()
        {
            Console.WriteLine($"\nYou try to play with {Name}...");

            if (Hunger >= 8)
            {
                Console.WriteLine($"{Name} is too hungry to play! Feed first.");
                HourPasses(); // Time still passes
                return;
            }

            if (Health <= 2)
            {
                Console.WriteLine($"{Name} is too weak to play. Let it rest!");
                HourPasses();
                return;
            }

            Happiness = Clamp(Happiness + 2);
            Hunger = Clamp(Hunger + 1);

            Console.WriteLine($"{Name} had fun! Happiness increased, hunger slightly increased.");
            HourPasses();
        }

        /// <summary>
        /// Rest action improves health but decreases happiness slightly.
        /// </summary>
        public void Rest()
        {
            Console.WriteLine($"\n{Name} takes a rest...");
            Health = Clamp(Health + 2);
            Happiness = Clamp(Happiness - 1);

            Console.WriteLine($"{Name} feels healthier but a little bored.");
            HourPasses();
        }

        /// <summary>
        /// Simulates passage of one hour after each action.
        /// Applies passive changes and neglect consequences.
        /// </summary>
        private void HourPasses()
        {
            Console.WriteLine("(⏳ One hour passes...)");

            // Natural stat changes
            Hunger = Clamp(Hunger + 1);
            Happiness = Clamp(Happiness - 1);

            // Neglect consequences
            if (Hunger >= 9)
            {
                Console.WriteLine($"⚠️ {Name} is starving! Health drops from hunger.");
                Health = Clamp(Health - 2);
            }

            if (Happiness <= 2)
            {
                Console.WriteLine($"⚠️ {Name} is very unhappy! Health is affected.");
                Health = Clamp(Health - 1);
            }

            // Random positive event
            if (random.Next(1, 21) == 1) // 1 in 20 chance
            {
                Happiness = Clamp(Happiness + 2);
                Console.WriteLine($"✨ {Name} found a hidden toy and got happier!");
            }

            ShowWarnings();
        }

        /// <summary>
        /// Prints warnings if stats are critical.
        /// </summary>
        private void ShowWarnings()
        {
            if (Hunger >= 8) Console.WriteLine($"CRITICAL ⚠️ Hunger: {Hunger}/10 — Feed {Name} soon!");
            if (Happiness <= 2) Console.WriteLine($"CRITICAL ⚠️ Happiness: {Happiness}/10 — Play with {Name}!");
            if (Health <= 3) Console.WriteLine($"CRITICAL ⚠️ Health: {Health}/10 — Needs care!");
        }

        /// <summary>
        /// Shows pet's current stats clearly.
        /// </summary>
        public void ShowStatus()
        {
            Console.WriteLine("\n----- 🐾 Pet Status -----");
            Console.WriteLine($"Name     : {Name} the {Type}");
            Console.WriteLine($"Hunger   : {Hunger}/10");
            Console.WriteLine($"Happiness: {Happiness}/10");
            Console.WriteLine($"Health   : {Health}/10");
            Console.WriteLine("-------------------------\n");
        }

        /// <summary>
        /// Returns true if the pet is still alive.
        /// </summary>
        public bool IsAlive()
        {
            return Health > 0;
        }

        /// <summary>
        /// Helper: keeps stats between 1 and 10.
        /// </summary>
        private int Clamp(int value)
        {
            if (value < 1) return 1;
            if (value > 10) return 10;
            return value;
        }

        /// <summary>
        /// Helper: capitalize first letter of strings.
        /// </summary>
        private string Capitalize(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "Unknown";
            s = s.Trim();
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }
    }

    /// <summary>
    /// Main program controls user interaction and menu loop.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 🐶🐱 Virtual Pet Simulator 🐰 ===");
            Console.WriteLine("Stats range: 1 to 10 (1 = bad, 10 = excellent).");
            Console.WriteLine();

            // Pet creation
            string type = GetPetType();
            Console.Write("Enter your pet's name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) name = "Buddy";

            Pet pet = new Pet(type, name);

            // Instructions
            Console.WriteLine("How to interact:");
            Console.WriteLine("1 - Feed | 2 - Play | 3 - Rest | 4 - Check Status | 5 - Quit\n");

            // Main loop
            while (pet.IsAlive())
            {
                Console.Write("Choose an action (1-5): ");
                string choice = Console.ReadLine();

                if (choice == "1") pet.Feed();
                else if (choice == "2") pet.Play();
                else if (choice == "3") pet.Rest();
                else if (choice == "4") pet.ShowStatus();
                else if (choice == "5")
                {
                    Console.WriteLine("Exiting game. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Try again.");
                }

                if (!pet.IsAlive())
                {
                    Console.WriteLine($"\n💔 Sadly, {name} has passed away due to poor health.");
                    break;
                }
            }

            Console.WriteLine("\n(Program ended. Press Enter to exit.)");
            Console.ReadLine();
        }

        /// <summary>
        /// Gets a valid pet type (cat, dog, rabbit).
        /// </summary>
        static string GetPetType()
        {
            while (true)
            {
                Console.Write("Choose pet type (cat/dog/rabbit): ");
                string type = Console.ReadLine().Trim().ToLower();

                if (type == "cat" || type == "dog" || type == "rabbit")
                    return type;
                else
                    Console.WriteLine("Invalid choice. Please type cat, dog, or rabbit.");
            }
        }
    }
}