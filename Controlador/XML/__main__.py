import sys
from .conexionOdoo import enviar_todo_a_odoo
from .actividad_import import leer_xml_actividad, crear_actividad_en_odoo
from .cliente_import import leer_xml_cliente, crear_cliente_en_odoo
from .horario_import import leer_xml_horario, crear_horario_en_odoo
from .listaEspera_import import leer_xml_lista_espera, crear_lista_espera_en_odoo
from .monitor_import import leer_xml_monitor, crear_monitor_en_odoo
from .reserva_import import leer_xml_reserva, crear_reserva_en_odoo
from .usuario_import import leer_xml_usuario, crear_usuario_en_odoo

def main():
    if len(sys.argv) < 2:
        print("Uso: python -m GenteFitApp [opción]")
        print("Opciones:")
        print("  actividad   - Importar actividades")
        print("  cliente     - Importar clientes")
        print("  horario     - Importar horarios")
        print("  lista_espera - Importar listas de espera")
        print("  monitor     - Importar monitores")
        print("  reserva     - Importar reservas")
        print("  usuario     - Importar usuarios")
        print("  todo        - Importar todo a Odoo")
        return

    option = sys.argv[1].lower()
    
    try:
        if option == "actividad":
            actividades = leer_xml_actividad('actividades.xml')
            crear_actividad_en_odoo(actividades)
        elif option == "cliente":
            clientes = leer_xml_cliente('clientes.xml')
            crear_cliente_en_odoo(clientes)
        elif option == "horario":
            horarios = leer_xml_horario('horarios.xml')
            crear_horario_en_odoo(horarios)
        elif option == "lista_espera":
            listas_espera = leer_xml_lista_espera('lista_espera.xml')
            crear_lista_espera_en_odoo(listas_espera)
        elif option == "monitor":
            monitores = leer_xml_monitor('monitores.xml')
            crear_monitor_en_odoo(monitores)
        elif option == "reserva":
            reservas = leer_xml_reserva('reservas.xml')
            crear_reserva_en_odoo(reservas)
        elif option == "usuario":
            usuarios = leer_xml_usuario('usuarios.xml')
            crear_usuario_en_odoo(usuarios)
        elif option == "todo":
            enviar_todo_a_odoo()
        else:
            print(f"Opción desconocida: {option}")
    except Exception as e:
        print(f"Error al ejecutar la opción '{option}': {e}")

if __name__ == "__main__":
    main()
