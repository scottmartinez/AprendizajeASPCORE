CREATE PROC ExistenciasEcommercePaginado_Buscar
@ordenarpor VARCHAR(30)=NULL,
@buscar VARCHAR(30)=NULL,
@numeropagina INT,
@tamaniopagina INT
AS
BEGIN
DECLARE @comando NVARCHAR(1600)
	IF (@buscar IS NULL)
		BEGIN
--LINK VIDEO https://youtu.be/2S3x6UYrXXQ?t=1944
--DECLARE @ordenarpor VARCHAR(30)='codigoproducto',
--@numeropagina INT =1,
--@tamaniopagina INT =30
	SET @comando='SELECT ee.PLM,
               ee.CodigoProducto,
               ee.NombreProducto,
               ee.Existencia,
               ee.Coleccion,
               ee.Temporada,
               ee.UnidadNegocio,
               ee.Precio_Neto FROM dbo.ExistenciasEcommerce AS ee 
			   ORDER BY '+@ordenarpor+
			   
				' OFFSET '+ CONVERT(VARCHAR(10),@tamaniopagina) +'*'
				+ '('+CONVERT(VARCHAR(10),@numeropagina) +'-'+'1) ROWS FETCH NEXT '
				+ CONVERT(VARCHAR(10),@tamaniopagina) +' ROWS ONLY OPTION (RECOMPILE)'
				--SELECT @comando
				EXEC sp_executesql @comando
		END
	ELSE 
		BEGIN	
--DECLARE @ordenarpor VARCHAR(30)='codigoproducto',
--@numeropagina INT =1,
--@tamaniopagina INT =30,
--@buscar VARCHAR(30)='G11'
--DECLARE @comando NVARCHAR(1600)
		SET @comando='SELECT ee.PLM,
       ee.CodigoProducto,
       ee.NombreProducto,
       ee.Existencia,
       ee.Coleccion,
       ee.Temporada,
       ee.UnidadNegocio,
       ee.Precio_Neto FROM dbo.ExistenciasEcommerce AS ee
	WHERE ee.NombreProducto LIKE ''%' + @buscar+'%''
	 OR ee.PLM LIKE ''%'+@buscar+'%''
	 OR ee.COLECCION LIKE ''%'+@buscar+'%''  Order by '+@ordenarpor
	+ ' OFFSET '+ CONVERT(VARCHAR(10),@tamaniopagina) +'*'
	+ '('+ CONVERT(VARCHAR(10),@numeropagina)+'-'+ '1) ROWS FETCH NEXT ' 
	+ CONVERT(VARCHAR(10),@tamaniopagina)+' ROWS ONLY OPTION (RECOMPILE);';
	--SELECT @comando
	EXEC sp_executesql @comando
		END
END

