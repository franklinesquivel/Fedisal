using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Becario
/// </summary>
public class Becario
{
    private string idBecario;
    private DateTime fechaInicio;
    private DateTime fechaFin;
    private int idInformacion;
    private string idProgramaBeca;
    private int idUniversidad;
    private int idCarrera;
    private int idNivelEducativo;
    private string contrasenna;

    public string IdBecario
    {
        get
        {
            return idBecario;
        }

        set
        {
            idBecario = value;
        }
    }

    public DateTime FechaInicio
    {
        get
        {
            return fechaInicio;
        }

        set
        {
            fechaInicio = value;
        }
    }

    public DateTime FechaFin
    {
        get
        {
            return fechaFin;
        }

        set
        {
            fechaFin = value;
        }
    }

    public int IdInformacion
    {
        get
        {
            return idInformacion;
        }

        set
        {
            idInformacion = value;
        }
    }

    public string IdProgramaBeca
    {
        get
        {
            return idProgramaBeca;
        }

        set
        {
            idProgramaBeca = value;
        }
    }

    public int IdUniversidad
    {
        get
        {
            return idUniversidad;
        }

        set
        {
            idUniversidad = value;
        }
    }

    public int IdCarrera
    {
        get
        {
            return idCarrera;
        }

        set
        {
            idCarrera = value;
        }
    }

    public int IdNivelEducativo
    {
        get
        {
            return idNivelEducativo;
        }

        set
        {
            idNivelEducativo = value;
        }
    }

    public string Contrasenna
    {
        get
        {
            return contrasenna;
        }

        set
        {
            contrasenna = value;
        }
    }

    public Becario(string idBecario, int idInformacion, string idProgramaBeca, int idUniversidad, int idCarrera, int idNivelEducativo, DateTime fechaInicio, DateTime fechaFin, string contrasenna)
    {
        this.idBecario = idBecario;
        this.FechaInicio = fechaInicio;
        this.FechaFin = fechaFin;
        this.IdInformacion = idInformacion;
        this.IdProgramaBeca = idProgramaBeca;
        this.IdUniversidad = idUniversidad;
        this.IdCarrera = idCarrera;
        this.IdNivelEducativo = idNivelEducativo;
        this.contrasenna = contrasenna;
    }
}