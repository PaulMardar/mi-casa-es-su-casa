<Query Kind="Program" />

// This is a LINQPad script that randomizes the records from the three csv files.

void Main()
{
	string filePath1 = @"Data\rooms.csv";
	string filePath2 = @"Data\reservations.csv";
	string filePath3 = @"Data\customers.csv";
	
	RandomizeLines(filePath1);
	RandomizeLines(filePath2);
	RandomizeLines(filePath3);
}

// Define other methods and classes here

public void RandomizeLines(string filePath)
{
	string[] lines = File.ReadAllLines(filePath);
	string[] newLines = RandomizeLines(lines);
	
	File.WriteAllLines(filePath, newLines);
}

public string[] RandomizeLines(string[] lines)
{
	if (lines.Length == 0)
		return new string[0];
		
	List<string> newLines = new List<string>();
	
	Random random = new Random();
	List<int> indexes = System.Linq.Enumerable.Range(0, lines.Length).ToList();
	
	newLines.Add(lines[0]);
	indexes.RemoveAt(0);
	
	while(indexes.Count > 0)
	{
		int i = random.Next(indexes.Count);
		int index = indexes[i];
		
		newLines.Add(lines[index]);
		
		indexes.RemoveAt(i);
	}
	
	return newLines.ToArray();
}