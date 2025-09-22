import random

a = []
for i in range(20):
    a.append(random.randint(-100, 100))

print("Масив:", a)
print("Максимальний елемент:", max(a))