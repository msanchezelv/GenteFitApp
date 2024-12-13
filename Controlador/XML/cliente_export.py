import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))

# -*- coding: utf-8 -*-

# Mapeo de campos entre Odoo y SQL Server
campo_mapeo_cliente = {
    "x_id_cliente": "idCliente",
    "x_telefono": "telefono",
    "x_direccion": "direccion",
    "x_id_usuario": "idUsuario"
}

# Función para obtener los datos de Odoo
def obtener_datos_cliente():
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()

    # Usar search_read para obtener los datos del cliente desde Odoo
    clientes = models.execute_kw(
        ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
        'x_cliente', 'search_read',
        [[]],  # Para obtener todos los registros
        {'fields': ['x_id_cliente', 'x_telefono', 'x_direccion', 'x_id_usuario']}
    )
    return clientes

# Función para guardar los clientes en la base de datos SQL Server
def guardar_datos_cliente(clientes):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_sql

    connection = conectar_sql()

    # Nombre de la tabla en SQL Server
    tabla = "Cliente"

    with connection.cursor() as cursor:
        for cliente in clientes:
            # Crear el comando INSERT, mapeando los campos
            columnas = [campo_mapeo_cliente[key] for key in cliente.keys() if key in campo_mapeo_cliente]
            valores = [cliente[key] for key in cliente.keys() if key in campo_mapeo_cliente]

            # Verificar si ya existe un registro con los mismos datos
            id_cliente = cliente.get('x_id_cliente')
            cursor.execute(f"SELECT COUNT(*) FROM {tabla} WHERE idCliente = ?", (id_cliente,))
            resultado = cursor.fetchone()

            if resultado[0] == 0:
                # Si no existe, insertar el registro
                # Excluir la columna de identidad 'idCliente'
                columnas_sin_id = [col for col in columnas if col != 'idCliente']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idCliente']

                placeholders = ', '.join(['?'] * len(valores_sin_id))
                cursor.execute(f"INSERT INTO {tabla} ({', '.join(columnas_sin_id)}) VALUES ({placeholders})", tuple(valores_sin_id))
            else:
                # Si ya existe, actualizar el registro
                # Excluir la columna de identidad 'idCliente' en el UPDATE
                columnas_sin_id = [col for col in columnas if col != 'idCliente']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idCliente']
                set_clause = ', '.join([f"{col} = ?" for col in columnas_sin_id])

                # Ejecutar el UPDATE excluyendo 'idCliente'
                cursor.execute(f"UPDATE {tabla} SET {set_clause} WHERE idCliente = ?", (*valores_sin_id, id_cliente))

        # Confirmar la transacción
        connection.commit()

    # Cerrar la conexión
    connection.close()




clientes_odoo = obtener_datos_cliente()
guardar_datos_cliente(clientes_odoo)