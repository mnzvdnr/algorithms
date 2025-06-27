import random

n=int(input("Введите число для проверки"))
x=[]
k=0
y=1
while y==1:
   y=(random.randint(1,n-1)**((n-1)/2))%n
   y_new= (y*y)%n
   for i in range(n):
            if i==y:
                k+=1
   if(y==1):
    k+=1
   if k==20:
    print("Введённое число простое с вероятностью = ", 1-(1/2)**20)
    break
if(k<20):
    print("Число составное")