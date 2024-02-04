using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace _6TTI_POOBDDEX01_AY;

public class BienModel
{
    private MySqlConnection _mySqlConnection;
    private DataSet _dataSet;

    public BienModel(MySqlConnection mySqlConnection)
    {
        _mySqlConnection = mySqlConnection;
        _dataSet = new DataSet();
    }

    public DataSet DataSet
    {
        get { return _dataSet; }
    }

    /// <summary>
    /// Rafraîchir la liste des biens.
    /// </summary>
    /// <returns>Vrai si l'opération a réussi</returns>
    public bool RefreshBiens()
    {
        string query = "SELECT * FROM biens;";

        try
        {
            _mySqlConnection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(query, _mySqlConnection);
            _dataSet.Tables["biens"]?.Clear();
            da.Fill(_dataSet, "biens");
            _mySqlConnection.Close();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Ajouter un nouveau bien.
    /// </summary>
    /// <param name="nom">Le nom du bien</param>
    /// <param name="taille">La taille du bien</param>
    /// <param name="prix">Le prix du bien</param>
    /// <param name="ville">Le nom de la ville où le bien est localisé</param>
    /// <param name="userId">L'ID de l'utilisateur associé à ce bien</param>
    /// <param name="description">La description du bien</param>
    /// <param name="chambres">Le nombre de chambres dans le bien</param>
    /// <returns>Vrai si l'opération a réussi</returns>
    public bool AddBien(string? nom, int? taille, int? prix, string? ville, int userId, string? description, int? chambres)
    {
        string query =
            "INSERT INTO biens" +
            "(nom, taille, prix, ville, userId, description, chambres)" +
            "VALUES" +
            "(@nom, @taille, @prix, @ville, @userId, @description, @chambres" +
            ");";

        try
        {
            _mySqlConnection.Open();
            MySqlCommand command = new MySqlCommand(query, _mySqlConnection);
            command.Parameters.AddWithValue("@nom", nom);
            command.Parameters.AddWithValue("@taille", taille == 0 ? null : taille);
            command.Parameters.AddWithValue("@prix", prix == 0 ? null : prix);
            command.Parameters.AddWithValue("@ville", ville);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@chambres", chambres == 0 ? null : chambres);
            int res = command.ExecuteNonQuery();
            _mySqlConnection.Close();
            return res > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Modifier un bien.
    /// </summary>
    /// <param name="id">L'ID du bien à modifier</param>
    /// <param name="nom">Le nouveau nom du bien</param>
    /// <param name="taille">La nouvelle taille du bien</param>
    /// <param name="prix">Le nouveau prix du bien</param>
    /// <param name="ville">Le nouveau nom de la ville où le bien est localisé</param>
    /// <param name="userId">Le nouvel ID de l'utilisateur associé à ce bien</param>
    /// <param name="description">La nouvelle description du bien</param>
    /// <param name="chambres">Le nouveau nombre de chambres dans le bien</param>
    /// <returns>Vrai si l'opération a réussi</returns>
    public bool UpdateBien(int id, string? nom, int? taille, int? prix, string? ville, int userId, string? description, int? chambres)
    {
        string query =
            "UPDATE biens " +
            "SET nom = @nom, taille = @taille, prix = @prix, ville = @ville, userId = @userId, description = @description, chambres = @chambres " +
            "WHERE bienId = @id;";

        try
        {
            _mySqlConnection.Open();
            MySqlCommand command = new MySqlCommand(query, _mySqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nom", nom);
            command.Parameters.AddWithValue("@taille", taille == 0 ? null : taille);
            command.Parameters.AddWithValue("@prix", prix == 0 ? null : prix);
            command.Parameters.AddWithValue("@ville", ville);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@chambres", chambres == 0 ? null : chambres);
            int res = command.ExecuteNonQuery();
            _mySqlConnection.Close();
            return res > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Supprimer un bien.
    /// </summary>
    /// <param name="id">L'ID du bien à supprimer</param>
    /// <returns>Vrai si l'opération a réussi</returns>
    public bool DeleteBien(int id)
    {
        string query = "DELETE FROM biens WHERE bienId = @id;";

        try
        {
            _mySqlConnection.Open();
            MySqlCommand command = new MySqlCommand(query, _mySqlConnection);
            command.Parameters.AddWithValue("@id", id);
            int res = command.ExecuteNonQuery();
            _mySqlConnection.Close();
            return res > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
