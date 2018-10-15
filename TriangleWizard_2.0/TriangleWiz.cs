using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleWizard_2
{
    public class TriangleWiz
    {
        public TriangleWiz()
        {                
            container1 = new List<List<int>>();                             //Containers for general use, due to the alternating approach
            container2 = new List<List<int>>();
        }

        public (int, List<int>) CalculatePath(List<List<int>> bruttolist)   
        {
            int size = bruttolist.Count;
            AllPaths(bruttolist, size);                                     //Calculates indexes of all possible combinations of paths down through the triangle
            AllLists(bruttolist, size);                                     //Translates these lists of indexes to actual lists of numbers from the triangle
            ValidLists(bruttolist, size);                                   //Selects the lists of numbers that obey the alternating odd/even rule 
            (int count, int sum) = HighestSum(size);                        //Calculates the highest sum, and returns the corresponding list of numbers' index in container
         
            if (size % 2 != 0)                                              //If length of bruttolist ('height' of triangle) is odd, use data from container1
            {
                return (sum, container1[count]);                            //Returns the sum and the list containing the numbers in the path
            }
            else                                                            //Else use data from container2
            {
                return (sum, container2[count]);
            }
        }

        public (int, int) HighestSum(int size)                              //Calculates the highest sum, and returns the corresponding list of numbers' index in container
        {
            List<int> sumlist = new List<int>();
            if (size % 2 != 0)                                              //If height odd, we use data from container1
            {
                foreach (List<int> sublist in container1)                   
                {
                    int sumAf = sublist.Sum();
                    sumlist.Add(sumAf);
                }
            }
            else                                                            //If height even, we use data from container2
            {
                foreach (List<int> sublist in container2)
                {
                    int sumAf = sublist.Sum();
                    sumlist.Add(sumAf);
                }
            }
            int maxsum = sumlist.Max();
            int c = 0;
            for (int i = 0; sumlist[i] != maxsum; i++)                      //We find (in a clumsy way!!) what index the path with the highest sum has in the relevant container
            {
                c++;
            }
            return (c, maxsum);
        }

        public void ValidLists(List<List<int>> bruttolist, int size)        //Selects the lists of numbers that obey the alternating odd/even rule  
        {
            if (bruttolist[0][0] % 2 != 0)                                  //If the number at the top of the triangle is odd we continue with the following
            {
                if (size % 2 != 0)                                          //If the height of the triangle is odd, we take data from container2 
                {
                    container1.Clear();
                    foreach (List<int> path in container2)                  //We run through all possible paths in container2
                    {
                        int count = 0;                                      //Count validates if a path alternates correctly, se below
                        for (int i = 0; i < path.Count; i++)                //We run through all entries of a path, to check if they alternate correctly
                        {
                            if (i % 2 != 1)                                 //If we have a number in the path corresponding to an even row,
                            {
                                if (path[i] % 2 != 0)                       //we know it has to be odd,
                                {
                                    count++;                                //therefor we add to count
                                }
                            }
                            else                                            //If we have a number in the path corresponding to an odd row,
                            {
                                if (path[i] % 2 != 1)                       //we know it has to be even,
                                {
                                    count++;                                //therefor we add to count
                                }
                            }
                        }
                        if (count == size)                                  //Only if all parameters are met
                        {
                            container1.Add(path);                           //The path is added to the selected list
                        }
                    }
                }
                else                                                        //We repeat the above in case the height of the triangle is even, and we have to take data from container1
                {
                    container2.Clear();
                    foreach (List<int> path in container1)                  //We run through all possible paths
                    {
                        int count = 0;                                      //Count validates if a path alternates correctly, se below
                        for (int i = 0; i < path.Count; i++)
                        {
                            if (i % 2 != 1)                                 //If we have a number in the path corresponding to an even row,
                            {
                                if (path[i] % 2 != 0)                       //we know it has to be odd,
                                {
                                    count++;                                //therefor we add to count
                                }
                            }
                            else                                            //If we have a number in the path corresponding to an odd row,
                            {
                                if (path[i] % 2 != 1)                       //we know it has to be even,
                                {
                                    count++;                                //therefor we add to count
                                }
                            }
                        }
                        if (count == size)                                  //Only if all parameters are met,
                        {
                            container2.Add(path);                           //the path is added to the selected list
                        }
                    }
                }
            }
            else                                                            //Now, if the number at the top of the triangle is odd we continue with the following
            {
                if (size % 2 != 0)                                          //If the height of the triangle is odd, we take data from container2 
                {
                    container1.Clear();
                    foreach (List<int> path in container2)                  //We run through all possible paths
                    {
                        int count = 0;                                      //Count validates if a path alternates correctly, se below
                        for (int i = 0; i < path.Count; i++)                //We run through all entries of a path, to check if they alternate correctly
                        {
                            if (i % 2 != 1)                                 //If we have a number in the path corresponding to an even row,
                            {
                                if (path[i] % 2 != 1)                       //we know it has to be even,
                                {
                                    count++;                                //therefor we add to count
                                }
                            }
                            else                                            //If we have a number in the path corresponding to an odd row,
                            {
                                if (path[i] % 2 != 0)                       //we know it has to be odd,
                                {
                                    count++;                                //therefor we add to count
                                }
                            }
                        }
                        if (count == size)                                  //Only if all parameters are met,
                        {
                            container1.Add(path);                           //the path is added to the selected list
                        }
                    }
                }
                else                                                        //We repeat the above in case the height of the triangle is even, and we have to take data from container1
                {
                    container2.Clear();
                    foreach (List<int> path in container1)                  //We run through all possible paths
                    {
                        int count = 0;                                      //Count validates if a path alternates correctly, se below
                        for (int i = 0; i < path.Count; i++)
                        {
                            if (i % 2 != 1)                                 //If we have a number in the path corresponding to an even row,
                            {
                                if (path[i] % 2 != 1)                       //we know it has to be even,
                                {
                                    count++;                                //therefor we add to count
                                }
                            }
                            else                                            //If we have a number in the path corresponding to an odd row,
                            {
                                if (path[i] % 2 != 0)                       //we know it has to be odd,
                                {
                                    count++;                                //therefor we add to count
                                }
                            }
                        }
                        if (count == size)                                  //Only if all parameters are met,
                        {
                            container2.Add(path);                           //the path is added to the selected list
                        }
                    }
                }   
            }

        }

        public void AllLists(List<List<int>> bruttolist, int size)          //Translates these lists of indexes to actual lists of numbers from the triangle
        {
            if (size % 2 != 0)                                              //If the height of the triangle is odd, the relevant data is stored by AllPaths in container1 
            {
                container2.Clear();
                foreach (List<int> elem in container1)
                {
                    List<int> templiste2 = new List<int>();
                    for (int i = 0; i < size; i++)
                    {
                        templiste2.Add(bruttolist[i][elem[i]]);             //We choose the relevant numbers from the triangle and create paths with them
                    }
                    container2.Add(templiste2);
                }
            }
            else                                                            //If the height is even, data is in container2
            {
                container1.Clear();
                foreach (List<int> elem in container2)
                {
                    List<int> templiste2 = new List<int>();     
                    for (int i = 0; i < size; i++)
                    {
                        templiste2.Add(bruttolist[i][elem[i]]);             //See above
                    }
                    container1.Add(templiste2);
                }
            }
        }

        public void AllPaths(List<List<int>> bruttolist, int size)          //Calculates indexes of all possible combinations of paths down through the triangle
        {
            container1.Add(new List<int> { 0 });
            for (int i = 1; i < size; i++)
            {
                if ( i % 2 != 0 )                                           //If we run through an odd line of the triangle (with first row being row 0), we store data in container1 
                {
                    container2.Clear();
                    foreach (List<int> liste in container1)                 //We 'build' the paths step by step
                    {
                        List<int> templiste0 = new List<int>(liste);
                        templiste0.Add(liste.Last());
                        container2.Add(templiste0);

                        List<int> templiste1 = new List<int>(liste);
                        templiste1.Add(liste.Last() + 1);
                        container2.Add(templiste1);
                    }
                }
                else                                                         //If we run through an even line of the triangle (with first row being row 0), we store data in container2
                {
                    container1.Clear();
                    foreach (List<int> liste in container2)                  //We 'build' the paths step by step
                    {
                        List<int> templiste0 = new List<int>(liste);
                        templiste0.Add(liste.Last());
                        container1.Add(templiste0);

                        List<int> templiste1 = new List<int>(liste);
                        templiste1.Add(liste.Last() + 1);
                        container1.Add(templiste1);
                    }
                }
            }
        }

        public List<List<int>> container1;
        public List<List<int>> container2;
    }
}
