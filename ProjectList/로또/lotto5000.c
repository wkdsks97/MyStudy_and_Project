#include<stdio.h>
#include<stdlib.h>
#include<time.h>

int main()
{
	//2차원배열 5*7=5게임(번호 7개 추첨)
	//j의 1~6은 추첨번호, 7은 보너스 번호
	
	int lotto[5][7] ={NULL};
	int temp = 0;
	

	//변수 설정 &&초기화 값 설정
	int count = 0; //연속된 수의 쌍count
	int odd = 0; //홀
	int even = 0;//짝

	//stdlih에서 srand함수를 사용하여 랜덤난수설정
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
				if (lotto[i][k] == lotto[i][j]) //숫자 중복시 제거
				{
					j--;
					break;
				}
				if (abs(lotto[i][k] - lotto[i][j]) == 1) //연속된 숫자가 있을 경우 카운트
					count++;
			}

			if (lotto[i][j] % 2 == 0)//짝수인 경우
				even++;
			else
				odd++;
		}

		if (count > 1) //연속된 수가 2쌍이상이면 제외
		{
			i--;
			continue;
		}
		//홀수나 짝수가 각각 5개 이상인 게임은 제외한다
		if (even >= 5 || odd >= 5)
		{
			i--;
			continue;
		}

	}
	
	//숫자 순서대로 출력 (버블정렬)

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



	//출력
	//6개의 번호와 보너스 번호1개 총 7개씩
	//5게임 출력
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 7; j++)
		{
			if (j == 6) {
				printf("  보너스 번호 = %2d\n", lotto[i][j]);
			}
			else {
				printf("%2d ", lotto[i][j]);
			}
				
		}
	}
	return 0;
}