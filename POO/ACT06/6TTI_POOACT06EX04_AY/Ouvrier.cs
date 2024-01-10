namespace _6TTI_POOACT06EX04_AY;

public class Ouvrier : Employe
{
    private readonly DateTime _dateEntree;
    private double _salaireFixe;

    public DateTime DateEntree
    {
        get { return _dateEntree; }
    }

    public double SalaireFixe
    {
        get { return _salaireFixe; }
        set { _salaireFixe = value; }
    }

    public Ouvrier(DateTime dateEntree, double salaireFixe, string matricule, string nom, string prenom, string dateDeNaissance)
    {
        _dateEntree = dateEntree;
        _salaireFixe = salaireFixe;

        _matricule = matricule;
        _nom = nom;
        _prenom = prenom;
        _dateDeNaissance = dateDeNaissance;
    }

    public override string Afficher()
    {
        return "Ouvrier[dateEntree:" + _dateEntree + ";salaireFixe:" + _salaireFixe + ";matricule:" + _matricule + ";nom:" + _nom + ";prenom:" + _prenom + ";dateDeNaissance:" + _dateDeNaissance + ";salaire:" + Salaire() + "]";
    }

    public override double Salaire()
    {
        TimeSpan anciennete = DateTime.Now - _dateEntree;
        int ancienneteAnnee = (int)anciennete.TotalDays / 365;
        double salaire = _salaireFixe + (100 * ancienneteAnnee);
        if (salaire > (2 * _salaireFixe))
        {
            salaire = 2 * _salaireFixe;
        }

        return salaire;
    }
}
