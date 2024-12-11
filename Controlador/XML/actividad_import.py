import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))


# Función para leer el XML y obtener los datos de Actividad
def leer_xml_actividad(xml_file):
    import xml.etree.ElementTree as ET

    # Parsear el archivo XML
    tree = ET.parse(xml_file)
    root = tree.getroot()

    actividades = []
    
    # Iterar sobre cada elemento 'Actividad' en el XML
    for actividad_elem in root.findall('Actividad'):
        actividad = {
            'idActividad': int(actividad_elem.find('idActividad').text),
            'nombre': actividad_elem.find('nombre').text,
            'descripcion': actividad_elem.find('descripcion').text,
            'nivelIntensidad': actividad_elem.find('nivelIntensidad').text,
            'sala': int(actividad_elem.find('sala').text) if actividad_elem.find('sala').text else None,
            'plazasDisponibles': int(actividad_elem.find('plazasDisponibles').text) if actividad_elem.find('plazasDisponibles').text else None,
            'idMonitor': int(actividad_elem.find('idMonitor').text) if actividad_elem.find('idMonitor').text else None,
        }
        actividades.append(actividad)

    return actividades

# Función para crear actividades en Odoo
def crear_actividad_en_odoo(actividades):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()

    for actividad in actividades:
        try:
            actividad_data = {
                'id_actividad': actividad['idActividad'],
                'nombre': actividad['nombre'],
                'descripcion': actividad['descripcion'],
                'nivel_intensidad': actividad['nivelIntensidad'],
                'plazas_disponibles': actividad['plazasDisponibles'],
                'id_monitor': actividad['idMonitor'],
                'sala': actividad['sala']
            }

            actividad_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'actividad.custom', 'create', [actividad_data]
            )
            print(f"Actividad creada en Odoo con ID: {actividad_id}")
        except Exception as e:
            print(f"Error al crear actividad en Odoo: {e}")



# Llamar a la función para leer el XML y luego crear las actividades en Odoo
xml_file = 'actividades.xml'  # Nombre del archivo XML generado
actividades = leer_xml_actividad(xml_file)
crear_actividad_en_odoo(actividades)
