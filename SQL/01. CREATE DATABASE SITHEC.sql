-- -------------------------------------------------------------------------------------------------
-- Base de Datos	: SITHEC
-- M�dulo			: Examen
-- Objetivo			: Crear una nueva BD
-- -------------------------------------------------------------------------------------------------
IF NOT EXISTS(SELECT * FROM sysdatabases WHERE name = 'SITHEC')
BEGIN
	CREATE DATABASE SITHEC
END