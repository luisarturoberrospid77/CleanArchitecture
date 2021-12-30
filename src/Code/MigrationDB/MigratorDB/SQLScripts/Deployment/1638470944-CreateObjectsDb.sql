-- 1638470944-CreateObjectsDb

-- Autor: Olimpo Bonilla Ramírez.
-- Objetivo: Creación de las tablas de Base de Datos.
-- Fecha: 2021-12-02.
-- Comentarios: Refactorización de las tablas de Base de Datos de "PatosaComercial" para el capítulo 8 en adelante.

-- 1. Catálogo de cuentas de usuario.
-------------------------------------
IF OBJECT_ID('dbo.mtUsers') IS NOT NULL
BEGIN
  DROP TRIGGER IF EXISTS dbo.trgOnUpdateArticleInStock;
  DROP TRIGGER IF EXISTS dbo.trgOnAddArticleInStock;
  DROP VIEW IF EXISTS dbo.vwMovementArticles;
  DROP VIEW IF EXISTS dbo.vwMenuCategories;
  DROP VIEW IF EXISTS dbo.vwMenuSystem;
  DROP TABLE IF EXISTS dbo.mtOrderDetail;
  DROP TABLE IF EXISTS dbo.mtOrders;
  DROP TABLE IF EXISTS dbo.mtCustomers;
  DROP TABLE IF EXISTS dbo.mtItemMovement;
  DROP TABLE IF EXISTS dbo.mtStockArticles;
  DROP TABLE IF EXISTS dbo.mtAssignmentDetail;
  DROP TABLE IF EXISTS dbo.mtAssignments;
  DROP TABLE IF EXISTS dbo.mtPurchaseDetail;
  DROP TABLE IF EXISTS dbo.mtPurchases;
  DROP TABLE IF EXISTS dbo.mtArticles;
  DROP TABLE IF EXISTS dbo.mtBrands;
  DROP TABLE IF EXISTS dbo.mtSuppliers;
  DROP TABLE IF EXISTS dbo.mtStores;
  DROP TABLE IF EXISTS dbo.mtCodeValues;
  DROP TABLE IF EXISTS dbo.mtCodeNamespaces;
  DROP TABLE IF EXISTS dbo.mtCountriesDetail;
  DROP TABLE IF EXISTS dbo.mtCountries;
  DROP TABLE IF EXISTS dbo.mtUsers;

  IF OBJECT_ID('dbo.mtUsers') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtUsers''. >>>';
  ELSE
    PRINT '<<< Las referencias a la tabla ''dbo.mtUsers'' y la tabla ''dbo.mtUsers'' se han eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtUsers
(
  [account_id]              [int]                        IDENTITY(0, 1) NOT NULL,
  [first_name]              [varchar]       (255)        NOT NULL,
  [last_name]               [varchar]       (255)        NOT NULL,
  [username]                [varchar]       (255)        NOT NULL,
  [passwordhash]            [varchar]       (255)        NOT NULL,
  [email]                   [varchar]       (255)        NOT NULL,
  [number_phone]            [varchar]       (50)         NOT NULL,
  [adress]                  [varchar]       (255)        NOT NULL,
  [postal_code]             [int]                        NOT NULL,
  [country_code]            [int]                        NOT NULL,
  [federal_entity_code]     [int]                        NOT NULL,
  [municipality_code]       [int]                        NOT NULL,
  [neighborhood_code]       [int]                        NOT NULL,
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

-- 2. Catálogo base de colección de países del mundo.
-----------------------------------------------------
IF OBJECT_ID('dbo.mtCountries') IS NOT NULL
BEGIN
  DROP TABLE IF EXISTS dbo.mtCountries;

  IF OBJECT_ID('dbo.mtCountries') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtCountries''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtCountries'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE [dbo].[mtCountries]
(
  [country_code]            [int]                        IDENTITY(0, 1) NOT NULL,
  [iso]                     [char]          (255)        NOT NULL,
  [name_country]            [varchar]       (255)        NOT NULL,
  [nicename]                [varchar]       (255)        NOT NULL,
  [iso3]                    [char]          (3)          NULL,
  [numcode]                 [smallint]                   NULL,
  [phonecode]               [int]                        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_IdCountry]               PRIMARY KEY CLUSTERED ([country_code]),
  CONSTRAINT                [uq_IdCountry]               UNIQUE NONCLUSTERED ([country_code], [iso], [name_country], [nicename], [iso3], [numcode], [phonecode]),
  CONSTRAINT                [fk_IdCountry1]              FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id])
);
GO

IF OBJECT_ID('dbo.mtCountries') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtCountries'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtCountries''. >>>';

-- 3. Catálogo base de colección de detalle de países del mundo.
----------------------------------------------------------------
IF OBJECT_ID('dbo.mtCountriesDetail') IS NOT NULL
BEGIN
  DROP TABLE IF EXISTS dbo.mtCountriesDetail;

  IF OBJECT_ID('dbo.mtCountriesDetail') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtCountriesDetail''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtCountriesDetail'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE [dbo].[mtCountriesDetail]
(
  [postalcode_id]           [int]                        IDENTITY(0, 1) NOT NULL,
  [country_code]            [int]                        NOT NULL,
  [federal_entity_code]     [int]                        NOT NULL,
  [federal_entity_name]     [varchar]       (255)        NOT NULL,
  [municipality_code]       [int]                        NOT NULL,
  [municipality_name]       [varchar]       (255)        NOT NULL,
  [city_name]               [varchar]       (255)        NULL,
  [zone_name]               [varchar]       (255)        NOT NULL,
  [postal_code]             [int]                        NOT NULL,
  [township_id]             [int]                        NOT NULL,
  [township_name]           [varchar]       (255)        NOT NULL,
  [township_type_id]        [int]                        NOT NULL,
  [township_type_name]      [varchar]       (255)        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_IdPostalCode]            PRIMARY KEY CLUSTERED ([postalcode_id], [country_code], [federal_entity_code], [municipality_code], [postal_code], [township_id], [township_type_id]),
  CONSTRAINT                [uq_IdPostalCode]            UNIQUE NONCLUSTERED ([postalcode_id], [country_code], [federal_entity_code], [municipality_code], [postal_code], [township_id], [township_type_id]),
  CONSTRAINT                [fk_IdPostalCode1]           FOREIGN KEY ([country_code]) REFERENCES mtCountries([country_code]),
  CONSTRAINT                [fk_IdPostalCode2]           FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id])
);
GO

IF OBJECT_ID('dbo.mtCountriesDetail') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtCountriesDetail'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtCountriesDetail''. >>>';

-- 4. Catálogo base de colección de enumeraciones.
--------------------------------------------------
IF OBJECT_ID('dbo.mtCodeNamespaces') IS NOT NULL
BEGIN
  DROP TABLE IF EXISTS dbo.mtCodeValues;

  IF OBJECT_ID('dbo.mtCodeNamespaces') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtCodeNamespaces''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtCodeNamespaces'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtCodeNamespaces
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

IF OBJECT_ID('dbo.mtCodeNamespaces') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtCodeNamespaces'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtCodeNamespaces''. >>>';

-- 5. Catálogo base de colección de enumeraciones.
--------------------------------------------------
IF OBJECT_ID('dbo.mtCodeValues') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtCodeValues;

  IF OBJECT_ID('dbo.mtCodeValues') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtCodeValues''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtCodeValues'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtCodeValues
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
  CONSTRAINT                [fk_CodeValue1]              FOREIGN KEY ([codenamespaceid]) REFERENCES mtCodeNamespaces([codenamespaceid]),
  CONSTRAINT                [fk_CodeValue2]              FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id])
);
GO

IF OBJECT_ID('dbo.mtCodeValues') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtCodeValues'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtCodeNamespaces''. >>>';

-- 6. Catálogo de tiendas o sucursales.
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
  [number_phone]            [varchar]       (50)         NOT NULL,
  [postal_code]             [int]                        NOT NULL,
  [country_code]            [int]                        NOT NULL,
  [federal_entity_code]     [int]                        NOT NULL,
  [municipality_code]       [int]                        NOT NULL,
  [neighborhood_code]       [int]                        NOT NULL,
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
  CONSTRAINT                [fk_IdStore1]                FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id])
);
GO

IF OBJECT_ID('dbo.mtStores') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtStores'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtStores''. >>>';

-- 7. Catálogo de proveedores de artículos.
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
  [email]                   [varchar]       (255)        NOT NULL,
  [number_phone]            [varchar]       (50)         NOT NULL,
  [postal_code]             [int]                        NOT NULL,
  [country_code]            [int]                        NOT NULL,
  [federal_entity_code]     [int]                        NOT NULL,
  [municipality_code]       [int]                        NOT NULL,
  [neighborhood_code]       [int]                        NOT NULL,
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
  CONSTRAINT                [fk_IdSupplier1]             FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id])
);
GO

IF OBJECT_ID('dbo.mtSuppliers') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtSuppliers'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtSuppliers''. >>>';

-- 8. Catálogo de marcas de artículos.
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
GO

IF OBJECT_ID('dbo.mtBrands') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtBrands'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtBrands''. >>>';

-- 9. Catálogo de clientes.
---------------------------
IF OBJECT_ID('dbo.mtCustomers') IS NOT NULL
BEGIN
  DROP TABLE IF EXISTS dbo.mtOrders; DROP TABLE IF EXISTS dbo.mtCustomers;

  IF OBJECT_ID('dbo.mtCustomers') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtCustomers''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtCustomers'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtCustomers
(
  [customer_id]             [int]                        IDENTITY(0, 1) NOT NULL,
  [first_name]              [varchar]       (255)        NOT NULL,
  [last_name]               [varchar]       (255)        NOT NULL,
  [address]                 [varchar]       (255)        NOT NULL DEFAULT 0,
  [email]                   [varchar]       (255)        NOT NULL,
  [curp_code]               [varchar]       (50)         NULL,
  [rfc_code]                [varchar]       (50)         NULL,
  [number_phone]            [varchar]       (50)         NOT NULL,
  [postal_code]             [int]                        NOT NULL,
  [country_code]            [int]                        NOT NULL,
  [federal_entity_code]     [int]                        NOT NULL,
  [municipality_code]       [int]                        NOT NULL,
  [neighborhood_code]       [int]                        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_IdCustomer]              PRIMARY KEY CLUSTERED ([customer_id]),
  CONSTRAINT                [uq_IdCustomer]              UNIQUE NONCLUSTERED ([customer_id], [account_id_creationdate]),
  CONSTRAINT                [fk_IdCustomer1]             FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id])
);
GO

IF OBJECT_ID('dbo.mtCustomers') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtCustomers'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtCustomers''. >>>';

-- 10. Catálogo de artículos.
-----------------------------
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
  [short_name]              [varchar]       (255)        NOT NULL,
  [description]             [varchar]       (255)        NOT NULL DEFAULT 0,
  [total_in_vault]          [int]                        NOT NULL DEFAULT 0,
  [purchase_price]          [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [sale_price]              [decimal]       (15,2)       NOT NULL DEFAULT 0,
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

-- 11. Catálogo de compras de proveedor de artículos (encabezado).
------------------------------------------------------------------
IF OBJECT_ID('dbo.mtPurchases') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtPurchases;

  IF OBJECT_ID('dbo.mtPurchases') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtPurchases''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtPurchases'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtPurchases
(
  [purchase_id]             [int]                        IDENTITY(1, 1) NOT NULL,
  [supplier_id]             [int]                        NOT NULL,
  [quantity]                [int]                        NOT NULL DEFAULT 0,
  [purchase_sub_total]      [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [purchase_tax]            [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [purchase_grand_total]    [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [comments]                [varchar]       (255)        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_PurchaseHeader]          PRIMARY KEY CLUSTERED ([purchase_id]),
  CONSTRAINT                [uq_PurchaseHeader]          UNIQUE NONCLUSTERED ([purchase_id], [supplier_id]),
  CONSTRAINT                [fk_PurchaseHeader1]         FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_PurchaseHeader2]         FOREIGN KEY ([supplier_id]) REFERENCES mtSuppliers([supplier_id])
);
GO

IF OBJECT_ID('dbo.mtPurchases') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtPurchases'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtPurchases''. >>>';

-- 12. Catálogo de compras de proveedor de artículos (detalle).
---------------------------------------------------------------
IF OBJECT_ID('dbo.mtPurchaseDetail') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtPurchaseDetail;

  IF OBJECT_ID('dbo.mtPurchaseDetail') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtPurchaseDetail''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtPurchaseDetail'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtPurchaseDetail
(
  [row_id]                  [int]                        NOT NULL,
  [purchase_id]             [int]                        NOT NULL,
  [sku_id]                  [int]                        NOT NULL,
  [quantity]                [int]                        NOT NULL,
  [purchase_price]          [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [purchase_sub_total]      [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [purchase_tax]            [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [purchase_grand_total]    [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [sale_price]              [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_PurchaseDetail]          PRIMARY KEY CLUSTERED ([row_id], [purchase_id], [sku_id]),
  CONSTRAINT                [uq_PurchaseDetail]          UNIQUE NONCLUSTERED ([row_id], [purchase_id], [sku_id]),
  CONSTRAINT                [fk_PurchaseDetail1]         FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_PurchaseDetail2]         FOREIGN KEY ([sku_id]) REFERENCES mtArticles([sku_id]),
  CONSTRAINT                [fk_PurchaseDetail3]         FOREIGN KEY ([purchase_id]) REFERENCES mtPurchases([purchase_id])
);
GO

IF OBJECT_ID('dbo.mtPurchaseDetail') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtPurchaseDetail'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtPurchaseDetail''. >>>';

-- 13. Catálogo de compras de movimientos de artículos a sucursal (encabezado).
-------------------------------------------------------------------------------
IF OBJECT_ID('dbo.mtAssignments') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtAssignments;

  IF OBJECT_ID('dbo.mtAssignments') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtAssignments''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtAssignments'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtAssignments
(
  [assignment_id]           [int]                        IDENTITY(1, 1) NOT NULL,
  [store_id]                [int]                        NOT NULL,
  [quantity]                [int]                        NOT NULL DEFAULT 0,
  [purchase_sub_total]      [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [purchase_tax]            [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [purchase_grand_total]    [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [comments]                [varchar]       (255)        NOT NULL,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_AssignmentHead]          PRIMARY KEY CLUSTERED ([assignment_id]),
  CONSTRAINT                [uq_AssignmentHead]          UNIQUE NONCLUSTERED ([assignment_id], [store_id]),
  CONSTRAINT                [fk_AssignmentHead1]         FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_AssignmentHead2]         FOREIGN KEY ([store_id]) REFERENCES mtStores([store_id])
);
GO

IF OBJECT_ID('dbo.mtAssignments') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtAssignments'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtAssignments''. >>>';

-- 14. Catálogo de compras de movimientos de artículos a sucursal (detalle).
----------------------------------------------------------------------------
IF OBJECT_ID('dbo.mtAssignmentDetail') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtAssignmentDetail;

  IF OBJECT_ID('dbo.mtAssignmentDetail') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtAssignmentDetail''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtAssignmentDetail'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtAssignmentDetail
(
  [row_id]                  [int]                        NOT NULL,
  [assignment_id]           [int]                        NOT NULL,
  [sku_id]                  [int]                        NOT NULL,
  [quantity]                [int]                        NOT NULL,
  [purchase_price]          [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [purchase_sub_total]      [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [purchase_tax]            [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [purchase_grand_total]    [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [sale_price]              [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_AssignmentDetail]        PRIMARY KEY CLUSTERED ([row_id], [assignment_id], [sku_id]),
  CONSTRAINT                [uq_AssignmentDetail]        UNIQUE NONCLUSTERED ([row_id], [assignment_id], [sku_id]),
  CONSTRAINT                [fk_AssignmentDetail1]       FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_AssignmentDetail2]       FOREIGN KEY ([sku_id]) REFERENCES mtArticles([sku_id]),
  CONSTRAINT                [fk_AssignmentDetail3]       FOREIGN KEY ([assignment_id]) REFERENCES mtAssignments([assignment_id])
);
GO

IF OBJECT_ID('dbo.mtAssignmentDetail') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtAssignmentDetail'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtAssignmentDetail''. >>>';

-- 15. Catálogo de stock de artículos.
--------------------------------------
IF OBJECT_ID('dbo.mtStockArticles') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtStockArticles;

  IF OBJECT_ID('dbo.mtStockArticles') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtStockArticles''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtStockArticles'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtStockArticles
(
  [id]                      [int]                        IDENTITY(1, 1) NOT NULL,
  [sku_id]                  [int]                        NOT NULL,
  [store_id]                [int]                        NOT NULL,
  [item_input_quantity]     [int]                        NOT NULL,
  [item_output_quantity]    [int]                        NOT NULL,
  [purchase_price]          [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [sale_price]              [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_StockArticle]            PRIMARY KEY CLUSTERED ([id], [sku_id], [store_id]),
  CONSTRAINT                [uq_StockArticle]            UNIQUE NONCLUSTERED ([id], [sku_id], [store_id]),
  CONSTRAINT                [fk_StockArticle1]           FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_StockArticle2]           FOREIGN KEY ([sku_id]) REFERENCES mtArticles([sku_id]),
  CONSTRAINT                [fk_StockArticle3]           FOREIGN KEY ([store_id]) REFERENCES mtStores([store_id])
);
GO

IF OBJECT_ID('dbo.mtStockArticles') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtStockArticles'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtStockArticles''. >>>';

-- 16. Catálogo de movimientos de inventario.
---------------------------------------------
IF OBJECT_ID('dbo.mtItemMovement') IS NOT NULL
BEGIN
  DROP TABLE dbo.mtItemMovement;

  IF OBJECT_ID('dbo.mtItemMovement') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.mtItemMovement''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.mtItemMovement'' se ha eliminado correctamente. >>>';
END;

CREATE TABLE dbo.mtItemMovement
(
  [id]                      [int]                        IDENTITY(1, 1) NOT NULL,
  [sku_id]                  [int]                        NOT NULL,
  [origin_store_id]         [int]                        NOT NULL,
  [starting_total]          [int]                        NOT NULL DEFAULT 0,
  [supplier_id]             [int]                        NOT NULL,
  [posting_store_id]        [int]                        NOT NULL,
  [final_total]             [int]                        NOT NULL DEFAULT 0,
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
  CONSTRAINT                [pk_ItemMovement]            PRIMARY KEY CLUSTERED ([id], [year], [month], [day]),
  CONSTRAINT                [uq_ItemMovement]            UNIQUE NONCLUSTERED ([id], [origin_store_id], [posting_store_id], [movement_status], [year], [month], [day]),
  CONSTRAINT                [fk_ItemMovement1]           FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_ItemMovement2]           FOREIGN KEY ([sku_id]) REFERENCES mtArticles([sku_id]),
  CONSTRAINT                [fk_ItemMovement3]           FOREIGN KEY ([origin_store_id]) REFERENCES mtStores([store_id]),
  CONSTRAINT                [fk_ItemMovement4]           FOREIGN KEY ([supplier_id]) REFERENCES mtSuppliers([supplier_id]),
  CONSTRAINT                [fk_ItemMovement5]           FOREIGN KEY ([posting_store_id]) REFERENCES mtStores([store_id])
);
GO

IF OBJECT_ID('dbo.mtItemMovement') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtItemMovement'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtItemMovement''. >>>';

-- 17. Catálogo de pedidos (encabezado).
----------------------------------------
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
  [customer_id]             [int]                        NOT NULL,
  [store_id]                [int]                        NOT NULL,
  [status_order]            [int]                        NOT NULL,
  [type_order]              [int]                        NOT NULL,
  [quantity]                [int]                        NOT NULL,
  [sale_price]              [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [sale_sub_total]          [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [sale_tax]                [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [sale_grand_total]        [decimal]       (15,2)       NOT NULL DEFAULT 0,
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
  CONSTRAINT                [uq_OrderHeader1]            UNIQUE NONCLUSTERED ([order_id], [store_id], [customer_id]),
  CONSTRAINT                [fk_OrderHeader2]            FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_OrderHeader3]            FOREIGN KEY ([store_id]) REFERENCES mtStores([store_id]),
  CONSTRAINT                [fk_OrderHeader4]            FOREIGN KEY ([customer_id]) REFERENCES mtCustomers([customer_id])
);
GO

IF OBJECT_ID('dbo.mtOrders') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtOrders'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtOrders''. >>>';

-- 18. Catálogo de pedidos (detalle).
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
  [row_id]                  [int]                        NOT NULL,
  [order_id]                [int]                        NOT NULL,
  [sku_id]                  [int]                        NOT NULL,
  [quantity]                [int]                        NOT NULL,
  [sale_price]              [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [sale_sub_total]          [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [sale_tax]                [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [sale_grand_total]        [decimal]       (15,2)       NOT NULL DEFAULT 0,
  [issystemrow]             [bit]                        NOT NULL DEFAULT 1,
  [isdeleted]               [bit]                        NOT NULL DEFAULT 0,
  [creationdate]            [datetime]                   NOT NULL DEFAULT GETUTCDATE(),
  [account_id_creationdate] [int]                        NOT NULL,
  [updatedate]              [datetime]                   NULL,
  [account_id_updatedate]   [int]                        NULL,
  [deletedate]              [datetime]                   NULL,
  [account_id_deletedate]   [int]                        NULL,
  CONSTRAINT                [pk_OrderDetail]             PRIMARY KEY CLUSTERED ([row_id], [order_id], [sku_id]),
  CONSTRAINT                [uq_OrderDetail]             UNIQUE NONCLUSTERED ([row_id], [order_id], [sku_id]),
  CONSTRAINT                [fk_OrderDetail1]            FOREIGN KEY ([account_id_creationdate]) REFERENCES mtUsers([account_id]),
  CONSTRAINT                [fk_OrderDetail2]            FOREIGN KEY ([order_id]) REFERENCES mtOrders([order_id]),
  CONSTRAINT                [fk_OrderDetail3]            FOREIGN KEY ([sku_id]) REFERENCES mtArticles([sku_id])
);
GO

IF OBJECT_ID('dbo.mtOrderDetail') IS NOT NULL
  PRINT '<<< El objeto ''dbo.mtOrderDetail'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.mtOrderDetail''. >>>';

-- 19. Vista de opciones de menú.
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
    FROM dbo.mtCodeValues P1
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
    FROM dbo.mtCodeValues P2
    JOIN CTE_vwMenuSystem AS C ON (P2.parentid = C.value_id) AND (P2.isroot = 1) AND (P2.issystemrow = 1) AND (P2.codenamespaceid = 3)
)
SELECT CAST(ROW_NUMBER() OVER(ORDER BY CTE_vwMenuSystem.[value_id]) AS INT) [id], CTE_vwMenuSystem.* FROM CTE_vwMenuSystem;
GO

IF OBJECT_ID('dbo.vwMenuSystem') IS NOT NULL
  PRINT '<<< El objeto ''dbo.vwMenuSystem'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.vwMenuSystem''. >>>';
GO

-- 20. Vista de categorías.
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
    FROM dbo.mtCodeValues P1
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
    FROM dbo.mtCodeValues P2
    JOIN CTE_vwMenuCategories AS C ON (P2.parentid = C.value_id) AND (P2.isroot = 0) AND (P2.issystemrow = 0) AND (P2.codenamespaceid IN (6))
)
SELECT CAST(ROW_NUMBER() OVER(ORDER BY CTE_vwMenuCategories.[value_id]) AS INT) [id], CTE_vwMenuCategories.* FROM CTE_vwMenuCategories;
GO

IF OBJECT_ID('dbo.vwMenuCategories') IS NOT NULL
  PRINT '<<< El objeto ''dbo.vwMenuCategories'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.vwMenuCategories''. >>>';
GO

-- 21. Vista de stock de artículos.
-----------------------------------
IF OBJECT_ID('dbo.vwStockArticles') IS NOT NULL
BEGIN
  DROP VIEW dbo.vwStockArticles;

  IF OBJECT_ID('dbo.vwStockArticles') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.vwStockArticles''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.vwStockArticles'' se ha eliminado correctamente. >>>';
END;
GO

CREATE VIEW dbo.vwStockArticles AS
SELECT t1.id,
       t1.sku_id,
       t2.[short_name] as [article_short_name],
       t2.[description],
       t2.supplier_id,
       t3.[name] as [supplier_name],
       t2.brand_id,
       t4.[name] as [brand_name],
       t2.departament_id,
       t5.[description] as [department_name],
       t2.producttype_id,
       t6.[description] as [producttype_name],
       t1.store_id,
       t7.[name] as [store_name],
       t1.item_input_quantity,
       t1.item_output_quantity,
       t1.purchase_price,
       t1.sale_price,
       t1.issystemrow,
       t1.isdeleted,
       t1.creationdate,
       t1.account_id_creationdate,
       t1.updatedate,
       t1.account_id_updatedate,
       t1.deletedate,
       t1.account_id_deletedate
  FROM dbo.mtStockArticles t1
 INNER JOIN dbo.mtArticles t2 ON (t1.sku_id = t2.sku_id)
 INNER JOIN dbo.mtSuppliers t3 ON (t2.supplier_id = t3.supplier_id)
 INNER JOIN dbo.mtBrands t4 ON (t2.brand_id = t4.brand_id)
 INNER JOIN dbo.mtCodeValues t5 ON (t2.departament_id = t5.value_id) and (t5.codenamespaceid = 5)
 INNER JOIN dbo.mtCodeValues t6 ON (t2.producttype_id = t6.value_id) and (t6.codenamespaceid = 6)
 INNER JOIN dbo.mtStores t7 ON (t1.store_id = t7.store_id)
 WHERE (t1.isdeleted = 0);
GO

IF OBJECT_ID('dbo.vwStockArticles') IS NOT NULL
  PRINT '<<< El objeto ''dbo.vwStockArticles'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.vwStockArticles''. >>>';
GO

-- 22. Vista de movimientos de almacen.
---------------------------------------
IF OBJECT_ID('dbo.vwMovementArticles') IS NOT NULL
BEGIN
  DROP VIEW dbo.vwMovementArticles;

  IF OBJECT_ID('dbo.vwMovementArticles') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.vwMovementArticles''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.vwMovementArticles'' se ha eliminado correctamente. >>>';
END;
GO

CREATE VIEW dbo.vwMovementArticles AS
SELECT t1.Id,
       t1.sku_id,
       t2.[short_name] as [article_short_name],
       t2.[description],
       t1.origin_store_id,
       t3.[name] as [origin_store_name],
       t1.starting_total,
       t1.supplier_id,
       t4.[name] as [supplier_name],
       t1.posting_store_id,
       t5.[name] as [posting_store_name],
       t1.final_total,
       t1.movement_status,
       t6.[description] as [description_movement],
       t1.comments,
       t1.year,
       t1.month,
       t1.day,
       t1.issystemrow,
       t1.isdeleted,
       t1.creationdate,
       t1.account_id_creationdate,
       t1.updatedate,
       t1.account_id_updatedate,
       t1.deletedate,
       t1.account_id_deletedate
  FROM dbo.mtItemMovement t1
 INNER JOIN dbo.mtArticles t2 ON (t1.sku_id = t2.sku_id)
 INNER JOIN dbo.mtStores t3 ON (t1.origin_store_id = t3.store_id)
 INNER JOIN dbo.mtSuppliers t4 ON (t1.supplier_id = t4.supplier_id)
 INNER JOIN dbo.mtStores t5 ON (t1.posting_store_id = t5.store_id)
 INNER JOIN dbo.mtCodeValues t6 ON (t1.movement_status = t6.value_id) AND (t6.codenamespaceid = 4)
 WHERE (t1.isdeleted = 0);
GO

IF OBJECT_ID('dbo.vwMovementArticles') IS NOT NULL
  PRINT '<<< El objeto ''dbo.vwMovementArticles'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.vwMovementArticles''. >>>';
GO

-- 23. Creando el trigger de movimiento de artículos.
-----------------------------------------------------
IF OBJECT_ID('dbo.trgOnAddArticleInStock') IS NOT NULL
BEGIN
  DROP TRIGGER dbo.trgOnAddArticleInStock;

  IF OBJECT_ID('dbo.trgOnAddArticleInStock') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.trgOnAddArticleInStock''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.trgOnAddArticleInStock'' se ha eliminado correctamente. >>>';
END;
GO

CREATE TRIGGER dbo.trg_audit_article ON dbo.mtArticles
AFTER INSERT AS
BEGIN
  SET NOCOUNT ON;

  /* Se inserta en el stock de movimientos de artículo. */
  INSERT INTO [dbo].[mtStockArticles] ([sku_id], [store_id], [item_input_quantity], [item_output_quantity], [purchase_price], [sale_price],
                                       [issystemrow], [isdeleted], [creationdate], [account_id_creationdate],
                                       [updatedate], [account_id_updatedate], [deletedate],[account_id_deletedate])
  SELECT i.sku_id, 0, i.total_in_vault, 0, i.purchase_price, i.sale_price,
         i.issystemrow, i.isdeleted, i.creationdate, i.account_id_creationdate,
         i.updatedate, i.account_id_updatedate, i.deletedate, i.account_id_updatedate
    FROM inserted i;

  /* Se inserta al catálogo de movimientos de artículo. */
  INSERT INTO [dbo].[mtItemMovement] ([sku_id], [origin_store_id], [starting_total], [supplier_id],
                                      [posting_store_id], [final_total], [movement_status], [comments],
                                      [year], [month], [day], [issystemrow], [isdeleted], [creationdate],
                                      [account_id_creationdate], [updatedate], [account_id_updatedate],
                                      [deletedate], [account_id_deletedate])
  SELECT i.sku_id, 0, 0, i.supplier_id, 0, 0, 1, 'Alta de artículo en el sistema.',
         YEAR(GETUTCDATE()), MONTH(GETUTCDATE()), DAY(GETUTCDATE()),
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

-- 24. Creando el trigger de movimiento de artículos.
-----------------------------------------------------
IF OBJECT_ID('dbo.trgOnUpdateArticleInStock') IS NOT NULL
BEGIN
  DROP TRIGGER dbo.trgOnUpdateArticleInStock;

  IF OBJECT_ID('dbo.trgOnUpdateArticleInStock') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.trgOnUpdateArticleInStock''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.trgOnUpdateArticleInStock'' se ha eliminado correctamente. >>>';
END;
GO

CREATE TRIGGER dbo.trgOnUpdateArticleInStock ON dbo.mtPurchaseDetail
AFTER INSERT AS
BEGIN
  DECLARE @supplier_id int;
  DECLARE @item_input_quantity int;

  SET NOCOUNT ON;
  
  /* Cargo el identificador del artículo. */
  SELECT @item_input_quantity = j.item_input_quantity
    FROM dbo.mtStockArticles j
   INNER JOIN inserted i ON (j.sku_id = i.sku_id);

  /* Busco el proveedor del artículo previamente cargado. */
  SELECT @supplier_id = t1.supplier_id
    FROM dbo.mtArticles t1
   WHERE (t1.sku_id IN (SELECT i.sku_id FROM inserted i))
     AND (t1.isdeleted = 0);   

  /* Actualizo el stock del inventario. */
  UPDATE m
     SET m.[item_input_quantity] = (m.[item_input_quantity] + i.quantity),
         m.[item_output_quantity] = 0,
         m.[purchase_price] = i.purchase_price,
         m.[sale_price] = i.sale_price,
         m.[account_id_updatedate] = i.account_id_creationdate,
         m.[updatedate] = i.creationdate
    FROM dbo.mtStockArticles m
   INNER JOIN inserted i ON (m.sku_id = i.sku_id);

  /* Actualizo el movimiento del artículo existente. */
  UPDATE m
     SET m.[total_in_vault] = (@item_input_quantity + i.quantity),
         m.[purchase_price] = i.purchase_price,
         m.[sale_price] = i.sale_price,
         m.[account_id_updatedate] = i.account_id_creationdate,
         m.[updatedate] = i.creationdate
    FROM dbo.mtArticles m
   INNER JOIN inserted i ON (m.sku_id = i.sku_id);

  /* Se inserta al catálogo de movimientos de artículo. */
  INSERT INTO [dbo].[mtItemMovement] ([sku_id], [origin_store_id], [starting_total], [supplier_id],
                                      [posting_store_id], [final_total], [movement_status], [comments],
                                      [year], [month], [day], [issystemrow], [isdeleted], [creationdate],
                                      [account_id_creationdate], [updatedate], [account_id_updatedate],
                                      [deletedate], [account_id_deletedate])
  SELECT i.sku_id, 0, i.quantity, @supplier_id, 0, 0, 6, 'Compra de artículo a proveedor.',
         YEAR(GETUTCDATE()), MONTH(GETUTCDATE()), DAY(GETUTCDATE()),
         i.issystemrow, i.isdeleted, i.creationdate, i.account_id_creationdate,
         i.updatedate, i.account_id_updatedate, i.deletedate, i.account_id_updatedate
    FROM inserted i;

  SET NOCOUNT OFF;
END;
GO

IF OBJECT_ID('dbo.trgOnUpdateArticleInStock') IS NOT NULL
  PRINT '<<< El objeto ''dbo.trgOnUpdateArticleInStock'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.trgOnUpdateArticleInStock''. >>>';

-- 25. Creando el trigger de movimiento de artículos.
-----------------------------------------------------
IF OBJECT_ID('dbo.trgOnUpdateAssignArticle') IS NOT NULL
BEGIN
  DROP TRIGGER dbo.trgOnUpdateAssignArticle;

  IF OBJECT_ID('dbo.trgOnUpdateAssignArticle') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.trgOnUpdateAssignArticle''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.trgOnUpdateAssignArticle'' se ha eliminado correctamente. >>>';
END;
GO

CREATE TRIGGER dbo.trgOnUpdateAssignArticle ON [dbo].[mtAssignmentDetail]
AFTER INSERT AS
BEGIN
  DECLARE @supplier_id int;
  DECLARE @store_id int;

  SET NOCOUNT ON;
  
  /* Busco el proveedor del artículo previamente cargado. */
  SELECT @supplier_id = t1.supplier_id
    FROM dbo.mtArticles t1
   WHERE (t1.sku_id IN (SELECT i.sku_id FROM inserted i))
     AND (t1.isdeleted = 0);

  /* Busco el identificador de sucursal donde se mandará el artículo. */
  SELECT @store_id = t1.store_id
    FROM dbo.mtAssignments t1
   WHERE (t1.assignment_id IN (SELECT i.assignment_id FROM inserted i))
     AND (t1.isdeleted = 0);  

  /* Actualizo el stock del inventario de la sucursal de origen. */
  UPDATE m
     SET m.[item_input_quantity] = (m.[item_input_quantity] - i.quantity),
         m.[item_output_quantity] = (m.[item_output_quantity] + i.quantity),
         m.[purchase_price] = i.purchase_price,
         m.[sale_price] = i.sale_price,
         m.[account_id_updatedate] = i.account_id_creationdate,
         m.[updatedate] = i.creationdate
    FROM dbo.mtStockArticles m
   INNER JOIN inserted i ON (m.sku_id = i.sku_id) AND (m.store_id = 0);

  /* Actualizo el precio de venta del artículo existente en sucursal. */
  UPDATE m
     SET m.[purchase_price] = i.purchase_price,
         m.[sale_price] = i.sale_price,
         m.[account_id_updatedate] = i.account_id_creationdate,
         m.[updatedate] = i.creationdate
    FROM dbo.mtArticles m
   INNER JOIN inserted i ON (m.sku_id = i.sku_id);

  /* Se inserta al catálogo de movimientos de artículo como movimiento a sucursal. */
  INSERT INTO [dbo].[mtItemMovement] ([sku_id], [origin_store_id], [starting_total], [supplier_id],
                                      [posting_store_id], [final_total], [movement_status], [comments],
                                      [year], [month], [day], [issystemrow], [isdeleted], [creationdate],
                                      [account_id_creationdate], [updatedate], [account_id_updatedate],
                                      [deletedate], [account_id_deletedate])
  SELECT i.sku_id, 0, 0, @supplier_id, @store_id, i.quantity, 2, 'Asignación de artículo a sucursal.',
         YEAR(GETUTCDATE()), MONTH(GETUTCDATE()), DAY(GETUTCDATE()),
         i.issystemrow, i.isdeleted, i.creationdate, i.account_id_creationdate,
         i.updatedate, i.account_id_updatedate, i.deletedate, i.account_id_updatedate
    FROM inserted i;

  /* Se inserta en el stock de movimientos de artículo en la sucursal destino. */
  INSERT INTO [dbo].[mtStockArticles] ([sku_id], [store_id], [item_input_quantity], [item_output_quantity], [purchase_price], [sale_price],
                                       [issystemrow], [isdeleted], [creationdate], [account_id_creationdate],
                                       [updatedate], [account_id_updatedate], [deletedate],[account_id_deletedate])
  SELECT i.sku_id, @store_id, i.quantity, 0, i.purchase_price, i.sale_price,
         i.issystemrow, i.isdeleted, i.creationdate, i.account_id_creationdate,
         i.updatedate, i.account_id_updatedate, i.deletedate, i.account_id_updatedate
    FROM inserted i;

  SET NOCOUNT OFF;
END;
GO

IF OBJECT_ID('dbo.trgOnUpdateAssignArticle') IS NOT NULL
  PRINT '<<< El objeto ''dbo.trgOnUpdateAssignArticle'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.trgOnUpdateAssignArticle''. >>>';

-- 26. Creando el trigger de venta de artículos.
------------------------------------------------
IF OBJECT_ID('dbo.trgOnUpdateOrderArticle') IS NOT NULL
BEGIN
  DROP TRIGGER dbo.trgOnUpdateOrderArticle;

  IF OBJECT_ID('dbo.trgOnUpdateOrderArticle') IS NOT NULL
    PRINT '<<< Ocurrió un error al eliminar el objeto ''dbo.trgOnUpdateOrderArticle''. >>>';
  ELSE
    PRINT '<<< El objeto ''dbo.trgOnUpdateOrderArticle'' se ha eliminado correctamente. >>>';
END;
GO

CREATE TRIGGER dbo.trgOnUpdateOrderArticle ON [dbo].[mtOrderDetail]
AFTER INSERT AS
BEGIN
  DECLARE @supplier_id int;
	DECLARE @store_id int;
  DECLARE @item_input_quantity int;

  SET NOCOUNT ON;
  
  /* Obtengo la cantidad anterior en el stock. */
  SELECT @item_input_quantity = t1.item_input_quantity
    FROM dbo.mtStockArticles t1
   WHERE (t1.sku_id IN (SELECT i.sku_id FROM inserted i))
     AND (t1.isdeleted = 0);

  /* Busco el identificador de sucursal donde se hizo la venta del artículo. */
  SELECT @store_id = t1.store_id
    FROM dbo.mtOrders t1
   WHERE (t1.order_id IN (SELECT i.order_id FROM inserted i))
     AND (t1.isdeleted = 0);

  /* Actualizo el stock del inventario de la sucursal de origen. */
  UPDATE m
     SET m.[item_input_quantity] = (m.[item_input_quantity] - i.quantity),
         m.[item_output_quantity] = (m.[item_output_quantity] + i.quantity),
         m.[account_id_updatedate] = i.account_id_creationdate,
         m.[updatedate] = i.creationdate
    FROM dbo.mtStockArticles m
   INNER JOIN inserted i ON (m.sku_id = i.sku_id) AND (m.store_id = @store_id) and (m.isdeleted = 0);

  /* Busco el proveedor del artículo previamente cargado. */
  SELECT @supplier_id = t1.supplier_id
    FROM dbo.mtArticles t1
   WHERE (t1.sku_id IN (SELECT i.sku_id FROM inserted i))
     AND (t1.isdeleted = 0);

  /* Se inserta al catálogo de movimientos de artículo como movimiento a sucursal. */
  INSERT INTO [dbo].[mtItemMovement] ([sku_id], [origin_store_id], [starting_total], [supplier_id],
                                      [posting_store_id], [final_total], [movement_status], [comments],
                                      [year], [month], [day], [issystemrow], [isdeleted], [creationdate],
                                      [account_id_creationdate], [updatedate], [account_id_updatedate],
                                      [deletedate], [account_id_deletedate])
  SELECT i.sku_id, @store_id, @item_input_quantity, @supplier_id, @store_id, (@item_input_quantity - i.quantity), 7, 'Venta de artículo en sucursal.',
         YEAR(GETUTCDATE()), MONTH(GETUTCDATE()), DAY(GETUTCDATE()),
         i.issystemrow, i.isdeleted, i.creationdate, i.account_id_creationdate,
         i.updatedate, i.account_id_updatedate, i.deletedate, i.account_id_updatedate
    FROM inserted i;

  SET NOCOUNT OFF;
END;
GO

IF OBJECT_ID('dbo.trgOnUpdateOrderArticle') IS NOT NULL
  PRINT '<<< El objeto ''dbo.trgOnUpdateOrderArticle'' se ha creado correctamente. >>>';
ELSE
  PRINT '<<< Ocurrió un error al crear el objeto ''dbo.trgOnUpdateOrderArticle''. >>>';

-- 1638470944-CreateObjectsDb
