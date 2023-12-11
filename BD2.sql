--Generacion de la tabla
create table Teclado
(
 tecCodigo int not null,
 tecMarca varchar2(20) not null,
 telFechaElab date not null,
 tecIdioma char,
 constraint pk_Teclado primary key(tecCodigo),
 constraint ckc_tecIdioma check(tecIdioma in('i','e'))
);
--Insercion de Datos
insert into Teclado(tecCodigo,tecMarca,telFechaElab,tecIdioma)values(101,'Dell','13/06/2019','i');
insert into Teclado(tecCodigo,tecMarca,telFechaElab,tecIdioma)values(102,'Logitech','06/07/2019',null);
insert into Teclado(tecCodigo,tecMarca,telFechaElab,tecIdioma)values(103,'Gigabyte','08/09/2018','e');
---------------------------------------------------------------------------------------------------------------------------------------
--Procedimientos y Funciones Almacenadas
---------------------------------------------------------------------------------------------------------------------------------------
--Procedimiento para validar existencia de Tabla
create or replace procedure prcValidarExistenciaTabla (v_nombreTabla VARCHAR2)
is
    v_cantidad NUMBER;
begin
    select count(*) into v_cantidad from user_objects where object_type like 'TABLE' and lower(object_name) = lower(v_nombreTabla);
    if (v_cantidad>0) then
        dbms_output.put_line('La tabla ' || v_nombreTabla || ' existe en la base de datos.');
    else
        dbms_output.put_line('La tabla ' || v_nombreTabla || ' NO existe en la base de datos.');
    end if;
end prcValidarExistenciaTabla;

set serveroutput on
exec prcvalidarexistenciatabla('teclados');
---------------------------------------------------------------------------------------------------------------------------------------
--Procedimiento para validar que la Tabla tenga datos
create or replace procedure prcValidarDatosTabla (v_nombreTabla VARCHAR2)
is
    v_cantidad NUMBER;
begin
    EXECUTE IMMEDIATE 'select count(*) from ' || upper(v_nombretabla) into v_cantidad;
    
    if (v_cantidad>0) then
        dbms_output.put_line('La tabla ' || v_nombreTabla || ' contiene datos en la base de datos.');
    else
        dbms_output.put_line('La tabla ' || v_nombreTabla || ' NO contiene datos en la base de datos.');
    end if;
end prcValidarDatosTabla;
--Generacion de la tabla
create table PruebaTeclado
(
 pruebatecCodigo int not null,
 pruebatecMarca varchar2(20) not null,
 pruebatelFechaElab date not null,
 pruebatecIdioma char,
 constraint pk_PruebaTeclado primary key(pruebatecCodigo),
 constraint ckc_pruebatecIdioma check(pruebatecIdioma in('i','e'))
);

set serveroutput on
exec prcValidarDatosTabla('pruebateclado');
---------------------------------------------------------------------------------------------------------------------------------------
--Procedimiento para validar columnas asociadas a la tabla
create or replace procedure prcValidarColumna (v_nombreTabla VARCHAR2, v_nombreColumna VARCHAR2)
is
    v_cantidad NUMBER;
begin
    --Validar si la columna existe en la base de datos
    select count(*) into v_cantidad from all_tab_columns where lower(column_name) = lower(v_nombreColumna);
    if (v_cantidad>0) then
        dbms_output.put_line('La columna ' || v_nombrecolumna || ' existe en la base de datos.');
    else
        dbms_output.put_line('La columna ' || v_nombrecolumna || ' NO existe en la base de datos.');
    end if;
    --Validar si columna esta asociada a la tabla
    select count(*) into v_cantidad from all_tab_columns where lower(column_name) = lower(v_nombreColumna) and lower(table_name) = lower(v_nombreTabla);
    if (v_cantidad>0) then
        dbms_output.put_line('La columna ' || v_nombrecolumna || ' esta asociada a la tabla ' || v_nombretabla);
    else
        dbms_output.put_line('La columna ' || v_nombrecolumna || ' NO esta asociada a la tabla ' || v_nombretabla);
    end if;
end prcValidarColumna;

set serveroutput on
exec prcValidarColumna('pruebateclado','PRUEBATECCODIGO');
---------------------------------------------------------------------------------------------------------------------------------------
--Procedimiento para actualizar datos de la tabla
create or replace procedure prcActualizarTabla (
 v_primarykey IN Teclado.tecCodigo%TYPE,
 v_tecMarca IN Teclado.tecMarca%TYPE,
 v_telFechaElab IN Teclado.telFechaElab%TYPE,
 v_tecIdioma IN Teclado.tecIdioma%TYPE)
is
begin
    update teclado set tecMarca = v_tecMarca,telFechaElab = v_telFechaElab,tecIdioma = v_tecIdioma where tecCodigo = v_primarykey;
end prcActualizarTabla;

set serveroutput on
exec prcActualizarTabla(103,'pruebatec','08/09/2018','e');
--------------------------------------------------------------------------------
