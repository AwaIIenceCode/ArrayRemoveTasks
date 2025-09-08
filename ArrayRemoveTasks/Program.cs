using System;

class MyClass
{
    /// <summary>
    /// method for generating random array 
    /// </summary>
    static void GenerateArray(int[] mainArray)
    {
        Random rnd = new Random();

        for (int i = 0; i < mainArray.Length; i++)
        {
            mainArray[i] = rnd.Next(-21, 21);
        }
    }

    /// <summary>
    /// method for showing array
    /// </summary>
    static void ShowArray(int[] mainArray)
    {
        Console.WriteLine();
        
        for (int i = 0; i < mainArray.Length; i++)
        {
            Console.Write(mainArray[i] + " ");
        }
    }

    /// <summary>
    /// method for delete number from the end of an array
    /// </summary>
    static void RemoveFromEnd(ref int[] mainArray)
    {
        int[] tempArray = new int [mainArray.Length - 1];

        Array.Copy(mainArray,0, tempArray, 0, mainArray.Length - 1);
        
        mainArray = tempArray;
        
        ShowArray(mainArray);
    }

    /// <summary>
    /// method for delete number from the start of an array
    /// </summary>
    static void RemoveFromStart(ref int[] mainArray)
    {
        int[] tempArray = new int [mainArray.Length - 1];

        Array.Copy(mainArray, 1, tempArray, 0, mainArray.Length - 1);
        
        mainArray = tempArray;
        
        ShowArray(mainArray);
    }

    /// <summary>
    /// method for delete number fron the user index of an array
    /// </summary>
    static void RemoveAtIndex(ref int[] mainArray)
    {
        Console.Write("Enter the index to remove an element from the array -> ");
        if (!int.TryParse(Console.ReadLine(), out int userIndex) || userIndex >= mainArray.Length || userIndex <= 0) { Console.WriteLine("Must be in array range!"); return; }

        if (mainArray.Length == 0) { Console.WriteLine("Your array is empty!"); return; }
        
        int[] tempArray = new int[mainArray.Length - 1];
        
        Array.Copy(mainArray, 0, tempArray, 0, userIndex);
        Array.Copy(mainArray, userIndex, tempArray, userIndex - 1, mainArray.Length - userIndex);

        mainArray = tempArray;
        
        ShowArray(mainArray);
    }

    static void Main()
    {
        Console.Write("Enter the size your array (0-1000) -> ");
        if (!int.TryParse(Console.ReadLine(), out int mainSize) || mainSize <= 0 || mainSize > 1000)
        {
            Console.WriteLine("Size must be 0 - 1000!");
            return;
        }

        int[] mainArray = new int[mainSize];

        GenerateArray(mainArray);

        while (true)
        {
            Console.WriteLine("\n\n1 - for showing full array" +
                              "\n2 - for delete number from the end at an array" +
                              "\n3 - for delete number from the start at an array" +
                              "\n4 - for delete number to index of an array" +
                              "\nWrite \"Exit\" for exit the program");

            Console.Write("\nEnter your choice -> ");

            string userChoice = Console.ReadLine()?.ToLower();

            switch (userChoice)
            {
                case "1":
                    ShowArray(mainArray); break;

                case "2":
                    RemoveFromEnd(ref mainArray); break;

                case "3":
                    RemoveFromStart(ref mainArray); break;
                
                case "4":
                    RemoveAtIndex(ref mainArray); break;

                case "exit":
                    return;

                default:
                    Console.WriteLine("Try again..."); break;
            }
        }
    }
}