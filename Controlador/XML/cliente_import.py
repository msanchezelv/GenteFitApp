import xml.etree.ElementTree as ET
from .ConexionOdoo import ODOO_CONFIG, conectar_odoo

# Función para leer el XML y obtener los datos de clientes
def leer_xml_cliente(xml_file):
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
def enviar_clientes_a_odoo(clientes):
    models, uid = ConexionOdoo.conectar_odoo()  # Conectar a Odoo
    
    for cliente in clientes:
        # Preparar los datos para el registro en Odoo
        values = {
            'phone': cliente['telefono'],
            'address': cliente['direccion'],
            'user_id': cliente['idUsuario']  # Se supone que idUsuario corresponde al campo 'user_id' en Odoo
        }

        try:
            # Crear el cliente en Odoo (suponiendo que el modelo de cliente es 'res.partner')
            cliente_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'res.partner', 'create', [values]
            )
            print(f"Cliente creado en Odoo con ID: {cliente_id}")
        except Exception as e:
            print(f"Error al crear cliente en Odoo: {e}")

# Llamar a la función y mostrar los clientes
xml_file = 'clientes.xml'  # Nombre del archivo XML generado
clientes = leer_xml_cliente(xml_file)

# Enviar los clientes a Odoo
enviar_clientes_a_odoo(clientes)
