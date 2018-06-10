create table WEB_PERMISSAO (
  CD_EMPRESA number(4) not null,
  CD_USUARIO number(6) not null,
  CD_SERVICO varchar(100) not null,
  CD_METODO varchar(100) not null,
  constraint WEB_PERMISSAO_PK primary key (CD_EMPRESA, CD_USUARIO, CD_SERVICO, CD_METODO)
)
;

/*
insert into WEB_PERMISSAO values (1, 999998, 'Transacao', 'Consultar');
insert into WEB_PERMISSAO values (1, 999998, 'Transacao', 'Incluir');
insert into WEB_PERMISSAO values (1, 999998, 'Fiscal', 'Consultar');
insert into WEB_PERMISSAO values (1, 999998, 'Fiscal', 'Incluir');
insert into WEB_PERMISSAO values (1, 999998, 'Financeiro', 'Consultar');
insert into WEB_PERMISSAO values (1, 999998, 'Financeiro', 'Incluir');
insert into WEB_PERMISSAO values (1, 999998, 'Receber', 'Consultar');
insert into WEB_PERMISSAO values (1, 999998, 'Receber', 'Incluir');
insert into WEB_PERMISSAO values (1, 999998, 'Pessoa', 'Consultar');
insert into WEB_PERMISSAO values (1, 999998, 'Pessoa', 'Incluir');
insert into WEB_PERMISSAO values (1, 999998, 'Produto', 'Consultar');
insert into WEB_PERMISSAO values (1, 999998, 'Produto', 'Incluir');
*/