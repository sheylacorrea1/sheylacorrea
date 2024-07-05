class Estudiante:
    def __init__(self, cedula, nombre, apellido, correo, nota):
        self.cedula = cedula
        self.nombre = nombre
        self.apellido = apellido
        self.correo = correo
        self.nota = nota
        self.next = None

class ListaEnlazada:
    def __init__(self):
        self.head = None

    def agregar_estudiante(self, cedula, nombre, apellido, correo, nota):
        nuevo_estudiante = Estudiante(cedula, nombre, apellido, correo, nota)
        if nota >= 6:
            # Insertar por el inicio para aprobados
            nuevo_estudiante.next = self.head
            self.head = nuevo_estudiante
            print(f"Estudiante {nombre} {apellido} agregado al inicio (Aprobado).")
        else:
            # Insertar por el final para reprobados
            if not self.head:
                self.head = nuevo_estudiante
            else:
                current = self.head
                while current.next:
                    current = current.next
                current.next = nuevo_estudiante
            print(f"Estudiante {nombre} {apellido} agregado al final (Reprobado).")

    def buscar_estudiante(self, cedula):
        current = self.head
        while current:
            if current.cedula == cedula:
                return current
            current = current.next
        return None

    def eliminar_estudiante(self, cedula):
        current = self.head
        prev = None
        while current:
            if current.cedula == cedula:
                if prev:
                    prev.next = current.next
                else:
                    self.head = current.next
                print(f"Estudiante con cédula {cedula} eliminado con éxito.")
                return True
            prev = current
            current = current.next
        print(f"Estudiante con cédula {cedula} no encontrado.")
        return False

    def total_estudiantes(self):
        current = self.head
        aprobados = 0
        reprobados = 0
        while current:
            if current.nota >= 6:
                aprobados += 1
            else:
                reprobados += 1
            current = current.next
        return aprobados, reprobados

    def mostrar_estudiante(self, estudiante):
        if estudiante:
            print(f"Cédula: {estudiante.cedula}, Nombre: {estudiante.nombre}, Apellido: {estudiante.apellido}, Correo: {estudiante.correo}, Nota: {estudiante.nota}")
        else:
            print("Estudiante no encontrado.")

def main():
    lista = ListaEnlazada()

    while True:
        print("\nOpciones:")
        print("a. Agregar estudiante")
        print("b. Buscar estudiante por cédula")
        print("c. Eliminar estudiante")
        print("d. Total estudiantes aprobados y reprobados")
        print("e. Salir")
        opcion = input("Selecciona una opción: ").strip().lower()

        if opcion == 'a':
            cedula = input("Ingresa la cédula del estudiante: ").strip()
            nombre = input("Ingresa el nombre del estudiante: ").strip()
            apellido = input("Ingresa el apellido del estudiante: ").strip()
            correo = input("Ingresa el correo del estudiante: ").strip()
            nota = float(input("Ingresa la nota definitiva del estudiante (Escala: 1-10): ").strip())
            lista.agregar_estudiante(cedula, nombre, apellido, correo, nota)

        elif opcion == 'b':
            cedula = input("Ingresa la cédula del estudiante que buscas: ").strip()
            estudiante = lista.buscar_estudiante(cedula)
            lista.mostrar_estudiante(estudiante)

        elif opcion == 'c':
            cedula = input("Ingresa la cédula del estudiante que deseas eliminar: ").strip()
            lista.eliminar_estudiante(cedula)

        elif opcion == 'd':
            aprobados, reprobados = lista.total_estudiantes()
            print(f"Total estudiantes aprobados: {aprobados}")
            print(f"Total estudiantes reprobados: {reprobados}")

        elif opcion == 'e':
            print("Saliendo del programa.")
            break

        else:
            print("Opción no válida, por favor intenta de nuevo.")

if __name__ == "__main__":
    main()
