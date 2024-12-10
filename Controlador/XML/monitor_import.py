import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))

# Función para leer el XML y obtener los datos de Monitor
def leer_xml_monitor(xml_file):
    import xml.etree.ElementTree as ET

    # Parsear el archivo XML
    tree = ET.parse(xml_file)
    root = tree.getroot()

    monitores = []

    # Iterar sobre cada elemento 'Monitor' en el XML
    for monitor_elem in root.findall('Monitor'):
        # Obtener el campo idActividad dentro del ciclo
        id_actividad_elem = monitor_elem.find('idActividad')
        
        monitor = {
            'idMonitor': int(monitor_elem.find('idMonitor').text),
            'nombre': monitor_elem.find('nombre').text,
            'apellidos': monitor_elem.find('apellidos').text,
            'idActividad': id_actividad_elem.text.strip() if id_actividad_elem is not None and id_actividad_elem.text else None,
        }
        monitores.append(monitor)

    return monitores

# Función para crear los monitores en Odoo
def crear_monitor_en_odoo(monitores):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    if not monitores:
        print("No se encontraron monitores para crear en Odoo.")
        return

    models, uid = conectar_odoo()

    for monitor in monitores:
        try:
            # Verificar si 'idActividad' está en el monitor y tiene un valor
            id_actividad = monitor.get('idActividad', None)
            # Si idActividad es None, usar un valor vacío o el valor por defecto
            id_actividad = id_actividad if id_actividad is not None else ''

            monitor_data = {
                'x_idmonitor': monitor['idMonitor'],
                'x_nombre': monitor['nombre'],
                'x_apellidos': monitor['apellidos'],
                'x_idactividad': id_actividad,  # Enviar el valor vacío o un valor por defecto
            }

            # Crear el monitor en Odoo
            monitor_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'x_monitor', 'create', [monitor_data]
            )
            print(f"Monitor creado en Odoo con ID: {monitor_id}")
        except Exception as e:
            print(f"Error al crear monitor en Odoo: {e}")

# Llamar a la función para leer el XML y luego crear los monitores en Odoo
xml_file = 'monitores.xml'  # Nombre del archivo XML generado
monitores = leer_xml_monitor(xml_file)
crear_monitor_en_odoo(monitores)
