namespace Lab3_Review;

public class Program
{
    public static int Multiply3Args(string input)
    {
        string[] numberStrings = input.Split(" ");

        if (numberStrings.Length < 3)
        {
            return 0;
        }

        int product = 1;
        for (int i = 0; i < 3; i++)
        {

            bool success = int.TryParse(numberStrings[i], out int num);
            if (success)
            {
                product *= num;

            }
            else
            {
                product *= 1;
            }

        }

        return product;
    }

    public static decimal FindAverage(decimal[] array)
    {
        decimal sum = 0;
        decimal numOfItems = array.Length;

        foreach (decimal num in array)
        {
            sum += num;
        }
        return sum / numOfItems;
    }

    public static void DrawStar()
    {
        Console.WriteLine("    *    ");
        Console.WriteLine("");
        Console.WriteLine("   ***   ");
        Console.WriteLine("");
        Console.WriteLine("  *****  ");
        Console.WriteLine("");
        Console.WriteLine(" ******* ");
        Console.WriteLine("");
        Console.WriteLine("  *****  ");
        Console.WriteLine("");
        Console.WriteLine("   ***   ");
        Console.WriteLine("");
        Console.WriteLine("    *    ");
    }

    public static int MostFrequentIntIn(int[] arr)
    {
        /* key value pair: { item: [count, initialIndex]} */
        Dictionary<int, int[]> frequencyCounter = new();
        for (int i = 0; i < arr.Length; i++)
        {
            int key = arr[i];
            if (frequencyCounter.ContainsKey(key))
            {
                frequencyCounter[key][0]++;
            }
            else
            {
                int[] countAndIndex = new int[2];
                countAndIndex[0] = 1;
                countAndIndex[1] = i;
                frequencyCounter[key] = countAndIndex;
            }

        }

        int mostFrequent = arr[0];
        int mostFrequentCount = frequencyCounter[mostFrequent][0];
        int mostFrequentIndex = frequencyCounter[mostFrequent][1];

        foreach (KeyValuePair<int, int[]> kvp in frequencyCounter)
        {
            // we are only interested in duplicates
            if (kvp.Value[0] == 1)
            {
                continue;
            }

            if (kvp.Value[0] > mostFrequentCount)
            {
                mostFrequent = kvp.Key;
                mostFrequentIndex = frequencyCounter[mostFrequent][1];
            }

            else if (kvp.Value[0] == mostFrequentCount)
            {
                if (kvp.Value[1] < mostFrequentIndex)
                {
                    mostFrequent = kvp.Key;
                }
            }
        }
        return mostFrequent;
    }

    public static int MaximumValueIn(int[] arr)
    {
        if (arr.Length < 1)
        {
            return 0;
        }
        int max = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    public static void SaveWordToFile(string word)
    {

        string filePath = "/Users/joshuacannon/Documents/words.txt";
        Console.WriteLine(filePath);

        try
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(word);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }

    public static void ReadFileContents()
    {
        string filePath = "/Users/joshuacannon/Documents/words.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public static void RemoveWordFromFile(string wordToRemove)
    {
        string filePath = "/Users/joshuacannon/Documents/words.txt";

        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Create a list to hold the updated lines
            List<string> updatedLines = new List<string>();

            // Remove the specified word from the lines
            foreach (string line in lines)
            {
                // Remove the word if it matches
                string updatedLine = line.Replace(wordToRemove, string.Empty);
                updatedLines.Add(updatedLine);
            }

            // Write the updated lines back to the file
            File.WriteAllLines(filePath, updatedLines);

            Console.WriteLine("Word removed from file successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }

    public static string[] GetWordsWithCharacterCount(string sentence)
    {
        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] result = new string[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            int characterCount = word.Length;
            result[i] = $"{word}: {characterCount}";
        }

        return result;
    }

    static void Main(string[] args)
    {
        //    //Challenge 1

        //    Console.Write("Please enter 3 numbers: ");
        //    string input = Console.ReadLine();
        //    int output = Multiply3Args(input);
        //    Console.WriteLine(output);

        //    //Challenge 2

        //    Console.WriteLine("Please enter a number between 2-10");
        //    int attempts = Convert.ToInt32(Console.ReadLine());

        //    while (attempts < 2 || attempts > 10)
        //    {
        //        Console.Write("Must be a number between 2 and 10, try again: ");
        //        attempts = Convert.ToInt32(Console.ReadLine());
        //    }

        //    decimal[] nums = new decimal[attempts];
        //    int count = 0;

        //    while (count < attempts)
        //    {

        //        Console.WriteLine($"{count + 1} of {attempts}");

        //        string input2 = Console.ReadLine();

        //        bool success = decimal.TryParse(input2, out decimal num);

        //        if (success)
        //        {
        //            if (num < 0)
        //            {
        //                Console.WriteLine("number cannot be negative, try again");
        //                continue;
        //            }

        //            nums[count] = num;
        //            count++;

        //        }
        //        else
        //        {
        //            Console.WriteLine("not a number, try again");
        //        }


        //    }
        //    decimal average = FindAverage(nums);
        //    Console.WriteLine($"{average}");


        //    //Challenge 3

        //    DrawStar();

        //    //Challenge 4

        //    int[] dupArray = { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1, 3, 3, 3 };
        //    int result = MostFrequentIntIn(dupArray);
        //    Console.WriteLine(result4);


        //    //Challenge 5
        //    int[] maxArray = { 5, 25, 99, 123, 78, 96, 555, 108, 4 };

        //    int[] maxArray = { };

        //    int result5 = MaximumValueIn(maxArray);
        //    Console.WriteLine(result5);

        //    //Challenge 6 - 8

        //    SaveWordToFile("some more words");
        //    RemoveWordFromFile("words");
        //    ReadFileContents();

        //    //Challenge 9

        //    string input = "This is a sentence about important things";
        //    string[] output = GetWordsWithCharacterCount(input);

        //    foreach (string item in output)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadLine();
    }

}

