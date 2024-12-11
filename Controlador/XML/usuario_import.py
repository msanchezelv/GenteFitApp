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
            'password': usuario_elem.find('password').text,
            'rol': usuario_elem.find('rol').text,
        }
        usuarios.append(usuario)

    return usuarios


# Llamar a la función y mostrar los usuarios
xml_file = 'usuarios.xml'  # Nombre del archivo XML generado
usuarios = leer_xml_usuario(xml_file)

# Enviar los usuarios a Odoo
crear_usuarios_a_odoo(usuarios)
