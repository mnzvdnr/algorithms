import random

def toBinary(n=559):
    r = []
    while (n > 0):
        r.append(n % 2)
        n = n / 2
        return r

def MillerRabin(n=559, s = 50):  
    for j in range(1, s + 1):
        a = random.randint(1, n - 1)
        b = toBinary(n - 1)
        d = 1
        for i in range(len(b) - 1, -1, -1):
            x = d
            d = (d * d) % n
            if d == 1 and x!= 1 and x != n - 1:
                return "число простое" # Составное
            if b[i] == 1:
                d = (d * a) % n
                if d != 1:
                    return "число простое" # Составное
                return "число состаное" # Простое

print(MillerRabin(2802, 20))