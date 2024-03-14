//Culmination of lab excercises and tests revolving around manipulating arrays
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Arrays : MonoBehaviour
{
    [SerializeField] TMP_InputField userInput;
    [SerializeField] TextMeshProUGUI displayText;

    private int[] numbers = new int[5];
    private int index = 0;

    //On button press/submit, adds user input to the index location in the 'numbers' array
    public void inputToArray()
    {
        int inputVal;

        //check to verify if input is an int
        if(int.TryParse(userInput.text, out inputVal))
        {
            numbers[index] = inputVal;
            index++;
            userInput.text = "Enter a number..."; //resets input box display text
            displayText.text += inputVal + " "; //shows the number on screen

            //when array is full, perform the functions on the numbers
            if(index == 5)
            {
                displayText.text += "\n" + DisplayAsterix(numbers) + 
                                    "\n" + DisplayReverse(numbers) + 
                                    "\n" + AddNumbers(numbers) + 
                                    "\n" + PrintLargest(numbers) +
                                    "\n" + CountDuplicates(numbers);
            } 
        }

        //error if not an int
        else
        {
            userInput.text = "Invalid Entry";
        }
    }

    //For each num in array, loop to create line of asterix equal to the number
    private string DisplayAsterix(int[] arr)
    {
        string displayString = "Number to asterix: \n";

        //outer loop to loop through the array numbers
        for(int i = 0; i < arr.Length; i++)
        {
            string asterix = arr[i] + ": ";

            //inner loop to add * based on the number
            for(int j = 0; j < arr[i]; j++)
            {
                asterix += "*";
            }
            displayString += asterix + "\n"; 
        }

        return displayString;
    }

    //Print all numbers in reverse order based on input order
    private string DisplayReverse(int[] arr)
    {
        string displayString = "Reversed Numbers: ";

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            displayString += numbers[i] + ", ";
        }

        return displayString;
    }

    //Print the sum of numbers in the array
    private string AddNumbers(int[] arr)
    {
        int sum = 0;
        string displayString = "Sum of numbers: ";

        for(int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return displayString + sum;
    }

    //Find and print the largest number in the array
    private string PrintLargest(int[] arr)
    {
        SelectionSort(arr);
        string displayString = "Largest number: ";

        index = arr.Length - 1;
        displayString += arr[index];

        return displayString;
    }

    //Count any duplicate numbers in the array
    private string CountDuplicates(int[] arr)
    {
        string displayString = "Duplicates: ";
        int count = 1;
        int dupCount = 0;
        
        int [] arrCopy = new int[5]; //used to store a copy of the array
        int [] arrDup = new int[5]; //used to store the duplicates

        //copy the elements from arr to arrCopy and initialize arrDup
        for(int i = 0; i < arr.Length; i++)
        {
            arrCopy[i] = arr[i]; 
            arrDup[i] = 0;
        }


        //outer loop to go through arr elements
        for(int i = 0; i < arr.Length; i++)
        {
            //inner loup to go through arrCopy elements
            for(int j = 0; j < arr.Length; j++)
            {
                if(arr[i] == arrCopy[j])
                {
                    //if duplicate found, mark it with count
                    arrDup[j] = count;
                    count++;
                }
            }
            count = 1; 
        }

        //count number of duplicates from arrDup
        for(int i = 0; i < arrDup.Length; i++)
        {
            if(arrDup[i] == 2)
            {
                dupCount++;
            }
        }

        return displayString + dupCount;
    }


   void SelectionSort(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            int min = i;
            for(int j = i+1; j < arr.Length; j++)
            {
                if(arr[j] < arr[min])
                {
                    min = j;
                }
            }
            int temp = arr[min];
            arr[min] = arr[i];
            arr[i] = temp;
        }
    }

    
}