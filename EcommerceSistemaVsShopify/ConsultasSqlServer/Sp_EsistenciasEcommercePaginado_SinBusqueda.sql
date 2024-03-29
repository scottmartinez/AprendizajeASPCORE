USE [SCM Vision Comercial New]
GO
/****** Object:  StoredProcedure [dbo].[ExistenciasEcommercePaginado]    Script Date: 29/10/2021 05:46:26 P.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[ExistenciasEcommercePaginado]
@NumeroPagina INT,
@TamañoPagina INT
AS
BEGIN
	DECLARE @sqlCommand NVARCHAR(1000)
	SET @sqlCommand=
	'SELECT ee.PLM,
           ee.CodigoProducto,
           ee.NombreProducto,
           ee.Existencia,
           ee.Coleccion,
           ee.Temporada,
           ee.UnidadNegocio,
           ee.Precio_Neto FROM dbo.ExistenciasEcommerce AS ee ORDER BY ee.CodigoProducto  
		   OFFSET '+CONVERT(VARCHAR(10),@TamañoPagina)+' * '+'('+CONVERT(VARCHAR(10),@NumeroPagina)+'-'+'1) ROWS FETCH NEXT '+
		   CONVERT(VARCHAR(10),@TamañoPagina)+' ROWS ONLY OPTION(RECOMPILE);'
		  
		  
		   EXEC sp_executesql @sqlCommand
END
