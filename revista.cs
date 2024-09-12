def catalogo_revistas():
    revistas = [
        "National Geographic", "Scientific American", "Forbes", "Time", "Nature",
        "Popular Science", "The Economist", "Wired", "Vogue", "Harvard Business Review"
    ]

    while True:
        # Menu
        print("Menu:")
        print("1. Buscar un titulo (Busqueda Iterativa)")
        print("2. Buscar un titulo (Busqueda Recursiva)")
        print("3. Salir")
        opcion = input("Seleccione una opcion: ")

        if opcion == "1":
            buscar_iterativa(revistas)
        elif opcion == "2":
            buscar_recursiva(revistas)
        elif opcion == "3":
            break
        else:
            print("Opcion no valida. Intente nuevamente.")


def buscar_iterativa(revistas):
    titulo = input("Ingrese el titulo de la revista a buscar: ")
    encontrado = False

    for revista in revistas:
        if revista.lower() == titulo.lower():
            encontrado = True
            break

    print("Encontrado" if encontrado else "No encontrado")


def buscar_recursiva(revistas):
    titulo = input("Ingrese el titulo de la revista a buscar: ")
    encontrado = buscar_recursiva_helper(revistas, titulo, 0)
    print("Encontrado" if encontrado else "No encontrado")


def buscar_recursiva_helper(revistas, titulo, index):
    if index >= len(revistas):
        return False

    if revistas[index].lower() == titulo.lower():
        return True

    return buscar_recursiva_helper(revistas, titulo, index + 1)


# Ejecucion del programa
catalogo_revistas()
