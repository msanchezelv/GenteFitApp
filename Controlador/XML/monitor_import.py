import xml.etree.ElementTree as ET
from .ConexionOdoo import ODOO_CONFIG, conectar_odoo

# Función para leer el XML y obtener los datos de Monitor
def leer_xml_monitor(xml_file):
    # Parsear el archivo XML
    tree = ET.parse(xml_file)
    root = tree.getroot()

    monitores = []
    
    # Iterar sobre cada elemento 'Monitor' en el XML
    for monitor_elem in root.findall('Monitor'):
        monitor = {
            'idMonitor': int(monitor_elem.find('idMonitor').text),
            'nombre': monitor_elem.find('nombre').text,
            'apellidos': monitor_elem.find('apellidos').text,
            'idActividad': int(monitor_elem.find('idActividad').text) if monitor_elem.find('idActividad') is not None else None,
        }
        monitores.append(monitor)

    return monitores

# Función para crear los monitores en Odoo
def crear_monitor_en_odoo(monitores):
    models, uid = conectar_odoo()

    for monitor in monitores:
        try:
            monitor_data = {
                'name': monitor['nombre'],
                'last_name': monitor['apellidos'],
                'activity_id': monitor['idActividad'],
            }

            # Crear el monitor en Odoo
            monitor_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'gentefit.monitor', 'create', [monitor_data]
            )
            print(f"Monitor creado en Odoo con ID: {monitor_id}")
        except Exception as e:
            print(f"Error al crear monitor en Odoo: {e}")

# Llamar a la función para leer el XML y luego crear los monitores en Odoo
xml_file = 'monitores.xml'  # Nombre del archivo XML generado
monitores = leer_xml_monitor(xml_file)
crear_monitor_en_odoo(monitores)
