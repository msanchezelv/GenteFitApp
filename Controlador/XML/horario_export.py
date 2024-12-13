import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))


# Mapeo de campos entre Odoo y SQL Server
campo_mapeo_horario = {
    "x_id_horario": "idHorario",
    "x_dia_semana": "diaSemana",
    "x_hora_inicio": "horaInicio",
    "x_hora_fin": "horaFin",
    "x_id_actividad": "idActividad",
    "x_sala": "sala",
    "x_monitor": "Monitor",
    "x_duracion": "duracion"
}

# Función para obtener los datos de Odoo (Horario)
def obtener_datos_horario():
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()

    # Usar search_read para obtener los datos de horario desde Odoo
    horarios = models.execute_kw(
        ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
        'x_horario', 'search_read',
        [[]],  # Para obtener todos los registros
        {'fields': ['x_id_horario', 'x_dia_semana', 'x_hora_inicio', 'x_hora_fin', 'x_id_actividad', 'x_sala', 'x_monitor', 'x_duracion']}
    )
    return horarios

# Función para guardar los horarios en la base de datos SQL Server
def guardar_datos_horario(horarios):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_sql

    connection = conectar_sql()

    # Nombre de la tabla en SQL Server
    tabla = "Horario"

    with connection.cursor() as cursor:
        for horario in horarios:
            # Crear el comando INSERT, mapeando los campos
            columnas = [campo_mapeo_horario[key] for key in horario.keys() if key in campo_mapeo_horario]
            valores = [horario[key] for key in horario.keys() if key in campo_mapeo_horario]

            # Verificar si ya existe un registro con los mismos datos
            id_horario = horario.get('x_id_horario')
            cursor.execute(f"SELECT COUNT(*) FROM {tabla} WHERE idHorario = ?", (id_horario,))
            resultado = cursor.fetchone()

            if resultado[0] == 0:
                # Si no existe, insertar el registro
                # Excluir la columna de identidad 'idHorario'
                columnas_sin_id = [col for col in columnas if col != 'idHorario']
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idHorario']                

                placeholders = ', '.join(['?'] * len(valores_sin_id))
                cursor.execute(f"INSERT INTO {tabla} ({', '.join(columnas_sin_id)}) VALUES ({placeholders})", tuple(valores_sin_id))
            else:
                 # Si ya existe, actualizar el registro
                columnas_sin_id = [col for col in columnas if col != 'idHorario']  # Excluir la columna de identidad
                valores_sin_id = [val for col, val in zip(columnas, valores) if col != 'idHorario']
                set_clause = ', '.join([f"{col} = ?" for col in columnas_sin_id])

                # Ejecutar el UPDATE excluyendo 'idHorario'
                cursor.execute(f"UPDATE {tabla} SET {set_clause} WHERE idHorario = ?", (*valores_sin_id, id_horario))

        # Confirmar la transacción
        connection.commit()

    # Cerrar la conexión
    connection.close()
