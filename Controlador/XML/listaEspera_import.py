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
            'idActividad': int(lista_elem.find('idActividad').text) if lista_elem.find('idActividad') is not None else None,
            'idHorario': int(lista_elem.find('idHorario').text) if lista_elem.find('idHorario') is not None else None,
            'idCliente': int(lista_elem.find('idCliente').text) if lista_elem.find('idCliente') is not None else None,
            'posicion': int(lista_elem.find('posicion').text) if lista_elem.find('posicion') is not None else None,
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
                'activity_id': espera['idActividad'],
                'schedule_id': espera['idHorario'],
                'client_id': espera['idCliente'],
                'position': espera['posicion']
            }

            # Crear la entrada en la lista de espera en Odoo
            lista_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'gentefit.waiting_list', 'create', [espera_data]
            )
            print(f"Entrada en Lista de Espera creada en Odoo con ID: {lista_id}")
        except Exception as e:
            print(f"Error al crear entrada en Lista de Espera en Odoo: {e}")

# Llamar a la función para leer el XML y luego crear las entradas en la lista de espera en Odoo
xml_file = 'lista_espera.xml'  # Nombre del archivo XML generado
lista_espera = leer_xml_lista_espera(xml_file)
crear_lista_espera_en_odoo(lista_espera)
