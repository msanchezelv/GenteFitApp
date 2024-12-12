import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))


# Función para leer el XML y obtener los datos de ListaEspera
def leer_xml_lista_espera(xml_file):
    import xml.etree.ElementTree as ET

    # Parsear el archivo XML
    tree = ET.parse(xml_file)
    root = tree.getroot()

    lista_espera = []
    
    # Iterar sobre cada elemento 'ListaEspera' en el XML
    for lista_elem in root.findall('ListaEspera'):
        espera = {
            'idListaEspera': int(lista_elem.find('idListaEspera').text),
            'idActividad': int(lista_elem.find('idActividad').text) if lista_elem.find('idActividad'),
            'idHorario': int(lista_elem.find('idHorario').text) if lista_elem.find('idHorario'),
            'idCliente': int(lista_elem.find('idCliente').text) if lista_elem.find('idCliente'),
            'posicion': int(lista_elem.find('posicion').text) if lista_elem.find('posicion'),
        }
        lista_espera.append(espera)

    return lista_espera

# Función para crear las entradas en ListaEspera en Odoo
def crear_lista_espera_en_odoo(lista_espera):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()

    for espera in lista_espera:
        try:
            espera_data = {
                'x_id_actividad': espera['idActividad'],
                'x_id_horario': espera['idHorario'],
                'x_id_cliente': espera['idCliente'],
                'x_posicion': espera['posicion']
            }

            # Crear la entrada en la lista de espera en Odoo
            lista_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'x_listaespera', 'create', [espera_data]
            )
            print(f"Entrada en Lista de Espera creada en Odoo con ID: {lista_id}")
        except Exception as e:
            print(f"Error al crear entrada en Lista de Espera en Odoo: {e}")


# Llamar a la función para leer el XML y luego crear las entradas en la lista de espera en Odoo
xml_file = 'lista_espera.xml'
lista_espera = leer_xml_lista_espera(xml_file)
crear_lista_espera_en_odoo(lista_espera)
