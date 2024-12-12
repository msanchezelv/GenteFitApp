import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))

# Función para leer el XML y obtener los datos de Horario
def leer_xml_horario(xml_file):
    import xml.etree.ElementTree as ET

    # Parsear el archivo XML
    tree = ET.parse(xml_file)
    root = tree.getroot()

    horarios = []
    
    # Iterar sobre cada elemento 'Horario' en el XML
    for horario_elem in root.findall('Horario'):
        horario = {
            'idHorario': int(horario_elem.find('idHorario').text),
            'diaSemana': horario_elem.find('diaSemana').text,
            'horaInicio': horario_elem.find('horaInicio').text,  # Suponiendo formato "HH:MM:SS"
            'horaFin': horario_elem.find('horaFin').text,  # Suponiendo formato "HH:MM:SS"
            'idActividad': int(horario_elem.find('idActividad').text) if horario_elem.find('idActividad') is not None else None,
            'sala': int(horario_elem.find('sala').text) if horario_elem.find('sala') is not None else None,
            'Monitor': horario_elem.find('Monitor').text,
            'duracion': int(horario_elem.find('duracion').text) if horario_elem.find('duracion') is not None else None
        }
        horarios.append(horario)

    return horarios

# Función para crear horarios en Odoo
def crear_horario_en_odoo(horarios):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()

    for horario in horarios:
        try:
            horario_data = {
                'id_horario': horario['idHorario'],
                'dia_semana': horario['diaSemana'],
                'hora_inicio': horario['horaInicio'],
                'hora_fin': horario['horaFin'],
                'id_actividad': horario['idActividad'],
                'sala': horario['sala'],
                'monitor': horario['Monitor'],
                'duracion': horario['duracion']
            }

            # Crear el horario en Odoo
            horario_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'x_horario', 'create', [horario_data]
            )
            print(f"Horario creado en Odoo con ID: {horario_id}")
        except Exception as e:
            print(f"Error al crear horario en Odoo: {e}")


# Llamar a la función para leer el XML y luego crear los horarios en Odoo
xml_file = 'horarios.xml'  # Nombre del archivo XML
horarios = leer_xml_horario(xml_file)

# Enviar los clientes a Odoo
crear_horario_en_odoo(horarios)