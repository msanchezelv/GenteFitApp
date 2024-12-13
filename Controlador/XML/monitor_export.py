import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))


# Mapeo de campos entre Odoo y SQL Server
campo_mapeo_monitor = {
    "x_idmonitor": "idMonitor",
    "x_nombre": "nombre",
    "x_apellidos": "apellidos",
    "x_idactividad": "idActividad"
}

# Función para obtener los datos de Odoo (Monitor)
def obtener_datos_monitor():
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()

    # Usar search_read para obtener los datos de monitor desde Odoo
    monitores = models.execute_kw(
        ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
        'x_monitor', 'search_read',
        [[]],  # Para obtener todos los registros
        {'fields': ['x_idmonitor', 'x_nombre', 'x_apellidos', 'x_idactividad']}
    )
    return monitores

# Función para guardar los monitores en la base de datos SQL Server
def guardar_datos_monitor(monitores):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_sql

    connection = conectar_sql()

    # Nombre de la tabla en SQL Server
    tabla = "Monitor"

    with connection.cursor() as cursor:
        for monitor in monitores:
            # Crear el comando INSERT, mapeando los campos
            columnas = [campo_mapeo_monitor[key] for key in monitor.keys() if key in campo_mapeo_monitor]
            valores = [monitor[key] for key in monitor.keys() if key in campo_mapeo_monitor]

            # Asegurarse de que 'idActividad' pueda ser NULL
            if 'idActividad' not in monitor or monitor['idActividad'] is None:
                valores = [None if col == 'idActividad' else val for col, val in zip(columnas, valores)]

            # Verificar si ya existe un registro con los mismos datos
            id_monitor = monitor.get('x_idmonitor')
            cursor.execute(f"SELECT COUNT(*) FROM {tabla} WHERE idMonitor = ?", (id_monitor,))
            resultado = cursor.fetchone()

            if resultado[0] == 0:
                # Si no existe, insertar el registro
                # Excluir la columna de identidad 'idMonitor'
                columnas_sin_id = [col for col in columnas if col != 'idMonitor']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idMonitor']
                
                placeholders = ', '.join(['?'] * len(valores_sin_id))
                cursor.execute(f"INSERT INTO {tabla} ({', '.join(columnas_sin_id)}) VALUES ({placeholders})", tuple(valores_sin_id))
            else:
                # Si ya existe, actualizar el registro
                # Excluir la columna de identidad 'idMonitor' en el UPDATE
                columnas_sin_id = [col for col in columnas if col != 'idMonitor']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idMonitor']
                set_clause = ', '.join([f"{col} = ?" for col in columnas_sin_id])

                # Ejecutar el UPDATE excluyendo 'idMonitor'
                cursor.execute(f"UPDATE {tabla} SET {set_clause} WHERE idMonitor = ?", (*valores_sin_id, id_monitor))

        # Confirmar la transacción
        connection.commit()

    # Cerrar la conexión
    connection.close()
