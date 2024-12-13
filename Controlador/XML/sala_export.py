import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))


# Mapeo de campos entre Odoo y SQL Server (para Sala)
campo_mapeo_sala = {
    "x_idsala": "idSala",
    "x_nombre": "nombre"
}

# Función para obtener los datos de Odoo (Sala)
def obtener_datos_sala():
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()

    # Usar search_read para obtener los datos de sala desde Odoo
    salas = models.execute_kw(
        ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
        'x_sala', 'search_read',
        [[]],  # Para obtener todos los registros
        {'fields': ['x_idsala', 'x_nombre']}
    )
    return salas

# Función para guardar las salas en la base de datos SQL Server
def guardar_datos_sala(salas):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_sql

    connection = conectar_sql()

    # Nombre de la tabla en SQL Server
    tabla = "Sala"

    with connection.cursor() as cursor:
        for sala in salas:
            # Crear el comando INSERT, mapeando los campos
            columnas = [campo_mapeo_sala[key] for key in sala.keys() if key in campo_mapeo_sala]
            valores = [sala[key] for key in sala.keys() if key in campo_mapeo_sala]

            # Verificar si ya existe un registro con los mismos datos
            id_sala = sala.get('x_idsala')  # Cambiar el nombre del campo según corresponda
            cursor.execute(f"SELECT COUNT(*) FROM {tabla} WHERE idSala = ?", (id_sala,))
            resultado = cursor.fetchone()

            if resultado[0] == 0:
                # Si no existe, insertar el registro
                # Excluir la columna de identidad 'idSala'
                columnas_sin_id = [col for col in columnas if col != 'idSala']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idSala']
                
                placeholders = ', '.join(['?'] * len(valores_sin_id))
                cursor.execute(f"INSERT INTO {tabla} ({', '.join(columnas_sin_id)}) VALUES ({placeholders})", tuple(valores_sin_id))
            else:
                # Si ya existe, actualizar el registro
                # Excluir la columna de identidad 'idSala' en el UPDATE
                columnas_sin_id = [col for col in columnas if col != 'idSala']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idSala']
                set_clause = ', '.join([f"{col} = ?" for col in columnas_sin_id])

                # Ejecutar el UPDATE excluyendo 'idSala'
                cursor.execute(f"UPDATE {tabla} SET {set_clause} WHERE idSala = ?", (*valores_sin_id, id_sala))

        # Confirmar la transacción
        connection.commit()

    # Cerrar la conexión
    connection.close()

