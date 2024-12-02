import pyodbc
import xmlrpc.client

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
