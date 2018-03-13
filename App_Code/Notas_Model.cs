using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Notas_Model
/// </summary>
public class Notas_Model
{
    public Notas_Model()
    {
     
    }
    public static bool Insertar(Notas nota)
    {
        SqlCommand comando = DBConnection.GetCommand("INSERT INTO Nota(nombreMateria,nota,CumplioTercio,idCiclo) VALUES(@nombreMateria,@nota,@tercioSuperior,@idCiclo)");
        comando.Parameters.Add("@nombreMateria", SqlDbType.VarChar);
        comando.Parameters.Add("@nota", SqlDbType.Decimal);
        comando.Parameters.Add("@tercioSuperior", SqlDbType.Bit);
        comando.Parameters.Add("@idCiclo", SqlDbType.Int);

        comando.Parameters["@nombreMateria"].Value = nota.NombreMat;
        comando.Parameters["@nota"].Value = nota.Nota;
        comando.Parameters["@tercioSuperior"].Value = nota.TercioSuperior;
        comando.Parameters["@idCiclo"].Value = nota.IdCiclo;
        if (DBConnection.ExecuteCommandIUD(comando))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}