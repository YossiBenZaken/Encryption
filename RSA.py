import random
prime = []
def Encrypt():
    d=0
    p,q,N,phi,e,c=0,0,0,0,0,0
    while not d:
        p=prime[random.randrange(len(prime))]
        q=prime[random.randrange(len(prime))]
        N=p*q
        phi=(p-1)*(q-1)
        e = random.randrange(1,phi)
        for i in range(3,phi-1):
            if i*e % phi ==1 and e!=phi:
                d=i
                break
    print(d)
    x=int(input("Enter number to cipher:"))
    x=x**e
    c=x%N
    print(c)
    c=c**d
    x=c%N
    print(x)
    s=x**d %N
    s2=s**e %N
    if s2==x:
        print(s)
    else:
        print("no signature")
                
def PrimeNumbers():
    for i in range(2,100):
        if i >2:
            flag=True
            for j in range(2,i):
                if i%j==0:
                    flag=False
                    break
            if flag==True:
                prime.append(i)
        else:
            prime.append(i)
PrimeNumbers()
Encrypt()
