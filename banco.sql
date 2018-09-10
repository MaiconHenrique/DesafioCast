create schema biblioteca

create table biblioteca.livro(
	id_livro serial not null,
	nm_livro varchar(100) not null,
	ds_livro varchar(500) not null,
	st_livro integer not null,

	constraint pk_livro primary key (id_livro)
)

create table biblioteca.cliente(
	id_cliente serial not null,
	nm_cliente varchar(100) not null,
	cpf_cliente varchar(11)not null,

	constraint pk_cliente primary key(id_cliente)

)

create table biblioteca.emprestimo(
	id_emprestimo serial not null,
	id_cliente_emprestimo int not null,
	id_livro_emprestimo int not null,
	dt_aluguel_emprestimo timestamp without time zone not null,
	dt_entrega_emprestimo timestamp without time zone not null,
	
	constraint pk_emprestimo primary key (id_emprestimo),
	constraint fk_emprestimo_cliente foreign key (id_cliente_emprestimo) references biblioteca.cliente(id_cliente),
	constraint fk_emprestimo_livro foreign key (id_livro_emprestimo) references biblioteca.livro(id_livro)
	
)

insert into biblioteca.livro(nm_livro, ds_livro, st_livro)
values('harry potter e a pedra filosofal','testesss', 0)

insert into biblioteca.livro(nm_livro, ds_livro, st_livro)
values('harry potter e o enigma do príncipe','Testeee', 0)

insert into biblioteca.livro(nm_livro, ds_livro, st_livro)
values('harry potter ea ordem da fenix', 'Testeeee', 1)

insert into biblioteca.cliente(nm_cliente, ra_cliente)
values ('Teste1', '258963147')

insert into biblioteca.cliente(nm_cliente, ra_cliente)
values ('Teste2', '987456321')

insert into biblioteca.cliente(nm_cliente, ra_cliente)
values ('Teste3', '8524147')