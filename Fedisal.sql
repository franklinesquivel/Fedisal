/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases V10.0.1                    */
/* Target DBMS:           MS SQL Server 2016                              */
/* Project file:          LP2.Catedra.dez                                 */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Database creation script                        */
/* Created on:            2018-02-24 14:57                                */
/* ---------------------------------------------------------------------- */


USE master;
GO

CREATE DATABASE Fedisal;
GO

/* ---------------------------------------------------------------------- */
/* Add tables                                                             */
/* ---------------------------------------------------------------------- */

GO


/* ---------------------------------------------------------------------- */
/* Add table "Carrera"                                                    */
/* ---------------------------------------------------------------------- */

GO

USE Fedisal;
GO

CREATE TABLE [Carrera] (
    [idCarrera] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR(40),
    CONSTRAINT [PK_Carrera] PRIMARY KEY ([idCarrera])
)
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Nombre de la carrera.', 'SCHEMA', N'dbo', 'TABLE', N'Carrera', 'COLUMN', N'nombre'
GO


/* ---------------------------------------------------------------------- */
/* Add table "Universidad"                                                */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Universidad] (
    [idUniversidad] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR(80),
    [direccion] VARCHAR(80),
    [telefono] VARCHAR(9),
    CONSTRAINT [PK_Universidad] PRIMARY KEY ([idUniversidad])
)
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Nombre de la universidad.', 'SCHEMA', N'dbo', 'TABLE', N'Universidad', 'COLUMN', N'nombre'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Direcci�n de la universidad.', 'SCHEMA', N'dbo', 'TABLE', N'Universidad', 'COLUMN', N'direccion'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Tel�fono de la universidad.', 'SCHEMA', N'dbo', 'TABLE', N'Universidad', 'COLUMN', N'telefono'
GO


/* ---------------------------------------------------------------------- */
/* Add table "NivelEducativo"                                             */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [NivelEducativo] (
    [idNivelEducativo] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR(80),
    [descripcion] VARCHAR(120),
    CONSTRAINT [PK_NivelEducativo] PRIMARY KEY ([idNivelEducativo])
)
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Nombre del nivel educativo.', 'SCHEMA', N'dbo', 'TABLE', N'NivelEducativo', 'COLUMN', N'nombre'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Descripci�n del nivel educativo.', 'SCHEMA', N'dbo', 'TABLE', N'NivelEducativo', 'COLUMN', N'descripcion'
GO


/* ---------------------------------------------------------------------- */
/* Add table "InformacionPersonal"                                        */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [InformacionPersonal] (
    [idInformacion] INTEGER IDENTITY(1,1) NOT NULL,
    [nombres] VARCHAR(80),
    [apellidos] VARCHAR(80),
    [dui] VARCHAR(10),
    [fechaNacimiento] DATE,
    [direccionResidencia] VARCHAR(100),
    [telefono] VARCHAR(9),
    [correoElectronico] VARCHAR(60),
    CONSTRAINT [PK_InformacionPersonal] PRIMARY KEY ([idInformacion])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "ProgramaBecas"                                              */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [ProgramaBecas] (
    [idPrograma] CHAR(4) NOT NULL,
    [nombre] VARCHAR(40),
    [descripcion] VARCHAR(80),
    CONSTRAINT [PK_ProgramaBecas] PRIMARY KEY ([idPrograma])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "TipoDesembolso"                                             */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [TipoDesembolso] (
    [idTipoDesembolso] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR(40),
    PRIMARY KEY ([idTipoDesembolso])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "TipoIncidente"                                              */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [TipoIncidente] (
    [idTipoIncidente] INTEGER IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR(40),
    [descripcion] VARCHAR(150),
    CONSTRAINT [PK_TipoIncidente] PRIMARY KEY ([idTipoIncidente])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "TipoUsuario"                                                */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [TipoUsuario] (
    [idTipoUsuario] CHAR(1) NOT NULL,
    [descripcion] VARCHAR(40),
    CONSTRAINT [PK_TipoUsuario] PRIMARY KEY ([idTipoUsuario])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Becario"                                                   */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Becario] (
    [idBecario] VARCHAR(12) NOT NULL,
    [fechaInicio] DATE,
    [fechaFin] DATE,
    [idInformacion] INTEGER,
    [idPrograma] CHAR(4),
    [idUniversidad] INTEGER,
    [idCarrera] INTEGER,
    [idNivelEducativo] INTEGER,
	[contrasenna] VARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Becario] PRIMARY KEY ([idBecario])
)
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'C�digo �nico del becario. ', 'SCHEMA', N'dbo', 'TABLE', N'Becario', 'COLUMN', N'idBecario'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Fecha en la cual el becario inicia el programa.', 'SCHEMA', N'dbo', 'TABLE', N'Becario', 'COLUMN', N'fechaInicio'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Fecha en la cual el becario  finaliza el programa', 'SCHEMA', N'dbo', 'TABLE', N'Becario', 'COLUMN', N'fechaFin'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Llave for�nea de la tabla Informacion_Personal.', 'SCHEMA', N'dbo', 'TABLE', N'Becario', 'COLUMN', N'idInformacion'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Llave for�nea de la tabla ProgramaBecas', 'SCHEMA', N'dbo', 'TABLE', N'Becario', 'COLUMN', N'idPrograma'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Llave for�nea de la tabla Universidad', 'SCHEMA', N'dbo', 'TABLE', N'Becario', 'COLUMN', N'idUniversidad'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Llave for�nea de la tabla Carrera', 'SCHEMA', N'dbo', 'TABLE', N'Becario', 'COLUMN', N'idCarrera'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Llave for�nea de la tabla NivelEducativo', 'SCHEMA', N'dbo', 'TABLE', N'Becario', 'COLUMN', N'idNivelEducativo'
GO


/* ---------------------------------------------------------------------- */
/* Add table "PresupuestoBecas"                                           */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [PresupuestoBecas] (
    [idPresupuesto] INTEGER IDENTITY(1,1) NOT NULL,
    [libro] MONEY,
    [colegiatura] MONEY,
    [manutencion] MONEY,
    [matricula] MONEY,
    [otros] MONEY,
    [trabajoGraduacion] MONEY,
    [idBecario] VARCHAR(12),
    CONSTRAINT [PK_PresupuestoBecas] PRIMARY KEY ([idPresupuesto])
)
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Presupuesto para libros.', 'SCHEMA', N'dbo', 'TABLE', N'PresupuestoBecas', 'COLUMN', N'libro'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Presupuesto para colegiatura.', 'SCHEMA', N'dbo', 'TABLE', N'PresupuestoBecas', 'COLUMN', N'colegiatura'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Presupuesto para la manutenci�n diaria.', 'SCHEMA', N'dbo', 'TABLE', N'PresupuestoBecas', 'COLUMN', N'manutencion'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Presupuesto para la matricula.', 'SCHEMA', N'dbo', 'TABLE', N'PresupuestoBecas', 'COLUMN', N'matricula'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Presupuesto para otros aranceles.', 'SCHEMA', N'dbo', 'TABLE', N'PresupuestoBecas', 'COLUMN', N'otros'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Presupuesto para el trabajo de graduaci�n.', 'SCHEMA', N'dbo', 'TABLE', N'PresupuestoBecas', 'COLUMN', N'trabajoGraduacion'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Llave for�nea del Becario.', 'SCHEMA', N'dbo', 'TABLE', N'PresupuestoBecas', 'COLUMN', N'idBecario'
GO


/* ---------------------------------------------------------------------- */
/* Add table "Ciclo"                                                      */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Ciclo] (
    [idCiclo] INTEGER IDENTITY(1,1) NOT NULL,
    [anio] NUMERIC(4),
    [nCiclo] INTEGER,
    [evidenciaNotas] BIT,
    [idBecario] VARCHAR(12),
    CONSTRAINT [PK_Ciclo] PRIMARY KEY ([idCiclo])
)
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'A�o que se cursa el ciclo.', 'SCHEMA', N'dbo', 'TABLE', N'Ciclo', 'COLUMN', N'anio'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'N�mero del ciclo.', 'SCHEMA', N'dbo', 'TABLE', N'Ciclo', 'COLUMN', N'nCiclo'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Campo que autoriza al becario para qe puedan realizarse desembolsos el siguiente ciclo.', 'SCHEMA', N'dbo', 'TABLE', N'Ciclo', 'COLUMN', N'evidenciaNotas'
GO


EXECUTE sp_addextendedproperty N'MS_Description', N'Llave for�nea del Becario.', 'SCHEMA', N'dbo', 'TABLE', N'Ciclo', 'COLUMN', N'idBecario'
GO


/* ---------------------------------------------------------------------- */
/* Add table "Nota"                                                       */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Nota] (
    [idNota] INTEGER IDENTITY(1,1) NOT NULL,
    [nombreMateria] VARCHAR(40),
    [nota] DEC(18, 2),
    [cumplioTercio] BIT,
    [idCiclo] INTEGER,
    CONSTRAINT [PK_Nota] PRIMARY KEY ([idNota])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Desembolso"                                                 */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Desembolso] (
    [idDesembolso] INTEGER IDENTITY(1,1) NOT NULL,
    [monto] MONEY,
    [fecha] DATE,
    [idTipoDesembolso] INTEGER,
    [idBecario] VARCHAR(12),
    CONSTRAINT [PK_Desembolso] PRIMARY KEY ([idDesembolso])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "BitacoraIncidentes"                                         */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [BitacoraIncidentes] (
    [idBitacora] INTEGER IDENTITY(1,1) NOT NULL,
    [idTipoIncidente] INTEGER,
    [idBecario] VARCHAR(12),
    CONSTRAINT [PK_BitacoraIncidentes] PRIMARY KEY ([idBitacora])
)
GO


/* ---------------------------------------------------------------------- */
/* Add table "Usuario"                                                    */
/* ---------------------------------------------------------------------- */

GO


CREATE TABLE [Usuario] (
    [idUsuario] char(5) NOT NULL,
    [idInformacion] INTEGER NOT NULL,
    [idTipoUsuario] CHAR(1) NOT NULL,
	[nombreUsuario] VARCHAR(12) NOT NULL,
    [contrasenna] VARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([idUsuario])
)
GO


/* ---------------------------------------------------------------------- */
/* Add foreign key constraints                                            */
/* ---------------------------------------------------------------------- */

GO


ALTER TABLE [Becario] ADD CONSTRAINT [Carrera_Becario] 
    FOREIGN KEY ([idCarrera]) REFERENCES [Carrera] ([idCarrera])
GO


ALTER TABLE [Becario] ADD CONSTRAINT [NivelEducativo_Becario] 
    FOREIGN KEY ([idNivelEducativo]) REFERENCES [NivelEducativo] ([idNivelEducativo])
GO


ALTER TABLE [Becario] ADD CONSTRAINT [ProgramaBecas_Becario] 
    FOREIGN KEY ([idPrograma]) REFERENCES [ProgramaBecas] ([idPrograma])
GO


ALTER TABLE [Becario] ADD CONSTRAINT [InformacionPersonal_Becario] 
    FOREIGN KEY ([idInformacion]) REFERENCES [InformacionPersonal] ([idInformacion])
GO


ALTER TABLE [Becario] ADD CONSTRAINT [Universidad_Becario] 
    FOREIGN KEY ([idUniversidad]) REFERENCES [Universidad] ([idUniversidad])
GO


ALTER TABLE [PresupuestoBecas] ADD CONSTRAINT [Becario_PresupuestoBecas] 
    FOREIGN KEY ([idBecario]) REFERENCES [Becario] ([idBecario])
GO


ALTER TABLE [Ciclo] ADD CONSTRAINT [Becario_Ciclo] 
    FOREIGN KEY ([idBecario]) REFERENCES [Becario] ([idBecario])
GO


ALTER TABLE [Nota] ADD CONSTRAINT [Ciclo_Nota] 
    FOREIGN KEY ([idCiclo]) REFERENCES [Ciclo] ([idCiclo])
GO


ALTER TABLE [Desembolso] ADD CONSTRAINT [TipoDesembolso_Desembolso] 
    FOREIGN KEY ([idTipoDesembolso]) REFERENCES [TipoDesembolso] ([idTipoDesembolso])
GO


ALTER TABLE [Desembolso] ADD CONSTRAINT [Becario_Desembolso] 
    FOREIGN KEY ([idBecario]) REFERENCES [Becario] ([idBecario])
GO


ALTER TABLE [BitacoraIncidentes] ADD CONSTRAINT [Becario_BitacoraIncidentes] 
    FOREIGN KEY ([idBecario]) REFERENCES [Becario] ([idBecario])
GO


ALTER TABLE [BitacoraIncidentes] ADD CONSTRAINT [TipoIncidente_BitacoraIncidentes] 
    FOREIGN KEY ([idTipoIncidente]) REFERENCES [TipoIncidente] ([idTipoIncidente])
GO


ALTER TABLE [Usuario] ADD CONSTRAINT [InformacionPersonal_Usuario] 
    FOREIGN KEY ([idInformacion]) REFERENCES [InformacionPersonal] ([idInformacion])
GO


ALTER TABLE [Usuario] ADD CONSTRAINT [TipoUsuario_Usuario] 
    FOREIGN KEY ([idTipoUsuario]) REFERENCES [TipoUsuario] ([idTipoUsuario])
GO

INSERT INTO [TipoDesembolso] VALUES
('Manutención'),
('Matricula'),
('Colegitura');

INSERT INTO [TipoUsuario] VALUES
('A', 'Administrador'),
('C', 'Contador'),
('G', 'GestorEducativo');
