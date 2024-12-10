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
            'contraseña': usuario_elem.find('contraseña').text,
            'rol': usuario_elem.find('rol').text,
        }
        usuarios.append(usuario)

    return usuarios

# Función para enviar los usuarios a Odoo
def enviar_usuarios_a_odoo(usuarios):
    from GenteFitApp.Controlador.XML.conexionOdoo import conectar_odoo
    from GenteFitApp.Controlador.XML.config import ODOO_CONFIG

    models, uid = conectar_odoo()  # Conectar a Odoo
    
    for usuario in usuarios:
        # Preparar los datos para el registro en Odoo
        values = {
            'name': usuario['nombre'],
            'last_name': usuario['apellidos'],
            'email': usuario['email'],
            'password': usuario['contraseña'],
            'role': usuario['rol']
        }

        try:
            # Crear el usuario en Odoo (suponiendo que el modelo de usuario es 'res.users')
            user_id = models.execute_kw(
                ODOO_CONFIG['db'], uid, ODOO_CONFIG['password'],
                'res.users', 'create', [values]
            )
            print(f"Usuario creado en Odoo con ID: {user_id}")
        except Exception as e:
            print(f"Error al crear usuario en Odoo: {e}")

# Llamar a la función y mostrar los usuarios
xml_file = 'usuarios.xml'  # Nombre del archivo XML generado
usuarios = leer_xml_usuario(xml_file)

# Enviar los usuarios a Odoo
enviar_usuarios_a_odoo(usuarios)
