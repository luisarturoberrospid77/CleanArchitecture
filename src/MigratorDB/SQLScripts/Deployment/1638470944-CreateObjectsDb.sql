-- 1638470944-CreateObjectsDb

-- Autor: Olimpo Bonilla Ramírez.
-- Objetivo: Creación de las tablas de Base de Datos.
-- Fecha: 2021-12-02.
-- Comentarios: Refactorización de las tablas de Base de Datos de "PatosaComercial" para el capítulo 8 en adelante.

-- 1. Catálogo de cuentas de usuario.
-------------------------------------
IF OBJECT_ID('dbo.mtUsers') IS NOT NULL
BEGIN
  DROP TRIGGER IF EXISTS dbo.trg_audit_article;
  DROP VIEW IF EXISTS dbo.vwMenuCategories;
  DROP VIEW IF EXISTS dbo.vwMenuSystem;
  DROP TABLE IF EXISTS dbo.mtOrderDetail;
  DROP TABLE IF EXISTS dbo.mtOrders;
  DROP TABLE IF EXISTS dbo.mtStockInventory;
  DROP TABLE IF EXISTS dbo.mtArticles;
  DROP TABLE IF EXISTS dbo.mtSuppliers;
  DROP TABLE IF EXISTS dbo.mtBrands;
  DROP TABLE IF EXISTS dbo.mtStores;
  DROP TABLE IF EXISTS dbo.mtCodeValue;
  DROP TABLE IF EXISTS dbo.mtCodeNamespace;
  DROP TABLE IF EXISTS dbo.mtUsers;

  IF OBJECT_ID('dbo.mtUsers') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtUsers''. >>>';
  ELSE
    PRINT '<<< Las referencias a la tabla ''dbo.mtUsers'' y la tabla ''dbo.mtUsers'' se han eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtUsers
(
  [account_id]              [int]                        IDENTITY(1, 1) NOT NULL,
  [first_name]              [varchar]       (255)        NOT NULL,
  [last_name]               [varchar]       (255)        NOT NULL,
  [username]                [varchar]       (255)        NOT NULL,
  [passwordhash]            [varchar]       (255)        NOT NULL,
  [email]                   [varchar]       (255)        NOT NULL,
  [number_of_attemps]       [int]                        NOT NULL,
  [status_account]          [int]                        NOT NULL,
  [role_id]                 [int]                        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_IdUser]                  PRIMARY KEY CLUSTERED ([account_id]),
  CONSTRAINT                [uq_IdUser]                  UNIQUE NONCLUSTERED ([account_id], [status_account], [role_id])
);
GO

IF OBJECT_ID('dbo.mtUsers') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtUsers'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtUsers''. >>>';

-- 2. Catálogo base de colección de enumeraciones.
--------------------------------------------------
IF OBJECT_ID('dbo.mtCodeNamespace') IS NOT NULL
BEGIN
  DROP TABLE IF EXISTS dbo.mtCodeValue;

  IF OBJECT_ID('dbo.mtCodeNamespace') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtCodeNamespace''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtCodeNamespace'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtCodeNamespace
(
  [codenamespaceid]         [int]                        IDENTITY(1, 1) NOT NULL,
  [name]                    [varchar]       (255)        NOT NULL,
  [list]                    [varchar]       (255)        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_CodeNamespace]           PRIMARY KEY CLUSTERED ([codenamespaceid]),
  CONSTRAINT                [uq_CodeNamespaceName]       UNIQUE NONCLUSTERED ([name]),
  CONSTRAINT                [fk_CodeNamespace1]          FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id])
);
GO

IF OBJECT_ID('dbo.mtCodeNamespace') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtCodeNamespace'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtCodeNamespace''. >>>';

-- 3. Catálogo base de colección de enumeraciones.
--------------------------------------------------
IF OBJECT_ID('dbo.mtCodeValue') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtCodeValue;

  IF OBJECT_ID('dbo.mtCodeValue') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtCodeValue''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtCodeValue'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtCodeValue
(
  [row_id]                  [int]                        IDENTITY(1, 1) NOT NULL,
  [value_id]                [int]                        NOT NULL,
  [codenamespaceid]         [int]                        NOT NULL,
  [description]             [nvarchar]       (100)       NOT NULL,
  [isroot]                  [bit]                        NOT NULL DEFAULT 0,
  [parentid]                [int]                        NOT NULL DEFAULT 0,
  [orderby]                 [int]                        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_CodeValue]               PRIMARY KEY CLUSTERED ([row_id], [value_id]),
  CONSTRAINT                [uq_CodeValue]               UNIQUE NONCLUSTERED ([row_id], [codenamespaceid], [orderby], [value_id]),
  CONSTRAINT                [fk_CodeValue1]              FOREIGN KEY ([codenamespaceid]) REFERENCES mtCodeNamespace([codenamespaceid]),
  CONSTRAINT                [fk_CodeValue2]              FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id])
);
GO

IF OBJECT_ID('dbo.mtCodeValue') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtCodeValue'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtCodeNamespace''. >>>';

-- 4. Catálogo de tiendas o sucursales.
---------------------------------------
IF OBJECT_ID('dbo.mtStores') IS NOT NULL
BEGIN
  DROP TABLE IF EXISTS dbo.mtArticles; DROP TABLE IF EXISTS dbo.mtStores;

  IF OBJECT_ID('dbo.mtStores') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtStores''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtStores'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtStores
(
  [store_id]                [int]                        IDENTITY(0, 1) NOT NULL,
  [name]                    [varchar]       (255)        NOT NULL,
  [address]                 [varchar]       (255)        NOT NULL DEFAULT 0,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_IdStore]                 PRIMARY KEY CLUSTERED ([store_id]),
  CONSTRAINT                [uq_IdStore]                 UNIQUE NONCLUSTERED ([store_id], [account_id_creationdate]),
  CONSTRAINT                [fk_IdStore]                 FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id])
);
GO

IF OBJECT_ID('dbo.mtStores') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtStores'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtStores''. >>>';

-- 5. Catálogo de proveedores de artículos.
-------------------------------------------
IF OBJECT_ID('dbo.mtSuppliers') IS NOT NULL
BEGIN
  DROP TABLE IF EXISTS dbo.mtArticles; DROP TABLE IF EXISTS dbo.mtSuppliers;

  IF OBJECT_ID('dbo.mtSuppliers') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtSuppliers''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtSuppliers'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtSuppliers
(
  [supplier_id]             [int]                        IDENTITY(0, 1) NOT NULL,
  [name]                    [varchar]       (255)        NOT NULL,
  [address]                 [varchar]       (255)        NOT NULL DEFAULT 0,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_IdSupplier]              PRIMARY KEY CLUSTERED ([supplier_id]),
  CONSTRAINT                [uq_IdSupplier]              UNIQUE NONCLUSTERED ([supplier_id], [account_id_creationdate]),
  CONSTRAINT                [fk_IdSupplier]              FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id])
);
GO

IF OBJECT_ID('dbo.mtSuppliers') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtSuppliers'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtSuppliers''. >>>';

-- 6. Catálogo de marcas de artículos.
---------------------------------------
IF OBJECT_ID('dbo.mtBrands') IS NOT NULL
BEGIN
  DROP TABLE IF EXISTS dbo.mtArticles; DROP TABLE IF EXISTS dbo.mtSupplier;

  IF OBJECT_ID('dbo.mtBrands') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtBrands''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtBrands'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtBrands
(
  [brand_id]                [int]                        IDENTITY(0, 1) NOT NULL,
  [name]                    [varchar]       (255)        NOT NULL,
  [supplier_id]             [int]                        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_IdBrand]                 PRIMARY KEY CLUSTERED ([brand_id]),
  CONSTRAINT                [uq_IdBrand]                 UNIQUE NONCLUSTERED ([brand_id], [supplier_id], [account_id_creationdate]),
  CONSTRAINT                [fk_IdBrand1]                FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_IdBrand2]                FOREIGN KEY ([supplier_id]) REFERENCES mtSuppliers([supplier_id])
);

IF OBJECT_ID('dbo.mtBrands') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtBrands'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtBrands''. >>>';

-- 7. Catálogo de artículos.
----------------------------
IF OBJECT_ID('dbo.mtArticles') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtArticles;

  IF OBJECT_ID('dbo.mtArticles') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtArticles''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtArticles'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtArticles
(
  [sku_id]                  [int]                        IDENTITY(1, 1) NOT NULL,
  [name]                    [varchar]       (255)        NOT NULL,
  [description]             [varchar]       (255)        NOT NULL DEFAULT 0,
  [price]                   [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [total_in_vault]          [int]                        NOT NULL DEFAULT 0,
  [departament_id]          [int]                        NOT NULL,
  [producttype_id]          [int]                        NOT NULL,
  [supplier_id]             [int]                        NOT NULL,
  [brand_id]                [int]                        NOT NULL,
  [image_article]           [varchar]       (MAX)        NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_Idarticle]               PRIMARY KEY CLUSTERED (sku_id),
  CONSTRAINT                [uq_Idarticle]               UNIQUE NONCLUSTERED ([sku_id], [departament_id], [producttype_id], [supplier_id], [brand_id]),
  CONSTRAINT                [fk_Idarticle1]              FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_Idarticle2]              FOREIGN KEY ([supplier_id]) REFERENCES mtSuppliers([supplier_id]),
  CONSTRAINT                [fk_Idarticle3]              FOREIGN KEY ([brand_id]) REFERENCES mtBrands([brand_id])
);
GO

IF OBJECT_ID('dbo.mtArticles') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtArticles'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtArticles''. >>>';

-- 8. Catálogo de movimientos de inventario.
--------------------------------------------
IF OBJECT_ID('dbo.mtStockInventory') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtStockInventory;

  IF OBJECT_ID('dbo.mtStockInventory') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtStockInventory''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtStockInventory'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtStockInventory
(
  [id]                      [int]                        IDENTITY(1, 1) NOT NULL,
  [sku_id]                  [int]                        NOT NULL,
  [origin_store_id]         [int]                        NOT NULL,
  [starting_total]          [int]                        NOT NULL DEFAULT 0,
  [price_origin]            [decimal]       (15,2)       NOT NULL,
  [supplier_id]             [int]                        NOT NULL,
  [posting_store_id]        [int]                        NOT NULL,
  [final_total]             [int]                        NOT NULL DEFAULT 0,
  [price_posting]           [decimal]       (15,2)       NOT NULL,
  [movement_status]         [int]                        NOT NULL,
  [comments]                [varchar]       (255)        NOT NULL,
  [year]                    [int]                        NOT NULL,
  [month]                   [int]                        NOT NULL,
  [day]                     [int]                        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_StockInventory]          PRIMARY KEY CLUSTERED ([id], [year], [month], [day]),
  CONSTRAINT                [uq_StockInventory]          UNIQUE NONCLUSTERED ([id], [origin_store_id], [posting_store_id], [movement_status], [year], [month], [day]),
  CONSTRAINT                [fk_StockInventory1]         FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_StockInventory2]         FOREIGN KEY ([sku_id]) REFERENCES mtArticles([sku_id]),
  CONSTRAINT                [fk_StockInventory3]         FOREIGN KEY ([origin_store_id]) REFERENCES mtStores([store_id]),
  CONSTRAINT                [fk_StockInventory4]         FOREIGN KEY ([supplier_id]) REFERENCES mtSuppliers([supplier_id]),
  CONSTRAINT                [fk_StockInventory5]         FOREIGN KEY ([posting_store_id]) REFERENCES mtStores([store_id])
);
GO

IF OBJECT_ID('dbo.mtStockInventory') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtStockInventory'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtStockInventory''. >>>';

-- 9. Catálogo de pedidos (encabezado).
---------------------------------------
IF OBJECT_ID('dbo.mtOrders') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtOrders;

  IF OBJECT_ID('dbo.mtOrders') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtOrders''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtOrders'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtOrders
(
  [order_id]                [int]                        IDENTITY(1, 1) NOT NULL,
  [store_id]                [int]                        NOT NULL,
  [status_order]            [int]                        NOT NULL,
  [type_order]              [int]                        NOT NULL,
  [comments]                [varchar]       (255)        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_OrderHeader]             PRIMARY KEY CLUSTERED ([order_id]),
  CONSTRAINT                [uq_OrderHeader1]            UNIQUE NONCLUSTERED ([order_id], [store_id]),
  CONSTRAINT                [fk_OrderHeader2]            FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_OrderHeader3]            FOREIGN KEY ([store_id]) REFERENCES mtStores([store_id])
);
GO

IF OBJECT_ID('dbo.mtOrders') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtOrders'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtOrders''. >>>';

-- 10. Catálogo de pedidos (detalle).
-------------------------------------
IF OBJECT_ID('dbo.mtOrderDetail') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtOrderDetail;

  IF OBJECT_ID('dbo.mtOrderDetail') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtOrderDetail''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtOrderDetail'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtOrderDetail
(
  [row_id]                  [int]                        IDENTITY(1, 1) NOT NULL,
  [order_id]                [int]                        NOT NULL,
  [sku_id]                  [int]                        NOT NULL,
  [quantity]                [int]                        NOT NULL,
  [price]                   [decimal]       (15,2)       NOT NULL,
  [value_tax]               [decimal]       (15,2)       NOT NULL,
  [total_value]             [decimal]       (15,2)       NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_OrderDetail]             PRIMARY KEY CLUSTERED ([row_id]),
  CONSTRAINT                [uq_OrderDetail]             UNIQUE NONCLUSTERED ([row_id], [order_id]),
  CONSTRAINT                [fk_OrderDetail1]            FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_OrderDetail2]            FOREIGN KEY ([order_id]) REFERENCES mtOrders([order_id]),
  CONSTRAINT                [fk_OrderDetail3]            FOREIGN KEY ([sku_id]) REFERENCES mtArticles([sku_id])
);
GO

IF OBJECT_ID('dbo.mtOrderDetail') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtOrderDetail'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtOrderDetail''. >>>';

-- 11. Vista de opciones de menú.
---------------------------------
IF OBJECT_ID('dbo.vwMenuSystem') IS NOT NULL
BEGIN
  DROP VIEW dbo.vwMenuSystem;

  IF OBJECT_ID('dbo.vwMenuSystem') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.vwMenuSystem''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.vwMenuSystem'' se ha eliminado correctamente. >>>';
END;
GO

CREATE VIEW dbo.vwMenuSystem AS
WITH CTE_vwMenuSystem AS (
  SELECT P1.parentid,
         P1.value_id,
         P1.[description],
         CAST(P1.[description] AS VARCHAR(8000)) AS [breadcrumb],
         0 [level],
         P1.issystemrow,
         P1.isdeleted,
         P1.creationdate,
         P1.account_id_creationdate,
         P1.updatedate,
         P1.account_id_updatedate,
         P1.deletedate,
         P1.account_id_deletedate
    FROM dbo.mtCodeValue P1
   WHERE (P1.isroot = 1) AND (P1.issystemrow = 1) AND (P1.parentid = 0) AND (P1.codenamespaceid = 3)
   UNION ALL
  SELECT P2.parentid,
         P2.value_id,
         P2.[description],
         CONCAT(CAST(C.breadcrumb AS VARCHAR(4000)), ' > ', CAST(P2.[description] AS VARCHAR(4000))),
         C.[level] + 1 [level],
         P2.issystemrow,
         P2.isdeleted,
         P2.creationdate,
         P2.account_id_creationdate,
         P2.updatedate,
         P2.account_id_updatedate,
         P2.deletedate,
         P2.account_id_deletedate
    FROM dbo.mtCodeValue P2
    JOIN CTE_vwMenuSystem AS C ON (P2.parentid = C.value_id) AND (P2.isroot = 1) AND (P2.issystemrow = 1) AND (P2.codenamespaceid = 3)
)
SELECT CAST(ROW_NUMBER() OVER(ORDER BY CTE_vwMenuSystem.[value_id]) AS INT) [id], CTE_vwMenuSystem.* FROM CTE_vwMenuSystem;
GO

IF OBJECT_ID('dbo.vwMenuSystem') IS NOT NULL
  PRINT '<<< El objeto ''dbo.vwMenuSystem'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.vwMenuSystem''. >>>';
GO

-- 12. Vista de categorías.
---------------------------
IF OBJECT_ID('dbo.vwMenuCategories') IS NOT NULL
BEGIN
  DROP VIEW dbo.vwMenuCategories;

  IF OBJECT_ID('dbo.vwMenuCategories') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.vwMenuCategories''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.vwMenuCategories'' se ha eliminado correctamente. >>>';
END;
GO

CREATE VIEW dbo.vwMenuCategories AS
WITH CTE_vwMenuCategories AS (
  SELECT P1.parentid,
         P1.value_id,
         P1.[description],
         CAST(P1.[description] AS VARCHAR(8000)) AS [breadcrumb],
         0 [level],
         P1.issystemrow,
         P1.isdeleted,
         P1.creationdate,
         P1.account_id_creationdate,
         P1.updatedate,
         P1.account_id_updatedate,
         P1.deletedate,
         P1.account_id_deletedate
    FROM dbo.mtCodeValue P1
   WHERE (P1.isroot = 1) AND (P1.issystemrow = 0) AND (P1.parentid = 0) AND (P1.codenamespaceid = 5)
   UNION ALL
  SELECT P2.parentid,
         P2.value_id,
         P2.[description],
         CONCAT(CAST(C.breadcrumb AS VARCHAR(4000)), ' > ', CAST(P2.[description] AS VARCHAR(4000))),
         C.[level] + 1 [level],
         P2.issystemrow,
         P2.isdeleted,
         P2.creationdate,
         P2.account_id_creationdate,
         P2.updatedate,
         P2.account_id_updatedate,
         P2.deletedate,
         P2.account_id_deletedate
    FROM dbo.mtCodeValue P2
    JOIN CTE_vwMenuCategories AS C ON (P2.parentid = C.value_id) AND (P2.isroot = 0) AND (P2.issystemrow = 0) AND (P2.codenamespaceid IN (6))
)
SELECT CAST(ROW_NUMBER() OVER(ORDER BY CTE_vwMenuCategories.[value_id]) AS INT) [id], CTE_vwMenuCategories.* FROM CTE_vwMenuCategories;
GO

IF OBJECT_ID('dbo.vwMenuCategories') IS NOT NULL
  PRINT '<<< El objeto ''dbo.vwMenuCategories'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.vwMenuCategories''. >>>';
GO

-- 13. Creando el trigger de movimiento de artículos.
-----------------------------------------------------
IF OBJECT_ID('dbo.trgAuditArticle') IS NOT NULL
BEGIN
  DROP TRIGGER dbo.trgAuditArticle;

  IF OBJECT_ID('dbo.trgAuditArticle') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.trgAuditArticle''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.trgAuditArticle'' se ha eliminado correctamente. >>>';
END;
GO

CREATE TRIGGER dbo.trg_audit_article ON dbo.mtArticles
AFTER INSERT AS
BEGIN
  SET NOCOUNT ON;

  INSERT INTO [dbo].[mtStockInventory] ([sku_id], [origin_store_id], [starting_total], [price_origin],
                                        [supplier_id], [posting_store_id], [final_total], [price_posting],
                                        [movement_status], [comments], [year], [month], [day],
                                        [issystemrow], [isdeleted], [creationdate], [account_id_creationdate],
                                        [updatedate], [account_id_updatedate], [deletedate],[account_id_deletedate])
  SELECT i.sku_id, 0, i.total_in_vault, i.price, i.supplier_id, 0, 0, 0, 1, 'Alta de artículo', YEAR(GETUTCDATE()), MONTH(GETUTCDATE()), DAY(GETUTCDATE()),
         i.issystemrow, i.isdeleted, i.creationdate, i.account_id_creationdate,
         i.updatedate, i.account_id_updatedate, i.deletedate, i.account_id_updatedate
    FROM inserted i;
  SET NOCOUNT OFF;
END;
GO

IF OBJECT_ID('dbo.trg_audit_article') IS NOT NULL
  PRINT '<<< El objeto ''dbo.trg_audit_article'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.trg_audit_article''. >>>';

-- 1638470944-CreateObjectsDb