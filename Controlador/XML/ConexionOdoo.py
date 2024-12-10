# conexionOdoo.py
import pyodbc
import xmlrpc.client
from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

def conectar_sql():
    try:
        conn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-1JIM32R\\SQLEXPRESS;DATABASE=GenteFit;Trusted_Connection=yes;')
        print("Conexión a SQL Server exitosa.")
        return conn
    except Exception as e:
        print(f"Error al conectar a SQL Server: {e}")
        return None

def conectar_odoo():
    url = ODOO_CONFIG['url']
    db = ODOO_CONFIG['db']
    username = ODOO_CONFIG['username']
    password = ODOO_CONFIG['password']

    common = xmlrpc.client.ServerProxy(f'{url}/xmlrpc/2/common')
    uid = common.authenticate(db, username, password, {})

    if uid:
        print("Conexión a Odoo exitosa.")
    else:
        print("Error de autenticación con Odoo.")

    models = xmlrpc.client.ServerProxy(f'{url}/xmlrpc/2/object')
    return models, uid

def enviar_todo_a_odoo(
    actividad_file='actividades.xml',
    cliente_file='clientes.xml',
    horario_file='horarios.xml',
    lista_espera_file='lista_espera.xml',
    monitor_file='monitores.xml',
    reserva_file='reservas.xml',
    usuario_file='usuarios.xml'
):
    try:
        # Actividades
        actividades = leer_xml_actividad(actividad_file)
        crear_actividad_en_odoo(actividades)

        # Clientes
        clientes = leer_xml_cliente(cliente_file)
        crear_cliente_en_odoo(clientes)

        # Horarios
        horarios = leer_xml_horario(horario_file)
        crear_horario_en_odoo(horarios)

        # Lista de espera
        listas_espera = leer_xml_lista_espera(lista_espera_file)
        crear_lista_espera_en_odoo(listas_espera)

        # Monitores
        monitores = leer_xml_monitor(monitor_file)
        crear_monitor_en_odoo(monitores)

        # Reservas
        reservas = leer_xml_reserva(reserva_file)
        crear_reserva_en_odoo(reservas)

        # Usuarios
        usuarios = leer_xml_usuario(usuario_file)
        crear_usuario_en_odoo(usuarios)

        print("¡Toda la información se ha enviado a Odoo con éxito!")
    except Exception as e:
        print(f"Error al enviar información a Odoo: {e}")


def validar_configuracion_odoo(config):
    required_keys = ['url', 'db', 'username', 'password']
    for key in required_keys:
        if key not in config or not config[key]:
            raise ValueError(f"Falta la configuración de '{key}' en ODOO_CONFIG.")
