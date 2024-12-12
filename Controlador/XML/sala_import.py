import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))

# Función para leer el XML y obtener los datos de salas
def leer_xml_sala(xml_file):
    import xml.etree.ElementTree as ET

    # Parsear el archivo XML
    tree = ET.parse(xml_file)
    root = tree.getroot()

    salas = []
    
    # Iterar sobre cada elemento 'sala' en el XML
    for sala_elem in root.findall('Sala'):
        sala = {
            'idsala': int(sala_elem.find('idSala').text),
            'nombre': sala_elem.find('nombre').text,
        }

        salas.append(sala)

    return salas


# Función para enviar las salas a Odoo
def crear_salas_en_odoo(salas):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()  # Conectar a Odoo
    
    for sala in salas:
        # Preparar los datos para el registro en Odoo (no incluir 'id_sala' ya que es generado automáticamente)
        values = {
            'x_id_sala': sala['idsala'],
            'x_nombre': sala['nombre'],
        }

        try:
            # Crear sala en Odoo
            sala_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'x_sala', 'create', [values]
            )
            print(f"Sala creada en Odoo con ID: {sala_id}")
        except Exception as e:
            print(f"Error al crear sala en Odoo: {e}")



# Llamar a la función y mostrar salas
xml_file = 'salas.xml'
salas = leer_xml_sala(xml_file)

# Enviar salass a Odoo
crear_salas_en_odoo(salas)

