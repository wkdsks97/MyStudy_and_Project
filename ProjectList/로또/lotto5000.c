#include<stdio.h>
#include<stdlib.h>
#include<time.h>

int main()
{
	//2�����迭 5*7=5����(��ȣ 7�� ��÷)
	//j�� 1~6�� ��÷��ȣ, 7�� ���ʽ� ��ȣ
	
	int lotto[5][7] ={NULL};
	int temp = 0;
	

	//���� ���� &&�ʱ�ȭ �� ����
	int count = 0; //���ӵ� ���� ��count
	int odd = 0; //Ȧ
	int even = 0;//¦

	//stdlih���� srand�Լ��� ����Ͽ� ������������
	srand((unsigned int)time(NULL));

	for (int i = 0; i < 5; i++) 
	{
		count = 0;
		even = 0;
		odd = 0;
		for (int j = 0; j < 7; j++)
		{
			lotto[i][j] = rand() % 45 + 1;
			for (int k = 0; k < j; k++)
			{
				if (lotto[i][k] == lotto[i][j]) //���� �ߺ��� ����
				{
					j--;
					break;
				}
				if (abs(lotto[i][k] - lotto[i][j]) == 1) //���ӵ� ���ڰ� ���� ��� ī��Ʈ
					count++;
			}

			if (lotto[i][j] % 2 == 0)//¦���� ���
				even++;
			else
				odd++;
		}

		if (count > 1) //���ӵ� ���� 2���̻��̸� ����
		{
			i--;
			continue;
		}
		//Ȧ���� ¦���� ���� 5�� �̻��� ������ �����Ѵ�
		if (even >= 5 || odd >= 5)
		{
			i--;
			continue;
		}

	}
	
	//���� ������� ��� (��������)

	for (int i = 0; i < 5; i++)
		for (int j = 0; j < 6; j++)
			for (int k = 0; k < j; k++)
			{
				if (lotto[i][j] < lotto[i][k])
				{
					temp = lotto[i][j];
					lotto[i][j] = lotto[i][k];
					lotto[i][k] = temp;
				}
			}



	//���
	//6���� ��ȣ�� ���ʽ� ��ȣ1�� �� 7����
	//5���� ���
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 7; j++)
		{
			if (j == 6) {
				printf("  ���ʽ� ��ȣ = %2d\n", lotto[i][j]);
			}
			else {
				printf("%2d ", lotto[i][j]);
			}
				
		}
	}
	return 0;
}