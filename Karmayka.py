n=int(input("Введите составное число для проверки"))
n0=n
k=0
a=[]#простые числа
b=[]#делители
for i in range(2,n):
    a.append(i)  
for i in a:
    j=0
    for j in range(2,i-1):
        if i%j==0:
            a[a.index(i)]=0 
            break             
while n!=1:
    for i in a:
        if i!=0 and n%i==0 and n!=1:
            b.append(i)
            n=n/i
            if n==1:
                break
k==0
for i in b:
    if (n0-1)%(i-1)==0:
        k+=1
if k==len(b) and n0>=561:
    print("Число Кармайка")
else:
    print("Не число кармайка")


        
