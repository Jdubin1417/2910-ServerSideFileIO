namespace ServerSideFileIO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pets = ReadPets();
            pets.Sort();
            pets.Reverse();
            WritePets(pets);
        }

        public static List<Pet> CreatePets()
        {
            List<Pet> pets = new List<Pet>
            {
                new Pet("Garfield", 12, "cat"),
                new Pet("Snoopy", 8, "beagle"),
                new Pet("Clifford", 999, "big red dog"),
                new Pet("Ghost", 11, "direwolf")
            };

            return pets;
        }

        public static void WritePets(List<Pet> pets)
        {
            // 1. Where's the file
            var rootPath = RootDirectory.root;
            var dataPath = rootPath + Path.DirectorySeparatorChar + "data";
            var filePath = dataPath + Path.DirectorySeparatorChar + "pets.psv";
            
            // 2. Append or not to append

            // using statement will automatically dispose of the resource
            // in this case, the StreamWriter
            using(StreamWriter sr = new StreamWriter(filePath))
            {
                foreach(Pet p in pets)
                    sr.WriteLine(p);
            }
        }

        public static List<Pet> ReadPets()
        {
            List<Pet> pets = new List<Pet>();

            var filePath = RootDirectory.root + 
                Path.DirectorySeparatorChar + "data" + 
                Path.DirectorySeparatorChar + "pets.csv";

            using(StreamReader sr = new StreamReader(filePath))
            {
                while(!sr.EndOfStream)
                {
                    var line = sr.ReadLine(); // sadie,13,bat
                    string[] petInfo = line.Split(",");
                    Pet p = new Pet(petInfo[0], int.Parse(petInfo[1]), petInfo[2]);
                    pets.Add(p);
                }
            }

            return pets;
        }
    }
}