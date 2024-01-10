namespace _6TTI_POOACT06EX04_AY;

public class Directeur : Employe
{
    private double _chiffreAffaires;
    private double _pourcentage;

    public double ChiffreAffaires
    {
        get { return _chiffreAffaires; }
        set { _chiffreAffaires = value; }
    }

    public double Pourcentage
    {
        get { return _pourcentage; }
        set { _pourcentage = value; }
    }

    public Directeur(double chiffreAffaires, double pourcentage, string matricule, string nom, string prenom, string dateDeNaissance)
    {
        _chiffreAffaires = chiffreAffaires;
        _pourcentage = pourcentage;

        _matricule = matricule;
        _nom = nom;
        _prenom = prenom;
        _dateDeNaissance = dateDeNaissance;
    }

    public override string Afficher()
    {
        return "Directeur[chiffreAffaires:" + _chiffreAffaires + ";pourcentage:" + _pourcentage + ";matricule:" + _matricule + ";nom:" + _nom + ";prenom:" + _prenom + ";dateDeNaissance:" + _dateDeNaissance + ";salaire:" + Salaire() + "]";
    }

    public override double Salaire()
    {
        return _chiffreAffaires * (_pourcentage / 100);
    }
}
