ALTER	 PROC ObtieneCantidadExistencias_Buscar
@Buscar VARCHAR(30)= NULL
AS
BEGIN
SELECT COUNT(ee.CodigoProducto) FROM dbo.ExistenciasEcommerce AS ee
WHERE ee.NombreProducto LIKE '%'+ CASE WHEN @Buscar IS NULL THEN ee.NombreProducto ELSE	@Buscar END	+'%'
OR ee.PLM LIKE '%'+ CASE WHEN @Buscar IS NULL THEN ee.PLM ELSE	@Buscar END	+'%'
OR ee.Coleccion LIKE '%'+ CASE WHEN @Buscar IS NULL THEN ee.Coleccion ELSE	@Buscar END	+'%'
END
GO



'SELECT ee.PLM,
       ee.CodigoProducto,
       ee.NombreProducto,
       ee.Existencia,
       ee.Coleccion,
       ee.Temporada,
       ee.UnidadNegocio,
       ee.Precio_Neto FROM dbo.ExistenciasEcommerce AS ee
WHERE ee.NombreProducto LIKE ''%' + @Buscar +'%''
OR ee.PLM LIKE '%'+ CASE WHEN @Buscar IS NULL THEN ee.PLM ELSE	@Buscar END	+'%''
OR ee.Coleccion LIKE '%'+ CASE WHEN @Buscar IS NULL THEN ee.Coleccion ELSE	@Buscar END	+'%'
