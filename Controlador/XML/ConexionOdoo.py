# conexionOdoo.py
import pyodbc
import xmlrpc.client
import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))

def conectar_sql():
    try:
        connection = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-1JIM32R\\SQLEXPRESS;DATABASE=GenteFit;Trusted_Connection=yes;')
        print("Conexión a SQL Server exitosa.")
        return connection
    except Exception as e:
        print(f"Error al conectar a SQL Server: {e}")
        return None

def conectar_odoo():
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

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
    sala_file='salas.xml',
    usuario_file='usuarios.xml'
):
    from GenteFitApp.Controlador.XML import actividad_import, cliente_import, horario_import,listaEspera_import, monitor_import, reserva_import, sala_import, usuario_import

    try:
        # Actividades
        actividades = actividad_import.leer_xml_actividad(actividad_file)
        actividad_import.crear_actividad_en_odoo(actividades)

        # Clientes
        clientes = cliente_import.leer_xml_cliente(cliente_file)
        cliente_import.crear_cliente_en_odoo(clientes)

        # Horarios
        horarios = horario_import.leer_xml_horario(horario_file)
        horario_import.crear_horario_en_odoo(horarios)

        # Lista de espera
        listas_espera = listaEspera_import.leer_xml_lista_espera(lista_espera_file)
        listaEspera_import.crear_lista_espera_en_odoo(listas_espera)

        # Monitores
        monitores = monitor_import.leer_xml_monitor(monitor_file)
        monitor_import.crear_monitor_en_odoo(monitores)

        # Reservas
        reservas = reserva_import.leer_xml_reserva(reserva_file)
        reserva_import.crear_reserva_en_odoo(reservas)

        # Salas
        salas = sala_import.leer_xml_sala(sala_file)
        sala_import.crear_salas_en_odoo(salas)

        # Usuarios
        usuarios = usuario_import.leer_xml_usuario(usuario_file)
        usuario_import.crear_usuario_en_odoo(usuarios)

        print("¡Toda la información se ha enviado a Odoo con éxito!")
    except Exception as e:
        print(f"Error al enviar información a Odoo: {e}")

def validar_configuracion_odoo(config):
    required_keys = ['url', 'db', 'username', 'password']
    for key in required_keys:
        if key not in config or not config[key]:
            raise ValueError(f"Falta la configuración de '{key}' en ODOO_CONFIG.")
