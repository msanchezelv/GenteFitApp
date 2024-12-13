import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))

print("Se ha abierto el script usuario_export.py correctamente")
# Mapeo de campos entre XML de Usuario y SQL Server
campo_mapeo_usuario = {
    "x_idusuario": "idUsuario",
    "x_nombre": "nombre",
    "x_apellidos": "apellidos",
    "x_email": "email",
    "x_contrasena": "contraseña",
    "x_rol": "rol"
}

# Función para obtener los datos de Odoo (Usuario)
def obtener_datos_usuario():
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()

    # Usar search_read para obtener los datos de usuario desde Odoo
    usuarios = models.execute_kw(
        ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
        'x_usuario', 'search_read',
        [[]],  # Para obtener todos los registros
        {'fields': ['x_idusuario', 'x_nombre', 'x_apellidos', 'x_email', 'x_contrasena', 'x_rol']}
    )
    return usuarios

# Función para guardar los usuarios en la base de datos SQL Server
def guardar_datos_usuario(usuarios):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_sql

    connection = conectar_sql()

    # Nombre de la tabla en SQL Server
    tabla = "Usuario"

    with connection.cursor() as cursor:
        # Paso 1: Obtener los usuarios de Odoo
        usuarios_odoo = obtener_datos_usuario()

        # Paso 2: Obtener los ids de usuario de la base de datos
        cursor.execute(f"SELECT idUsuario FROM {tabla}")
        usuarios_base_datos = cursor.fetchall()

        # Paso 3: Eliminar los usuarios que ya no están en Odoo
        ids_odoo = [usuario.get('x_idusuario') for usuario in usuarios_odoo]
        ids_base_datos = [usuario[0] for usuario in usuarios_base_datos]

        # Encontrar los usuarios que están en la base de datos pero no en Odoo
        usuarios_a_eliminar = set(ids_base_datos) - set(ids_odoo)

        # Eliminar los usuarios que ya no existen en Odoo
        for id_usuario in usuarios_a_eliminar:
            cursor.execute(f"DELETE FROM {tabla} WHERE idUsuario = ?", (id_usuario,))
    
        # Paso 4: Insertar o actualizar los usuarios de Odoo
        for usuario in usuarios_odoo:
            id_usuario = usuario.get('x_idusuario')

            # Verificar si ya existe un registro con el mismo idUsuario
            cursor.execute(f"SELECT COUNT(*) FROM {tabla} WHERE idUsuario = ?", (id_usuario,))
            resultado = cursor.fetchone()

            # Definir las columnas y valores a insertar o actualizar
            columnas = [campo_mapeo_usuario[key] for key in usuario.keys() if key in campo_mapeo_usuario]
            valores = [usuario[key] for key in usuario.keys() if key in campo_mapeo_usuario]

            if resultado[0] == 0:
                # Si no existe, insertar el registro
                # Excluir la columna de identidad 'id_usuario' (o el nombre de la columna de identidad en tu caso)
                columnas_sin_id = [col for col in columnas if col != 'idUsuario']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idUsuario']

                placeholders = ', '.join(['?'] * len(valores_sin_id))
                cursor.execute(f"INSERT INTO {tabla} ({', '.join(columnas_sin_id)}) VALUES ({placeholders})", tuple(valores_sin_id))

            else:
                columnas_sin_id = [col for col in columnas if col != 'idUsuario']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idUsuario']
                set_clause = ', '.join([f"{col} = ?" for col in columnas_sin_id])

                # Ejecutar el UPDATE excluyendo 'id_usuario'
                cursor.execute(f"UPDATE {tabla} SET {set_clause} WHERE idUsuario = ?", (*valores_sin_id, id_usuario))

            # Confirmar la transacción para cada registro
            connection.commit()




usuarios_odoo = obtener_datos_usuario()
guardar_datos_usuario(usuarios_odoo)