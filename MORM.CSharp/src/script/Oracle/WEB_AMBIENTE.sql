create table WEB_AMBIENTE (
  CD_AMBIENTE varchar(100) not null,
  CD_DATABASE varchar(100) not null,
  CD_USERNAME varchar(100) not null,
  CD_PASSWORD varchar(100) not null,
  CD_EMPRESA number(4) not null,
  CD_USUARIO number(6) not null,
  constraint WEB_AMBIENTE_PK primary key (CD_AMBIENTE)
)
;