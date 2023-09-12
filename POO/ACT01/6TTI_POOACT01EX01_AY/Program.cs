namespace _6TTI_POOACT01EX01_AY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chien[] mesChiens = new Chien[3];

            for (int i = 0; i < mesChiens.Length; i++)
            {
                Chien monChien = new Chien("Chien" + (i + 1), "Golden Retriever", 0, false, i % 2 == 0 ? "f" : "m");
                Console.WriteLine(monChien.AfficheCaracteristiques());
                monChien.Vaccine();
                monChien.Age++;
                Console.WriteLine(monChien.AfficheCaracteristiques() + "\n");
                mesChiens[i] = monChien;
            }

            Console.WriteLine("J'ai " + mesChiens.Length + " chiens dans mon tableau.");
        }
    }
}