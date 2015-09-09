using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string tEMPS = Console.ReadLine(); // the N temperatures expressed as integers ranging from -273 to 5526
        
        // Arrays to hold temp and absolute temp
        string[] sTemp = new string[n];
        string[] sTempAbs = new string[n];
        sTemp = tEMPS.Split(' ');
        sTempAbs = tEMPS.Split(' ');
        
        // Integer arrays to store the temperatures as integers
        int[] temp = new int[n];
        int[] tempAbs = new int[n];
        
        int lowest = 0;
        int doubleNeg = 0;
       
        // Boolean flag to determine if the file is all negative numbers
        bool isNeg = false;
        
        
        // If file is not empty parse to array
        if (n != 0)
        {
            temp = sTemp.Select(x => int.Parse(x)).ToArray();
            tempAbs = sTemp.Select(x => int.Parse(x)).ToArray();
        }
        
        for (int count = 0; count < n; ++count)
        {
            
            // Store absolute values in tempAbs
            tempAbs[count] = Math.Abs(temp[count]);
            
            // Set lowest to minimum value in tempAbs
            lowest = tempAbs.Min();
            
            // If there is a single element and it is the negative edge case
            if (n == 1 && temp[count] == -273)
            {
                lowest = -273;
                break;
            }
            
            // If there are two elements which are both negative
            if ((n == 2) && (temp[count] < 0))
            {
                if (doubleNeg == temp[count])
                {
                    lowest = temp[count];
                    break;
                }
                
                doubleNeg = temp[count];
            }
        }
        
        // Determine if the file is all negative and set isNeg flag accordingly
        for (int count = 0; count < n; ++count)
        {
            if (temp[count] < 0)
            {
                isNeg = true;
            }
            else
            {
                isNeg = false;
            }
        }
        
        // If isNeg is true set lowest to highest negative value
        if (isNeg == true)
        {
            lowest = temp.Max();
        }
        
        // If the file is empty set lowest to 0
        if (n == 0)
        {
            lowest = 0;
        }

        Console.WriteLine(lowest);
    }
}
