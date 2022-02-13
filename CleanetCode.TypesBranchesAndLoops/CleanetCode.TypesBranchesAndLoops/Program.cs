// See https://aka.ms/new-console-template for more information
using Examples;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Hello, World!");

// data types
{
	// value types
	{
		// structs
		{
			// numeric types
			{
				// integral types
				sbyte sbyteValue = 42;
				byte byteValue = 42;
				char charValue = 'A';
				short shortValue = 42;
				ushort ushortValue = 42;
				int intValue = 42;
				uint uintValue = 42U;
				long longValue = 42L;
				ulong ulongValue = 42UL;

				// real types
				float floatValue = 42.00F;
				double doubleValue = 42.00;

				// decimal
				decimal decimalValue = 42.00M;

				Console.WriteLine(0.1 + 0.2 == 0.3); // false
				Console.WriteLine(0.1F + 0.2F == 0.3F); // false
				Console.WriteLine(0.1M + 0.2M == 0.3M); // true
			}

			// bool
			bool IsRainToday = false;

			// GUID
			Guid guid = Guid.NewGuid();

			// Date time
			DateTime dateTime = DateTime.Now;

			// Tuple
			(string Name, int Age) person = ("Ivan", 33);

			// user defined
			StudentId studentId = new StudentId(10, 20);
		}

		// Enumeration
		Colors color = Colors.Red;
	}

	// reference types
	{
		// string
		string stringValue = "test text message";

		// array
		int[] numbers = new int[] { 1, 2, 3, 4, 5 };
		Person[] people = new Person[10]; // массив с 10 людьми

		// class
		Student student = new Student
		{
			Name = "test",
			StudentId = new StudentId(10, 20)
		};

		// record
		Person person = new Person("Ivan", 33);

		// interface
		IMovable hero = new Hero();
		// передавать направление в виде крайне не наглядно, но тут для примера 
		hero.Move(true);

		// delegate
		// делегат необычный тип данных
		// он хранит информацию о методе
		// это что то вроде ссылки на метод
		NiceFunction function = (x) => x.ToString();
		NiceFunction function1 = GetInfo;

		// в последтвие его можно будет вызывать
		Console.WriteLine(function(person));
		Console.WriteLine(function1(person));
	}
}

// немного о переменных
// их можно создавать
string name = "Александр Пономарев";
// с них можно вычитывать значения
Console.WriteLine(name);
// а также их можно переиспользовать.
name = "Михаил";
Console.WriteLine(name);

// Операторы Operators
{
	int countOfVideos = 100;
	countOfVideos = countOfVideos + 1;
	countOfVideos = ++countOfVideos;
	countOfVideos += 1;
	Console.WriteLine(countOfVideos);

	Console.WriteLine(20 + 10);
	Console.WriteLine(20 - 10);
	Console.WriteLine(20 / 10);
	Console.WriteLine(20 * 10);
	Console.WriteLine(22 % 10);

	Console.WriteLine(true || false);
	Console.WriteLine(false || false);
	Console.WriteLine(true && false);
	Console.WriteLine(true && true);

	Console.WriteLine();

	Console.WriteLine(10 > 20 || 18 < 35);
	Console.WriteLine(10 == 20);
	Console.WriteLine(10 <= 20);
	Console.WriteLine(10 != 20);
}

// Ветвление Branches
{
	// для ветвления по условиям
	bool isRainyDay = false;
	bool ambrellaAvailable = false;
	if (isRainyDay && ambrellaAvailable)
	{
		Console.WriteLine("Отлично у меня есть зонт и я смогу не промокнуть");
	}
	else if (isRainyDay && !ambrellaAvailable)
	{
		Console.WriteLine("Блин, дождь. А зонта нет");
	}
	else
	{
		Console.WriteLine("Хорошо что нет дождя");
	}

	// ветвление по конкретным значениям
	// хотя можно еще добавить и условие конечно :)
	Colors color = Colors.Red;
	switch (color)
	{
		case Colors.Red:
			Console.WriteLine("Стой и жди зеленый");
			break;
		case Colors.Yellow:
			Console.WriteLine("Еще немного нужно подожать");
			break;
		case Colors.Green:
			Console.WriteLine("Можно идти");
			break;
		default:
			Console.WriteLine("Какой то неизвестный цвет");
			break;
	}
}

// Циклы Cycles
{
	for (int i = 0; i < 100; i++)
	{
		// цикл с заданным диапозоном заначений
		// обычно используется чтобы выполнить операции
		// определенное кол-во раз
	}

	while (false)
	{
		// используется когда есть пердусловие.
		// примерно как в if.
		// Только тут будет происходить повторение пока условие истино.
	}

	do
	{
		// выполнится как минимум один раз
		// а затем проверит условие
		// продолжит выполнение, если условие истино
	} while (false);
}


// DANGER ZONE: тут возможно вам будет совсем не понятно.
// На следующих стримах я постепенно все объясню
static string GetInfo(Person person)
{
	return person.ToString();
}

// я намеренно опускаю модификаторы доступа, они будут объяснены позже.
namespace Examples
{
	// enumeration
	enum Colors
	{
		Red,
		Green,
		Yellow
	}

	struct StudentId
	{
		private int _seria;
		private int _number;
		public StudentId(int seria, int number)
		{
			_seria = seria;
			_number = number;
		}

		public int Seria => _seria;
		public int Number => _number;

		public override string ToString()
		{
			return $"{_seria}-{_number}";
		}
	}

	class Student
	{
		public StudentId StudentId { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return Name + StudentId;
		}
	}

	record Person(string Name, int Age);

	interface IMovable
	{
		void Move(bool forward);
	}

	class Hero : IMovable
	{
		public void Move(bool forward)
		{
			if (forward)
			{
				Console.WriteLine("Hero moves forward");
			}
			else
			{
				Console.WriteLine("Hero moves backward");
			}
		}
	}

	delegate string NiceFunction(Person person);
}
