#Вивести всі двоцифрові числа, кратні 9.
for number in range(10, 100):
    if number % 9 == 0:
        print(number)
