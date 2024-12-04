import pyodbc
import xmlrpc.client
from .actividad_import import leer_xml_actividad, crear_actividad_en_odoo
from .cliente_import import leer_xml_cliente, crear_cliente_en_odoo
from .horario_import import leer_xml_horario, crear_horario_en_odoo
from .listaEspera_import import leer_xml_lista_espera, crear_lista_espera_en_odoo
from .monitor_import import leer_xml_monitor, crear_monitor_en_odoo
from .Reserva_import import leer_xml_reserva, crear_reserva_en_odoo
from .usuario_import import leer_xml_usuario, crear_usuario_en_odoo


# Definir la cadena de conexión para SQL Server
conn_str = 'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-1JIM32R\\SQLEXPRESS;DATABASE=GenteFit;Trusted_Connection=yes;'

ODOO_CONFIG = {
    'url': 'http://192.168.1.138:8069',  # IP de la máquina virtual
    'db': 'GenteFit',  # Nombre de la base de datos en Odoo
    'username': 'msanchezelv@uoc.edu',  # Usuario con acceso a Odoo
    'password': 'UOC.edu1'  # Contraseña del usuario
}



# Conectar a SQL Server
def conectar_sql():
    try:
        conn = pyodbc.connect(conn_str)
        print("Conexión a SQL Server exitosa.")
        return conn
    except Exception as e:
        print(f"Error al conectar a SQL Server: {e}")
        return None

# Conectar a Odoo con XML-RPC
def conectar_odoo():
    # Parámetros de conexión desde config.py
    url = ODOO_CONFIG['url']
    db = ODOO_CONFIG['db']
    username = ODOO_CONFIG['username']
    password = ODOO_CONFIG['password']
    
    # Conexión a la API de Odoo mediante XML-RPC
    common = xmlrpc.client.ServerProxy(f'{url}/xmlrpc/2/common')
    
    # Autenticación con el servidor
    uid = common.authenticate(db, username, password, {})
    
    # Conexión con el modelo de objetos de Odoo
    models = xmlrpc.client.ServerProxy(f'{url}/xmlrpc/2/object')
    
    return models, uid


def enviar_todo_a_odoo():
    try:
        # Actividades
        actividades = leer_xml_actividad('actividades.xml')
        crear_actividad_en_odoo(actividades)

        # Clientes
        clientes = leer_xml_cliente('clientes.xml')
        crear_cliente_en_odoo(clientes)

        # Horarios
        horarios = leer_xml_horario('horarios.xml')
        crear_horario_en_odoo(horarios)

        # Lista de espera
        listas_espera = leer_xml_lista_espera('lista_espera.xml')
        crear_lista_espera_en_odoo(listas_espera)

        # Monitores
        monitores = leer_xml_monitor('monitores.xml')
        crear_monitor_en_odoo(monitores)

        # Reservas
        reservas = leer_xml_reserva('reservas.xml')
        crear_reserva_en_odoo(reservas)

        # Usuarios
        usuarios = leer_xml_usuario('usuarios.xml')
        crear_usuario_en_odoo(usuarios)

        print("¡Toda la información se ha enviado a Odoo con éxito!")
    except Exception as e:
        print(f"Error al enviar información a Odoo: {e}")
