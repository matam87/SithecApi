-- -------------------------------------------------------------------------------------------------
-- Base de Datos	: SITHEC
-- Módulo			: Examen
-- Objetivo			: Crear una nueva BD
-- -------------------------------------------------------------------------------------------------
IF NOT EXISTS(SELECT * FROM sysdatabases WHERE name = 'SITHEC')
BEGIN
	CREATE DATABASE SITHEC
END