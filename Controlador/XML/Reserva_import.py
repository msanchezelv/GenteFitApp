import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))


# Función para leer el XML y obtener los datos de Reserva
def leer_xml_reserva(xml_file):
    import xml.etree.ElementTree as ET
    # Parsear el archivo XML
    tree = ET.parse(xml_file)
    root = tree.getroot()

    reservas = []
    
    # Iterar sobre cada elemento 'Reserva' en el XML
    for reserva_elem in root.findall('Reserva'):
        reserva = {
            'idReserva': int(reserva_elem.find('idReserva').text),
            'idCliente': int(reserva_elem.find('idCliente').text) if reserva_elem.find('idCliente') is not None else None,
            'idHorario': int(reserva_elem.find('idHorario').text) if reserva_elem.find('idHorario') is not None else None,
        }
        reservas.append(reserva)

    return reservas

# Función para crear las reservas en Odoo
def crear_reserva_en_odoo(reservas):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()

    for reserva in reservas:
        try:
            reserva_data = {
                'x_id_reserva': reserva['idReserva'],
                'x_id_cliente': reserva['idCliente'],
                'x_id_horario': reserva['idHorario'],
            }

            # Crear la reserva en Odoo
            reserva_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'x_reserva', 'create', [reserva_data]
            )
            print(f"Reserva creada en Odoo con ID: {reserva_id}")
        except Exception as e:
            print(f"Error al crear reserva en Odoo: {e}")

# Llamar a la función para leer el XML y luego crear las reservas en Odoo
xml_file = 'reservas.xml'  # Nombre del archivo XML generado
reservas = leer_xml_reserva(xml_file)
crear_reserva_en_odoo(reservas)
