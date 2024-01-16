namespace _6TTI_POOACT06EX02_AY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[3];
            animals[0] = new Chat("Pitor", "01/01/2003", "D763", 30, false);
            animals[1] = new Chien("Médor", "01/01/2002", "P893", 50, false);
            animals[2] = new Lapin("Flocon", "01/01/2009", "C471", 10, true, 3);

            for (int i = 0; i < animals.Length; i++)
            {
                Animal animal = animals[i];
                Console.WriteLine(animal.Afficher());
                animal.Manger();
                if (animal is Chat)
                {
                    ((Chat)animal).Miauler();
                } else if (animal is Chien)
                {
                    ((Chien)animal).Aboyer();
                } else if (animal is Lapin)
                {
                    ((Lapin)animal).FaireBond();
                }
                animal.Dormir();
            }
        }
    }
}