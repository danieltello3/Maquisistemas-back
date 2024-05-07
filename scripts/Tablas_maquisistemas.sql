
-- DROP TABLE public."TipoDocumento";

CREATE TABLE public."TipoDocumento" (
	"Id" int4 DEFAULT nextval('tipodocumento_id_seq'::regclass) NOT NULL,
	"Nombre" varchar(50) NOT NULL,
	"Estado" int4 NOT NULL,
	CONSTRAINT tipodocumento_pkey PRIMARY KEY ("Id")
);


INSERT INTO TipoDocumento (Nombre, Estado) VALUES ('DNI', 1);
INSERT INTO TipoDocumento (Nombre, Estado) VALUES ('RUC', 1);
INSERT INTO TipoDocumento (Nombre, Estado) VALUES ('CARNET DE EXTRANJERÍA', 1);

-- DROP TABLE public."Clients";

CREATE TABLE public."Clients" (
	"Id" uuid NOT NULL,
	"Nombres" varchar(100) NOT NULL,
	"Apellidos" varchar(100) NOT NULL,
	"FechaNacimiento" date NOT NULL,
	"IdTipoDocumento" int4 NOT NULL,
	"NroDocumento" varchar(20) NOT NULL,
	"Estado" int4 NOT NULL,
	CONSTRAINT clients_pkey PRIMARY KEY ("Id")
);


-- public."Clients" foreign keys

ALTER TABLE public."Clients" ADD CONSTRAINT fk_idtipodocumento FOREIGN KEY ("IdTipoDocumento") REFERENCES public."TipoDocumento"("Id");