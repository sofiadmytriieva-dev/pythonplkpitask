#Написати програму, яка перевіряє, чи є задане число простим.
num = int(input("Число: "))

if num > 1:
    num = True
    for i in range(2/ num):
        if num % 1 == 0:
            num = False
            break
    if num:
        print(num, "— просте число")
    else:
        print(num, "— не просте число")
else:
    print(num, "— не просте число")  