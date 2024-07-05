class Node:
    def __init__(self, placa, marca, modelo, año, precio):
        self.placa = placa
        self.marca = marca
        self.modelo = modelo
        self.año = año
        self.precio = precio
        self.next = None

class ListaEnlazada:
    def __init__(self):
        self.head = None

    def agregar_vehiculo(self, placa, marca, modelo, año, precio):
        nuevo_vehiculo = Node(placa, marca, modelo, año, precio)
        nuevo_vehiculo.next = self.head
        self.head = nuevo_vehiculo
        print(f"Vehículo con placa {placa} agregado con éxito.")

    def buscar_vehiculo(self, placa):
        current = self.head
        while current:
            if current.placa == placa:
                return current
            current = current.next
        return None

    def ver_vehiculos_por_año(self, año):
        current = self.head
        vehiculos = []
        while current:
            if current.año == año:
                vehiculos.append(current)
            current = current.next
        return vehiculos

    def ver_todos_vehiculos(self):
        current = self.head
        vehiculos = []
        while current:
            vehiculos.append(current)
            current = current.next
        return vehiculos

    def eliminar_vehiculo(self, placa):
        current = self.head
        prev = None
        while current:
            if current.placa == placa:
                if prev:
                    prev.next = current.next
                else:
                    self.head = current.next
                print(f"Vehículo con placa {placa} eliminado con éxito.")
                return True
            prev = current
            current = current.next
        print(f"Vehículo con placa {placa} no encontrado.")
        return False

    def mostrar_vehiculo(self, vehiculo):
        if vehiculo:
            print(f"Placa: {vehiculo.placa}, Marca: {vehiculo.marca}, Modelo: {vehiculo.modelo}, Año: {vehiculo.año}, Precio: {vehiculo.precio}")
        else:
            print("Vehículo no encontrado.")

    def mostrar_vehiculos(self, vehiculos):
        if vehiculos:
            for vehiculo in vehiculos:
                self.mostrar_vehiculo(vehiculo)
        else:
            print("No se encontraron vehículos.")

def main():
    lista = ListaEnlazada()

    while True:
        print("\nOpciones:")
        print("a. Agregar vehículo")
        print("b. Buscar vehículo por placa")
        print("c. Ver vehículos por año")
        print("d. Ver todos los vehículos registrados")
        print("e. Eliminar vehículo registrado")
        print("f. Salir")
        opcion = input("Selecciona una opción: ").strip().lower()

        if opcion == 'a':
            placa = input("Ingresa la placa del vehículo: ").strip()
            marca = input("Ingresa la marca del vehículo: ").strip()
            modelo = input("Ingresa el modelo del vehículo: ").strip()
            año = int(input("Ingresa el año del vehículo: ").strip())
            precio = float(input("Ingresa el precio del vehículo: ").strip())
            lista.agregar_vehiculo(placa, marca, modelo, año, precio)

        elif opcion == 'b':
            placa = input("Ingresa la placa del vehículo que buscas: ").strip()
            vehiculo = lista.buscar_vehiculo(placa)
            lista.mostrar_vehiculo(vehiculo)

        elif opcion == 'c':
            año = int(input("Ingresa el año de los vehículos que deseas ver: ").strip())
            vehiculos = lista.ver_vehiculos_por_año(año)
            lista.mostrar_vehiculos(vehiculos)

        elif opcion == 'd':
            vehiculos = lista.ver_todos_vehiculos()
            lista.mostrar_vehiculos(vehiculos)

        elif opcion == 'e':
            placa = input("Ingresa la placa del vehículo que deseas eliminar: ").strip()
            lista.eliminar_vehiculo(placa)

        elif opcion == 'f':
            print("Saliendo del programa.")
            break

        else:
            print("Opción no válida, por favor intenta de nuevo.")

if __name__ == "__main__":
    main()
