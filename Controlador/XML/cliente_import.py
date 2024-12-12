import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))


# Función para leer el XML y obtener los datos de clientes
def leer_xml_cliente(xml_file):
    import xml.etree.ElementTree as ET
    # Parsear el archivo XML
    tree = ET.parse(xml_file)
    root = tree.getroot()

    clientes = []
    
    # Iterar sobre cada elemento 'Cliente' en el XML
    for cliente_elem in root.findall('Cliente'):
        cliente = {
            'idCliente': int(cliente_elem.find('idCliente').text),
            'telefono': cliente_elem.find('telefono').text,
            'direccion': cliente_elem.find('direccion').text,
            'idUsuario': int(cliente_elem.find('idUsuario').text) if cliente_elem.find('idUsuario') is not None else None
        }
        clientes.append(cliente)

    return clientes

# Función para enviar los clientes a Odoo
def crear_cliente_en_odoo(clientes):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()  # Conectar a Odoo
    
    for cliente in clientes:
        try:
            values = {
                'x_id_cliente': cliente['idCliente'],
                'x_telefono': cliente['telefono'],
                'x_direccion': cliente['direccion'],
                'x_id_usuario': cliente['idUsuario']
            }

            cliente_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'x_cliente', 'create', [values]
            )
            print(f"Cliente creado en Odoo con ID: {cliente_id}")
        except Exception as e:
            print(f"Error al crear cliente en Odoo: {e}")

# Llamar a la función y mostrar los clientes
xml_file = 'clientes.xml'  # Nombre del archivo XML generado
clientes = leer_xml_cliente(xml_file)

# Enviar los clientes a Odoo
crear_cliente_en_odoo(clientes)
