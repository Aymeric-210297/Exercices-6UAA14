using System.Data;

namespace _6TTI_POOBDDEX01_AY;

public struct MesMethodes
{
    /// <summary>
    /// Générer la question pour l'utilisateur dans le cas précis où on se retrouve dans la situation: "Column (Valeur par défaut, NULL pour retirer) : ", cette fonction permet de rendre le code plus lisible.
    /// </summary>
    /// <param name="dataRow">Tuple de la table de la base de données contenant les données (pour connaître la valeur par défaut)</param>
    /// <param name="column">Colonne concernée dans le tuple</param>
    /// <returns>La question à poser à l'utilisateur</returns>
    public string GenerateQuestionString(DataRow dataRow, string column)
    {
        return $"{char.ToUpper(column[0]) + column[1..]}{(!dataRow.IsNull(column) ? $" ({dataRow[column]}, NULL pour retirer)" : "")} : ";
    }

    /// <summary>
    /// Vérifier si un string est vide ou non.
    /// </summary>
    /// <param name="value">Valeur à vérifier</param>
    /// <returns>Vrai si la valeur est vide</returns>
    public bool StringIsNull(string? value)
    {
        return value == null || value.Trim().Length <= 0;
    }

    /// <summary>
    /// Demander à l'utilisateur de donner un nombre entier.
    /// </summary>
    /// <param name="question">Question à laquelle l'utilisateur doit répondre</param>
    /// <param name="defaultValue">Valeur par défaut, dans le cas où l'utilisateur ne répond pas</param>
    /// <param name="allowNull">Si aucune valeur par défaut n'est spécifiée et que l'utilisateur ne répond pas, la fonction doit-elle renvoyer null ?</param>
    /// <param name="min">Valeur minimale (non inclusive)</param>
    /// <param name="max">Valeur maximale (non inclusive)</param>
    /// <returns>La réponse de l'utilisateur ou la valeur par défaut ou null</returns>
    public int? DemanderNombreUtilisateur(string question, int? defaultValue, bool allowNull, int? min, int? max)
    {
        int reponse;
        string? choixString;

        Console.Write(question);
        choixString = Console.ReadLine();

        if (StringIsNull(choixString) && defaultValue != null)
        {
            return defaultValue;
        }
        else if ((StringIsNull(choixString) || choixString == "NULL") && allowNull)
        {
            return null;
        }
        else if (!StringIsNull(choixString))
        {
            if (!int.TryParse(choixString, out reponse))
            {
                return DemanderNombreUtilisateur(question, defaultValue, allowNull, min, max);
            }
            else if (min != null && reponse < min)
            {
                return DemanderNombreUtilisateur(question, defaultValue, allowNull, min, max);
            }
            else if (max != null && reponse > max)
            {
                return DemanderNombreUtilisateur(question, defaultValue, allowNull, min, max);
            }

            return reponse;
        }
        else
        {
            return DemanderNombreUtilisateur(question, defaultValue, allowNull, min, max);
        }
    }

    /// <summary>
    /// Demander à l'utilisateur de remplir du texte.
    /// </summary>
    /// <param name="question">Question à laquelle l'utilisateur doit répondre</param>
    /// <param name="defaultValue">Valeur par défaut, dans le cas où l'utilisateur ne répond pas</param>
    /// <param name="allowNull">Si aucune valeur par défaut n'est spécifiée et que l'utilisateur ne répond pas, la fonction doit-elle renvoyer null ?</param>
    /// <returns>La réponse de l'utilisateur ou la valeur par défaut ou null</returns>
    public string? DemanderStringUtilisateur(string question, string? defaultValue, bool allowNull)
    {
        string? reponse;

        Console.Write(question);
        reponse = Console.ReadLine();

        if (defaultValue == null && !allowNull && StringIsNull(reponse))
        {
            return DemanderStringUtilisateur(question, defaultValue, allowNull);
        }

        if (StringIsNull(reponse))
        {
            if (allowNull && defaultValue == null)
            {
                return null;
            }
            else
            {
                return defaultValue;
            }
        }

        if (reponse == "NULL" && allowNull)
        {
            return null;
        }

        return reponse;
    }

    /// <summary>
    /// Effacer la console et écrire un titre dans la console, commencer un nouvel affichage dans le programme.
    /// </summary>
    /// <param name="title">Le titre à afficher</param>
    public void WriteTitle(string title)
    {
        string sep = string.Concat(Enumerable.Repeat("-", title.Length)) + "\n";
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(sep + title + "\n" + sep);
        Console.ResetColor();
    }

    /// <summary>
    /// Ecrire dans la console un message de réussite.
    /// </summary>
    /// <param name="msg">Le message à afficher</param>
    public void WriteSuccess(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

    /// <summary>
    /// Ecrire dans la console un message d'erreur.
    /// </summary>
    /// <param name="msg">Le message à afficher</param>
    public void WriteError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
}
