/*
Yossi Ben Zaken Cryptography
*/
#include <stdio.h>
int A[2][2] = { {3,3},{2,5} }, vec1[4] = { 0 }, vec2[4] = { 0 };
int GetScalar(int num) {
	for (int i = 0; i < 26; i++)
	{
		if ((i*num) % 26 == 1) return i;
	}
}
void InvertMat(int A[][2])
{
	int temp,det;
	det = A[0][0] * A[1][1] - A[0][1] * A[1][0];
	temp = A[0][0];
	A[0][0] = A[1][1];
	A[1][1] = temp;
	A[0][1] *= -1;
	A[1][0] *= -1;
	if (A[0][1] < 0)A[0][1] += 26;
	if (A[1][0] < 0)A[1][0] += 26;
	temp = GetScalar(det);
	for (int i = 0; i < 4; i++)
	{
		A[0][i] *= temp;
		A[0][i] %= 26;
	}
}
void Encrypt() {
	printf("Encrypt Text:\n");
	for (int i = 0; i < 4; vec2[i] = (vec1[i] * A[0][0] + vec1[i + 1] * A[0][1]) % 26, vec2[i + 1] = (vec1[i] * A[1][0] + vec1[i + 1] * A[1][1]) % 26, i += 2);
	for (int i = 0; i < 4; vec1[i]=0, i++);
	for (int i = 0; i < 4; printf("%c", vec2[i] + 'a'), i++);
}
void Decrypt() {
	printf("Decrypt Text:\n");
	for (int i = 0; i < 4; vec1[i] = (vec2[i] * A[0][0] + vec2[i + 1] * A[0][1]) % 26, vec1[i + 1] = (vec2[i] * A[1][0] + vec2[i + 1] * A[1][1]) % 26, i += 2);
	for (int i = 0; i < 4; printf("%c", vec1[i] + 'a'), i++);
}
void main()
{
	int i = 0;
	char str[5];
	printf("Enter string (4 chars):\n");
	gets(str);
	while (str[i])
	{
		vec1[i] = str[i] - 'a';
		i++;
	}
	Encrypt();
	InvertMat(A);
	printf("\n");
	Decrypt();
	printf("\n");
}