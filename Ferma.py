import random
import dict_digger as bd


n=int(input("Введите число для проверки"))
x=[]
k=0
y=1
while y==1:
   bd.y=bd.dig(random.randint(1,n-1)**((n-1)/2))%n
   if(y==1):
    y_new=(y*y)%n
   if(y==1) and (y_new==1):
    k+=1
   else:
    print("Число составное")
    break 
   if k==20:
    print("Введённое число простое с вероятностью = ", 1-(1/2)**20)
    break
'''if(k<20):
    print("Число составное")'''