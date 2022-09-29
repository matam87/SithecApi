-- -------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_SelHumanData'))
    DROP PROCEDURE [dbo].[sp_SelHumanData]
GO
-- -------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[sp_SelHumanData]
	 @Id		INT = NULL
	,@Nombre	VARCHAR(64) = NULL
AS
-- ------------------------------------------------------------------------------------------------- INICIO DE PROCEDIMIENTO
BEGIN
-- ------------------------------------------------------------------------------------------------- INICIO DE PROCEDIMIENTO
-- Base de Datos	: SITHEC
-- Módulo			: Examen
-- Objetivo			: Buscar los registros en la tabla HumanData
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

SELECT	*
	FROM dbo.HumanData hd
	WHERE ((@Id IS NULL) OR (hd.Id = @Id))
		AND ((@Nombre IS NULL) OR (hd.Nombre LIKE '%' + @Nombre + '%'))


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