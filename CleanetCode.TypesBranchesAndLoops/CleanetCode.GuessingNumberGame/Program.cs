// See https://aka.ms/new-console-template for more information
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Добро пожаловать в игру 'Угадай число'");
Console.WriteLine("Как вас зовут?");
string? userName = Console.ReadLine();
Console.WriteLine(
	$"Привет {userName}. " +
	$"Я загадал тебе число от 0 до 99. " +
	$"Попробуй отгадать");

int secretNumber = 42;
bool isWin = false;

while (!isWin)
{
	int userNumber = -1;
	bool isIntNumber = false;
	do
	{
		Console.WriteLine("Введи число от 0 до 99");
		string? userInput = Console.ReadLine();
		isIntNumber = int.TryParse(userInput, out userNumber);

		if (!isIntNumber)
		{
			Console.WriteLine($"Вы ввели {userInput}. Нужно ввести число от 0 до 99");
		}
	} while (!isIntNumber);

	if (userNumber > secretNumber)
	{
		Console.WriteLine($"Ваше число ({userNumber}) больше, чем загаданное");
	}
	else if (userNumber < secretNumber)
	{
		Console.WriteLine($"Ваше число ({userNumber}) меньше, чем загаданное");
	}
	else
	{
		isWin = true;
		Console.WriteLine("Вы победили!");
	}
}

