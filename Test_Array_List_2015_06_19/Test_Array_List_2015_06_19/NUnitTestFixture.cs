using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Test_Array_List_2015_06_19
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;

        public class Manage_list
        {
            //Create an integer array to fill with random number
            private int[] listToFill = new int[1];

            /*--------------------------------------------*/
            /* Function- Fill the array with random number */
            /*------------------------------------------- */
            public void FillArray(int nValue)
            {
                //Create a random var
                Random rnd = new Random();

                //Create temp var
                int i = 0;
                int j = 0;
                int duplicate = 0;

                //Resize the array
                Array.Resize(ref listToFill, nValue);

                //Fill the array with random number 
                while (i != nValue)
                {
                    //Create random number
                    int temp = rnd.Next(nValue) + 1;

                    //Verify duplicate random number
                    for (j = 1; j <= nValue; j++)
                    {
                        if (listToFill[j - 1] == temp)
                        {
                            duplicate++;
                        }
                    }

                    if (duplicate == 0)
                    {
                        //Fill the array with unique values
                        listToFill[i] = temp;
                        i++;
                    }
                    else
                    {
                        //Reset duplicate check
                        duplicate = 0;
                    }

                }

            }

            /*-------------------------*/
            /* Get filled array         */
            /*-------------------------*/
            public int[] FilledList
            {
                get { return listToFill; }
            }


            /*-------------------------*/
            /* Get Nth value from list  */
            /*-------------------------*/
            public int GiveValue(List<int> theList, int fromEnd)
            {
                //Create temp var
                int k = 0;
                int value = 0;

                //If fromEnd > list size throw exception throw exception
                if(fromEnd>=theList.Count)
                {
                    throw new ArgumentOutOfRangeException("Invalid parameters"); 
                }
                else
                {
                    //Verify the N position from End
                    while (k != theList.Count)
                    {
                        if (k == theList.Count - fromEnd)
                        {
                            value = theList[k];
                        }
                        k++;
                    }
                }

                return value;
            }
        }


        [TestFixture]
        public class Manage_list_Test
        {
            //Create an istance for test      
            private Manage_list general = new Manage_list();

            [Test]
            public void FillArray()
            {
                //Generic array for test
                general.FillArray(7);

                //Create sum of unique values 
                int sum = 0;
                for (int i = 0; i < general.FilledList.Length; i++)
                {
                    sum = sum + general.FilledList[i];
                }

                //Check result
                Assert.AreEqual(28, sum);
            }


            [Test]
            public void GiveValue()
            {
                //Create a list for test N=4
                List<int> lst = new List<int> { 5, 16, 22, 134, 24 };
                int val = general.GiveValue(lst, 4);

                //Check result
                Assert.AreEqual(16, val);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void OutofRangeExceptionTest()
            {
                //Index value N=8 out of range 
                List<int> lst = new List<int> { 5, 16, 22, 134, 24 };
                int val = general.GiveValue(lst, 8);

            }
        }
    
}

