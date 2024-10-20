using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));


            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);

        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> missingNumbers = new List<int>(); //List that holds missing numbers
                int n = nums.Length;

                for (int i = 0; i < n; i++)
                {
                    int index = Math.Abs(nums[i]) - 1; //Finds the index based on number's value

                    if (nums[index] > 0)  //if number is positive
                    {
                        nums[index] = -nums[index]; //Marks it as visited
                    }
                }

               
                for (int i = 0; i < n; i++)
                {
                    if (nums[i] > 0) //if number is positive
                    {
                        missingNumbers.Add(i + 1);  //Adds the missing number
                    }
                }

                return missingNumbers; //returns the list of missing numbers
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;

                // Sorts the array by parity
                while (left < right)
                {
                    // If the left element is odd and the right element is even, swaps them
                    if (nums[left] % 2 > nums[right] % 2)
                    {
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }
                    // Moves left pointer if it points to an even number
                    if (nums[left] % 2 == 0) left++;
                    // Moves right pointer if it points to an odd number
                    if (nums[right] % 2 == 1) right--;
                }

                return nums; // Return the sorted array
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw; 
            }

        }



            // Question 3: Two Sum
            public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                
                Dictionary<int, int> numDict = new Dictionary<int, int>(); // Stores the difference and its corresponding index


                for (int i = 0; i < nums.Length; i++)
                {
                    
                    int difference = target - nums[i]; // Calculates the difference required to reach the target

                    
                    if (numDict.ContainsKey(difference)) //Checks if the difference already exists in the dictionary
                    {
                        
                        return new int[] { numDict[difference], i }; // Returns the indices as an array
                    }

                   
                    if (!numDict.ContainsKey(nums[i])) // Avoids duplicates
                    {
                        numDict[nums[i]] = i; // Stores the index of the number
                    }
                }

                
                return new int[0];  // Returns an empty array if no solution found
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw; 
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
              
                Array.Sort(nums);
                int n = nums.Length;
                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3]; // Product of the three largest numbers
                int product2 = nums[0] * nums[1] * nums[n - 1]; // Product of the two smallest and the largest


                return Math.Max(product1, product2); // Returns the maximum of the two products
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw; 
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                
                if (decimalNumber == 0) // Handles the case of zero
                {
                    return "0";
                }

                string binary = string.Empty; // String to hold the binary representation

                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary; 
                    decimalNumber /= 2; // Divides the number by 2
                }

                return binary; // Returns the binary representation
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw; 
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;

                
                if (nums[left] < nums[right]) // Checks if the array is not rotated
                {
                    return nums[left]; // The smallest element is the first one
                }

                
                while (left < right) // Binary search to find the minimum element
                {
                    int mid = left + (right - left) / 2;

                    
                    if (mid < right && nums[mid] > nums[mid + 1]) // Checks if mid element is greater than its next element
                    {
                        return nums[mid + 1]; // The next element is the minimum
                    }

                    
                    if (mid > left && nums[mid] < nums[mid - 1]) // Checks if mid element is less than its previous element
                    {
                        return nums[mid]; // The mid element is the minimum
                    }

                    if (nums[mid] >= nums[left]) //Decides the search direction
                    {
                        left = mid + 1; // Searches in the right half
                    }
                    else
                    {
                        right = mid; // Searches in the left half
                    }
                }

                return nums[left]; // Returns the minimum element found
            }
            catch (Exception ex)
            { 
                Console.WriteLine("An error occurred: " + ex.Message);
                throw; 
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                
                if (x < 0) return false;

                int original = x;
                int reversed = 0;

                while (x > 0)
                {
                    int digit = x % 10; // Gets the last digit
                    reversed = reversed * 10 + digit; // Builds the reversed number
                    x /= 10; // Removes the last digit
                }

                // Checks if the original number is equal to the reversed number
                return original == reversed;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw; 
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n <= 0) return 0; // Fibonacci of 0 is 0
                if (n == 1) return 1; // Fibonacci of 1 is 1

                int a = 0, b = 1;

                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b; // Calculates the next Fibonacci number
                    a = b; // Moves to the next number in the sequence
                    b = temp; // Updates the last Fibonacci number
                }

                return b; // Returns The nth Fibonacci number
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw; 
            }
        }
    }






}




