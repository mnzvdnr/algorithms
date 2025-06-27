import random
import math

array_proverki=[]
karta0=[]
print("Введите ноль для завершения считывания словаря")
l=0
while True:
    l+=1
    g = (input("Введите дороги исходящие из пункта "+ str(l))).split()
    if g[0]=="0":
        break
    else:
        karta0.append(g)
print(karta0)
n=len(karta0)
def poisk_punkta(data): #принимает словарь, возвращает пункт для объединения 
    k=random.randint(0, len(data)-1)
    a=[]
    p=0
    for i in range(len(data)):
        if i==k:
            continue
        else:
            for j in data[i]:
                if j in data[k]:
                    k2=i
                    p+=1
                    a.append(k)
                    a.append(k2)
                    return(a)
    if(p==0):
        poisk_punkta(data)

def delet(data, a): #принимает словарь рандомный пункт и пункт(для объединения)
    p1=int(a[0])
    p2=int(a[1])
    g=[]
    for i in data[p1]:
        if i not in data[p2]:
            g.append(i)
    for i in data[p2]:
        if i not in data[p1]:
            g.append(i)
    #print("дороги объеденённого пункта", g)
    return(g)
for j in range(n*10):
    karta=[]
    karta=karta0.copy()
    for i in range(n-2):
        a=[]
        a=poisk_punkta(karta) 
        #print(a)
        g=[]
        g=delet(karta,a)
        if a[0]<a[1]:
            karta.remove(karta[int(a[0])])
            karta.remove(karta[int(a[1]-1)])
        else:
            karta.remove(karta[int(a[1])])
            karta.remove(karta[int(a[0]-1)])
        karta.append(g)
        #print("новая карта", karta)
    otvet=[]
    for i in karta[0]:
        if i  in karta[1] and i not in otvet:
            otvet.append(i)
    for i in karta[1]:
        if i  in karta[0] and i not in otvet:
            otvet.append(i)
    #print("кондидат на минимальный разрез", otvet)
    array_proverki.append(otvet)
min=len(array_proverki[0])
for i in array_proverki:
    if len(i)<min:
        min=len(i)
index=[]
for i in range(len(array_proverki)):
    if len(array_proverki[i])==min:
        index.append(i)
print("минимальное количество дорог, удалив, которые граф станет не связанным = ", min, "с вероятностью >",math.exp(-10))
print("кондидаты на минимальный разрез:")
for i in index:
    print(array_proverki[i])

    
  