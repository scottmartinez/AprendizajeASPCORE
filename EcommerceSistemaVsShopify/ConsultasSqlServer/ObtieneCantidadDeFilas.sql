USE [SCM Vision Comercial New]
GO
/****** Object:  StoredProcedure [dbo].[ObtenerExistenciasConteo]    Script Date: 29/10/2021 05:47:10 P.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[ObtenerExistenciasConteo]
AS
BEGIN
SELECT COUNT(ee.CodigoProducto) FROM dbo.ExistenciasEcommerce AS ee
END
