create table WEB_LOGACESSO (
  DT_LOQ date not null,
  NR_SEQLOG number(6) not null,
  CD_EMPRESA number(4) not null,
  CD_USUARIO number(6) not null,
  CD_SERVICO varchar(100) not null,
  CD_METODO varchar(100) not null,
  QT_ACESSO number(6) not null,
  constraint WEB_LOGACESSO_PK primary key (DT_LOQ, NR_SEQLOG, CD_EMPRESA, CD_USUARIO, CD_SERVICO, CD_METODO)
)
;