CREATE TABLE Servidor (
    ID                   INT           NOT NULL PRIMARY KEY,
    Matricula            BIGINT        NOT NULL PRIMARY KEY,
    Servidor             NVARCHAR (50) NULL,
    Ingresso             DATE          NULL,
    Cargo                NVARCHAR (50) NULL,
    CargaHoraria         NVARCHAR (50) NULL,
    Horario              NVARCHAR (20) NULL,
    AreaDeAtuacao        INT NULL,
    TipoDeIngressso      INT NULL,
    CompetenciaSetorial  NVARCHAR (MAX) NULL,
    AtividadesDoServidor NVARCHAR (MAX) NULL,
    Conhecimento        NVARCHAR (MAX) NULL,
    Habilidades          NVARCHAR (MAX) NULL,
    Atitudes             NVARCHAR (MAX) NULL,
    DataComp             DATE          NULL,
    CONSTRAINT [PK_GEAPE_BD] PRIMARY KEY CLUSTERED ([ID] ASC)
);

