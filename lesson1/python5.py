number = int(input("Введіть тризначне число: "))
if 100 <= number <= 999:
    hundr = number // 100
    ten = (number //10) % 10
    one = number % 10
    reversed_number = one * 100 + ten * 10 + hundr
    print("Перевернуте число: ", reversed_number)
else:
    print("Це не тризначне число.")
