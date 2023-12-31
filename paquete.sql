create or replace package updatePackage is
    procedure spValidarExistenciaTabla(v_nombreTabla in VARCHAR2,V_EXISTE out VARCHAR2);
    procedure spValidarDatosTabla(v_nombreTabla in VARCHAR2,V_EXISTE out VARCHAR2);
    procedure spValidarColumna (v_nombreTabla in VARCHAR2, v_nombreColumna in VARCHAR2,V_EXISTE out VARCHAR2);
PROCEDURE spcActualizarTabla ( v_updateQuery IN VARCHAR2 );
  PROCEDURE spCONSULTADICCIONARIO(o_cursor IN OUT SYS_REFCURSOR, V_COL IN VARCHAR2);
end updatePackage;




create or replace package body updatePackage is
    --Procedimiento para validar existencia de Tabla
 PROCEDURE spValidarExistenciaTabla(
    v_nombreTabla IN VARCHAR2,
    v_EXISTE OUT VARCHAR2
)
IS
    v_cantidad NUMBER;
BEGIN
    SELECT COUNT(*)
    INTO v_cantidad
    FROM user_objects
    WHERE object_type = 'TABLE' AND LOWER(object_name) = LOWER(v_nombreTabla);

    v_EXISTE := CASE WHEN v_cantidad > 0 THEN 'SI' ELSE 'NO' END;
END spValidarExistenciaTabla;


    
    --Procedimiento para validar que la Tabla tenga datos
    procedure spValidarDatosTabla(v_nombreTabla in VARCHAR2,V_EXISTE out VARCHAR2)
    IS
        v_cantidad NUMBER;
    BEGIN
        EXECUTE IMMEDIATE 'SELECT COUNT(*) FROM ' || v_nombreTabla INTO v_cantidad;
    v_EXISTE := CASE WHEN v_cantidad > 0 THEN 'SI' ELSE 'NO' END;
    END spValidarDatosTabla;
    
    --Procedimiento para validar columnas asociadas a la tabla
   procedure spValidarColumna (v_nombreTabla VARCHAR2, v_nombreColumna VARCHAR2,V_EXISTE out VARCHAR2)
    is
        v_cantidad NUMBER;
    begin
        --Validar si la columna existe en la base de datos
        select count(*) into v_cantidad from all_tab_columns where lower(column_name) = lower(v_nombreColumna);
        if (v_cantidad>0) then
                --Validar si columna esta asociada a la tabla
            select count(*) into v_cantidad from all_tab_columns where lower(column_name) = lower(v_nombreColumna) and lower(table_name) = lower(v_nombreTabla);
            v_EXISTE := CASE WHEN v_cantidad > 0 THEN 'SI' ELSE 'NO' END;
        else
           v_EXISTE := 'Ni';
        end if;
       
    end spValidarColumna;

    
    --Procedimiento para actualizar datos de la tabla
PROCEDURE spcActualizarTabla (
    v_updateQuery IN VARCHAR2 -- Sentencia UPDATE completa
)
IS
BEGIN
    -- Ejecutar la sentencia UPDATE recibida como par�metro
    EXECUTE IMMEDIATE v_updateQuery;

    -- Si la actualizaci�n se realiza correctamente, no se lanzar� ninguna excepci�n
EXCEPTION
    WHEN OTHERS THEN
        -- Manejo de la excepci�n en caso de error
        RAISE_APPLICATION_ERROR(-20001, 'Error al ejecutar la sentencia UPDATE: ' || SQLERRM);
END spcActualizarTabla;

   PROCEDURE spCONSULTADICCIONARIO(o_cursor IN OUT SYS_REFCURSOR, V_COL IN VARCHAR2)
    IS
    BEGIN
        OPEN o_cursor FOR
        'SELECT '||V_COL|| ' FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = ''MOTO''';
    END spCONSULTADICCIONARIO;

end updatePackage;