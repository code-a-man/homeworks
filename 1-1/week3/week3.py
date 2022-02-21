if __name__ == "__main__":
    name, surname, no = input("Name: "), input("Surname: "), int(input("No : "))
    birthday = input("Enter your birthday as dd/mm/yyyy: ").split("/")
    day, month, year = int(birthday[0]), int(birthday[1]), int(birthday[2])
    x = (day ** month)**(1/2)  # 2
    x = x / no  # 3
    x = x * year  # a4
    space = " " * day  # space for the number of days
    print(f"{name} {space} {surname}, {no**2}, {format(x, '.5f')}")
