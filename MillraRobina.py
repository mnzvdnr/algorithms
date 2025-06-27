import random
import decimal
decimal.getcontext().prec = 100


c=int(input("Введите число для проверки"))
b=c-1
y=0
if(c%2!=0):
    while y<=20:
        y+=1
        a=random.randint(1,c-1)
        z = (a**(b//2))%c
        z_new= (z*z)%c
        k=0
        for i in range(c):
            if i==z:
                k+=1
        if z_new==1 and k==0:            
            g= False
        else:
            g=True
        if g==True and y == 20:
            print("Число простое с вероятностью = ", 1-(1/c)**c)
        if g==False:
            print("Число составное")
            break
else:
    print("Число составное")


        
