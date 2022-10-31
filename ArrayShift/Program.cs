using ArrayShift;

int arrayLength;
while (true)
{
	Console.Write("Enter array length: ");
	var userLength = Console.ReadLine();
	if (int.TryParse(userLength,out arrayLength))
		break;

	Console.WriteLine("Error!");
}

var shiftArray = new int[arrayLength];

for (int i = 0; i < shiftArray.Length; i++)
	shiftArray[i] = i + 1;



shiftArray.ShiftLeft(3);
shiftArray.Print();
shiftArray.ShiftRight(1);
shiftArray.Print();