CREATE TABLE [dbo].[GEAPE_BD] (
    [ID]                   INT           NOT NULL,
    [Matricula]            BIGINT        NOT NULL,
    [Servidor]             NVARCHAR (50) NULL,
    [Ingresso]             DATE          NULL,
    [Cargo]                NVARCHAR (50) NULL,
    [CargaHoraria]         NVARCHAR (50) NULL,
    [Horario]              NVARCHAR (20) NULL,
    [AreaDeAtuacao]        INT NULL,
    [TipoDeIngressso]      INT NULL,
    [CompetenciaSetorial]  NVARCHAR (MAX) NULL,
    [AtividadesDoServidor] NVARCHAR (MAX) NULL,
    [Conhecimento]         NVARCHAR (MAX) NULL,
    [Habilidades]          NVARCHAR (MAX) NULL,
    [Atitudes]             NVARCHAR (MAX) NULL,
    [DataComp]             DATE          NULL,
    CONSTRAINT [PK_GEAPE_BD] PRIMARY KEY CLUSTERED ([ID] ASC)
);

