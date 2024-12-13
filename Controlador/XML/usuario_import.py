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
            'contrasena': usuario_elem.find('contraseña').text,
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
                'x_idusuario': usuario['idUsuario'],
                'x_nombre': usuario['nombre'],
                'x_apellidos': usuario['apellidos'],
                'x_email': usuario['email'],
                'x_contrasena': usuario['contrasena'],
                'x_rol': usuario['rol']
            }

            usuario_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'x_usuario', 'create', [usuario_data]
            )
            print(f"Usuario creado en Odoo con ID: {usuario_id}")
        except Exception as e:
            print(f"Error al crear usuario en Odoo: {e}")



