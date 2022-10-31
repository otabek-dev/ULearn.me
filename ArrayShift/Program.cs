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

var array = new int[arrayLength];
var shift = 2;

for (int i = 0; i < arrayLength; i++)
{
	if (i + shift < arrayLength)
	{
		array[i] = shiftArray[i + shift];
	}
	else
	{
		array[i] = shiftArray[shiftArray.Length - i - shift];
		shift -= 1;
	}
}

foreach (var e in array)
	Console.Write(e + " ");