import json
import xmlrpc.client
import os
import sys
import chardet

sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '../../..')))

url = "http://192.168.1.165:8069"
db = "GenteFit"
username = "msanchezelv@uoc.edu"
password = "UOC.edu1"

common = xmlrpc.client.ServerProxy(f"{url}/xmlrpc/2/common")
uid = common.authenticate(db, username, password, {})

models = xmlrpc.client.ServerProxy(f"{url}/xmlrpc/2/object")

modelos_odoo = ['x_actividad', 'x_cliente', 'x_horario', 'x_monitor', 'x_sala', 'x_usuario']

def corregir_codificacion(valor):
    try:
        result = chardet.detect(valor.encode())
        encoding = result['encoding']
        if encoding:
            return valor.encode(encoding).decode('utf-8', errors='replace')
        else:
            return valor.encode('utf-8', errors='replace').decode('utf-8')
    except Exception as e:
        print(f"Error al corregir la codificación: {e}")
        return valor

def obtener_datos(modelo):
    try:
        datos = models.execute_kw(db, uid, password, modelo, 'search_read', [[]])
        # print(f"Datos obtenidos de Odoo para el modelo {modelo}:")
        # print(json.dumps(datos, indent=4, ensure_ascii=False))

        for registro in datos:
            for clave, valor in registro.items():
                if isinstance(valor, str):
                    registro[clave] = corregir_codificacion(valor)
                    
        return datos
    
    except Exception as e:
        print(f"Error al obtener los datos del modelo {modelo}: {e}")
        return []

def sincronizar_modelos():
    for modelo in modelos_odoo:
        
        from GenteFitApp.Controlador.XML.actividad_export import obtener_datos_actividad, guardar_datos_actividad
        from GenteFitApp.Controlador.XML.cliente_export import obtener_datos_cliente, guardar_datos_cliente
        from GenteFitApp.Controlador.XML.horario_export import obtener_datos_horario, guardar_datos_horario
        from GenteFitApp.Controlador.XML.monitor_export import obtener_datos_monitor, guardar_datos_monitor
        from GenteFitApp.Controlador.XML.sala_export import obtener_datos_sala, guardar_datos_sala
        from GenteFitApp.Controlador.XML.usuario_export import obtener_datos_usuario, guardar_datos_usuario

        mapeo_modelos = {
            'x_actividad': {
                'obtener': obtener_datos_actividad,
                'guardar': guardar_datos_actividad
            },
            'x_cliente': {
                'obtener': obtener_datos_cliente,
                'guardar': guardar_datos_cliente
            },
            'x_horario': {
                'obtener': obtener_datos_horario,
                'guardar': guardar_datos_horario
            },
            'x_monitor': {
                'obtener': obtener_datos_monitor,
                'guardar': guardar_datos_monitor
            },
            'x_sala': {
                'obtener': obtener_datos_sala,
                'guardar': guardar_datos_sala
            },
            'x_usuario': {
                'obtener': obtener_datos_usuario,
                'guardar': guardar_datos_usuario
            }
        }

        print(f"Sincronizando datos para el modelo: {modelo}")
        datos = obtener_datos(modelo)

        if modelo in mapeo_modelos:
            obtener_func = mapeo_modelos[modelo]['obtener']
            guardar_func = mapeo_modelos[modelo]['guardar']

            if datos:
                guardar_func(datos)
                print(f"Sincronización completada para el modelo: {modelo}")
        else:
            print(f"Modelo {modelo} no encontrado en el mapeo. No se puede sincronizar.")

sincronizar_modelos()


