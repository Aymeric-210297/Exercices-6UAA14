namespace _6TTI_POOACT06EX04_AY;

public class Cadre : Employe
{
    private int _indice;

    public int Indice
    {
        get { return _indice; }
        set { _indice = value; }
    }

    public Cadre(int indice, string matricule, string nom, string prenom, string dateDeNaissance)
    {
        _indice = indice;

        _matricule = matricule;
        _nom = nom;
        _prenom = prenom;
        _dateDeNaissance = dateDeNaissance;
    }

    public override string Afficher()
    {
        return "Cadre[indice:" + _indice + ";matricule:" + _matricule + ";nom:" + _nom + ";prenom:" + _prenom + ";dateDeNaissance:" + _dateDeNaissance + ";salaire:" + Salaire() + "]";
    }

    public override double Salaire()
    {
        if (_indice == 1)
        {
            return 13000;
        }
        else if (_indice == 2)
        {
            return 15000;
        }
        else if (_indice == 3)
        {
            return 17000;
        }
        else if (_indice == 4)
        {
            return 20000;
        }

        return 0;
    }
}
