import os
import sys

# -*- coding: utf-8 -*-

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))

# Mapeo de campos entre Odoo y SQL Server
campo_mapeo = {
   "x_id_actividad": "idActividad",
   "x_nombre": "nombre",
   "x_descripcion": "descripcion",
   "x_nivel_intensidad": "nivelIntensidad",
   "x_sala": "sala",
   "x_plazas_disponibles": "plazasDisponibles",
   "x_id_monitor": "idMonitor",
   "x_sala": "idSala"
   }

def obtener_datos_actividad():
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG


    models, uid = conectar_odoo()

    # Usar search_read para obtener los datos de la actividad desde Odoo
    actividades = models.execute_kw(
        ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
        'x_actividad', 'search_read',
        [[]],  # Para obtener todos los registros
        {'fields': ['x_id_actividad', 'x_nombre', 'x_descripcion', 'x_nivel_intensidad', 'x_plazas_disponibles', 'x_id_monitor', 'x_sala']}
    )
    return actividades

# Funcion para guardar las actividades en la base de datos SQL Server
def guardar_datos_actividad(actividades):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_sql

    connection = conectar_sql()

    # Nombre de la tabla en SQL Server
    tabla = "Actividad"

    with connection.cursor() as cursor:
        # Paso 1: Obtener las actividades de Odoo
        actividades_odoo = obtener_datos_actividad()

        # Paso 2: Obtener los ids de actividad de la base de datos
        cursor.execute(f"SELECT idActividad FROM {tabla}")
        actividades_base_datos = cursor.fetchall()

        # Paso 3: Eliminar las actividades que ya no están en Odoo
        ids_odoo = [actividad.get('idActividad') for actividad in actividades_odoo]
        ids_base_datos = [actividad[0] for actividad in actividades_base_datos]

        # Encontrar las actividades que están en la base de datos pero no en Odoo
        actividades_a_eliminar = set(ids_base_datos) - set(ids_odoo)

        # Eliminar las actividades que ya no existen en Odoo
        for id_actividad in actividades_a_eliminar:
            cursor.execute(f"DELETE FROM {tabla} WHERE idActividad = ?", (id_actividad,))

        # Paso 4: Insertar o actualizar las actividades de Odoo
        for actividad in actividades_odoo:
            id_actividad = actividad.get('idActividad')

            # Verificar si ya existe un registro con el mismo idActividad
            cursor.execute(f"SELECT COUNT(*) FROM {tabla} WHERE idActividad = ?", (id_actividad,))
            resultado = cursor.fetchone()

            # Definir las columnas y valores a insertar o actualizar
            columnas = [campo_mapeo[key] for key in actividad.keys() if key in campo_mapeo]
            valores = [actividad[key] for key in actividad.keys() if key in campo_mapeo]

            if resultado[0] == 0:
                # Si no existe, insertar el registro
                # Excluir la columna de identidad 'idActividad' (o el nombre de la columna de identidad en tu caso)
                columnas_sin_id = [col for col in columnas if col != 'idActividad']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idActividad']
                
                placeholders = ', '.join(['?'] * len(valores_sin_id))
                cursor.execute(f"INSERT INTO {tabla} ({', '.join(columnas_sin_id)}) VALUES ({placeholders})", tuple(valores_sin_id))

            else:
                # Si ya existe, actualizar el registro
                # Excluir la columna de identidad 'idActividad' en el UPDATE
                columnas_sin_id = [col for col in columnas if col != 'idActividad']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idActividad']
                set_clause = ', '.join([f"{col} = ?" for col in columnas_sin_id])

                # Ejecutar el UPDATE excluyendo 'idActividad'
                cursor.execute(f"UPDATE {tabla} SET {set_clause} WHERE idActividad = ?", (*valores_sin_id, id_actividad))

            # Confirmar la transacción para cada registro
            connection.commit()


    # Cerrar la conexión
    connection.close()


actividades_odoo = obtener_datos_actividad()
guardar_datos_actividad(actividades_odoo)