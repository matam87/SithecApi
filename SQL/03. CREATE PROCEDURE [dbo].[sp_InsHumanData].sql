-- -------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_InsHumanData'))
    DROP PROCEDURE [dbo].[sp_InsHumanData]
GO
-- -------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[sp_InsHumanData]
		 @Opc		VARCHAR(3)
		,@Id		INT			
		,@Nombre	VARCHAR(64)		= NULL
		,@Sexo		VARCHAR(1)		= NULL
		,@Altura	DECIMAL(10,2)	= NULL
		,@Peso		INT				= NULL
AS
-- ------------------------------------------------------------------------------------------------- INICIO DE PROCEDIMIENTO
BEGIN
-- ------------------------------------------------------------------------------------------------- INICIO DE PROCEDIMIENTO
-- Base de Datos	: SITHEC
-- Módulo			: Examen
-- Objetivo			: Guardar los registros en la tabla HumanData
--
-- Observaciones	: 
--
-- CNSC	TICKET	AUTOR			FECHA			MODIFICACION
-- -------------------------------------------------------------------------------------------------
-- 0001	000001	Moises Mata		29/Sep/2022		Creacion de SP.
-- -------------------------------------------------------------------------------------------------
SET NOCOUNT ON -- Inhibe el envío de DONE_IN_PROC al cliente

-- -------------------------------------------------------------------------------------------------
-- DECLARACION DE VARIABLES
-- -------------------------------------------------------------------------------------------------
DECLARE @MensajeError VARCHAR(255)	-- Mensaje de Error
	,   @NumError     INT			-- Número de Error
	,   @RowCount     INT			-- @@ROWCOUNT

IF (UPPER(@Opc) = 'INS')
BEGIN
	INSERT INTO dbo.HumanData
	(
		 Id
		,Nombre
		,Sexo
		,Altura
		,Peso
	)
	VALUES
	(
		 @Id
		,@Nombre
		,@Sexo
		,@Altura
		,@Peso
	);
END

IF (UPPER(@Opc) = 'UPD')
BEGIN
	UPDATE hd
		SET hd.Nombre = @Nombre
		FROM dbo.HumanData hd
		WHERE hd.Id = @Id
			AND hd.Nombre <> @Nombre;

	UPDATE hd
		SET hd.Sexo = @Sexo
		FROM dbo.HumanData hd
		WHERE hd.Id = @Id
			AND hd.Sexo <> @Sexo;

	UPDATE hd
		SET hd.Altura = @Altura
		FROM dbo.HumanData hd
		WHERE hd.Id = @Id
			AND hd.Altura <> @Altura;

	UPDATE hd
		SET hd.Peso = @Peso
		FROM dbo.HumanData hd
		WHERE hd.Id = @Id
			AND hd.Peso <> @Peso;
END

GOTO FIN
-- -------------------------------------------------------------------------------------------------
ERROR:
-- -------------------------------------------------------------------------------------------------
RAISERROR (@MensajeError, 16, 1)
RETURN 1

-- -------------------------------------------------------------------------------------------------
FIN:
-- -------------------------------------------------------------------------------------------------
RETURN 0

-- ------------------------------------------------------------------------------------------------- FIN DE PROCEDIMIENTO
END
-- ------------------------------------------------------------------------------------------------- FIN DE PROCEDIMIENTO