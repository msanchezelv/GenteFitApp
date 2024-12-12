import os
import sys

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))

# Función para leer el XML y obtener los datos de usuarios
def leer_xml_usuario(xml_file):
    import xml.etree.ElementTree as ET

    # Parsear el archivo XML
    tree = ET.parse(xml_file)
    root = tree.getroot()

    usuarios = []
    
    # Iterar sobre cada elemento 'Usuario' en el XML
    for usuario_elem in root.findall('Usuario'):
        usuario = {
            'idUsuario': int(usuario_elem.find('idUsuario').text),
            'nombre': usuario_elem.find('nombre').text,
            'apellidos': usuario_elem.find('apellidos').text,
            'email': usuario_elem.find('email').text,
            'password': usuario_elem.find('contraseña').text,
            'rol': usuario_elem.find('rol').text,
        }
        usuarios.append(usuario)

    return usuarios

# Función para enviar los usuarios a Odoo
def crear_usuarios_en_odoo(usuarios):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()

    for usuario in usuarios:
        try:
            usuario_data = {
                'idusuario': usuario['idUsuario'],
                'nombre': usuario['nombre'],
                'apellidos': usuario['apellidos'],
                'email': usuario['email'],
                'contrasena': usuario['password'],
                'rol': usuario['rol']
            }

            usuario_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'x_usuario', 'create', [usuario_data]
            )
            print(f"Usuario creado en Odoo con ID: {usuario_id}")
        except Exception as e:
            print(f"Error al crear usuario en Odoo: {e}")


# Llamar a la función y mostrar los usuarios
xml_file = 'usuarios.xml'  # Nombre del archivo XML generado
usuarios = leer_xml_usuario(xml_file)

# Enviar los usuarios a Odoo
crear_usuarios_en_odoo(usuarios)
