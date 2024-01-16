namespace _6TTI_POOACT06EX03_AY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carre carre = new Carre(3, "bleu");
            Rectangle rectangle = new Rectangle(5, 3, "rouge");

            Console.WriteLine(carre.Afficher());
            Console.WriteLine(rectangle.Afficher());
        }
    }
}