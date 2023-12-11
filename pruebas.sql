update Teclado set TECMARCA = 'MOSAS' WHERE TECCODIGO = 101;

update Teclado set TECMARCA = 'MOSAS2',tecidioma = 'e' WHERE TECCODIGO = 101;

update Teclado set TECMARCA = 'MOSAS2',tecidioma = 'e', TELFECHAELAB = '10/12/21' WHERE TECCODIGO = 101;

update Teclado set TECMARCA = 'MOSAS2',tecidioma = 'e', TELFECHAELAB = '10/12/21', teccodigo = 201  WHERE TECCODIGO = 01;

update Teclado set TECMARCA = 'MOSAS2',TECMARCA = 'MOSAS2',tecidioma = 'e', TELFECHAELAB = '10/12/21', teccodigo = 201  WHERE TECCODIGO = 01;

SET SERVEROUTPUT ON

DECLARE
    tabla_existe NUMBER;
    nombre_tabla VARCHAR2(100) := 'TECLADO'; -- Cambia 'mi_tabla' por el nombre de tu tabla
BEGIN
    tabla_existe := updatePackage.fnValidarExistenciaTabla(nombre_tabla);
    
    IF tabla_existe = 1 THEN
        DBMS_OUTPUT.PUT_LINE('La tabla ' || nombre_tabla || ' existe en la base de datos.');
    ELSE
        DBMS_OUTPUT.PUT_LINE('La tabla ' || nombre_tabla || ' NO existe en la base de datos.');
    END IF;
END;

SET SERVEROUTPUT ON

DECLARE
    v_EXISTE VARCHAR2(3); -- Definimos una variable para almacenar la salida del procedimiento
BEGIN
    -- Llamamos al procedimiento y pasamos los valores de prueba
    updatePackage.spValidarColumna('TECLADO', 'TEcMARCA', v_EXISTE);

    -- Mostramos el resultado
    DBMS_OUTPUT.PUT_LINE('La columna está asociada a la tabla: ' || v_EXISTE);
END;
