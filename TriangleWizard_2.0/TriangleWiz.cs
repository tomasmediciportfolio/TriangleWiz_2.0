using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleWizard_2
{
    public class TriangleWiz
    {
        public TriangleWiz()
        {
            allpaths = new List<List<int>>();
            container1 = new List<List<int>>();
            container2 = new List<List<int>>();
        }

        public (int, List<int>) CalculatePath(List<List<int>> bruttolist)
        {
            int size = bruttolist.Count;
            if (size % 2 != 0) //if height odd, use container1
            {
                AllPaths(bruttolist);
                AllLists(bruttolist);
                ValidLists(bruttolist);
                (int count, int sum) = HighestSum(bruttolist);
                return (sum, container1[count]);
            }
            else //else use container2
            {
                AllPaths(bruttolist);
                AllLists(bruttolist);
                ValidLists(bruttolist);
                (int count, int sum) = HighestSum(bruttolist);
                return (sum, container2[count]);
            }
        }

        public (int, int) HighestSum(List<List<int>> bruttolist)
        {
            int size = bruttolist.Count;
            if (size % 2 != 0) //if height odd, use container1
            {
                List<int> sumlist = new List<int>();
                foreach (List<int> sublist in container1)
                {
                    int sumAf = sublist.Sum();
                    sumlist.Add(sumAf);
                }
                int maxsum = sumlist.Max();
                int c = 0;
                for (int i = 0; sumlist[i] != maxsum; i++)
                {
                    c++;
                }
                return (c, maxsum);
            }
            else //if height even, use container2
            {
                List<int> sumlist = new List<int>();
                foreach (List<int> sublist in container2)
                {
                    int sumAf = sublist.Sum();
                    sumlist.Add(sumAf);
                }
                int maxsum = sumlist.Max();
                int c = 0;
                for (int i = 0; sumlist[i] != maxsum; i++)
                {
                    c++;
                }
                return (c, maxsum);
            }
        }

        public void ValidLists(List<List<int>> bruttolist)
        {
            int size = bruttolist.Count;
            if (bruttolist[0][0] % 2 != 0) //The top row is odd
            {
                if (size % 2 != 0) //If the height of the triangle is odd, we take data from container2 
                {
                    container1.Clear();
                    foreach (List<int> path in container2) //We run through all possible paths
                    {
                        int count = 0; //Count validates if a path alternates correctly, se below
                        for (int i = 0; i < path.Count; i++) //We run through all entries of a path, to check if they alternate correctly
                        {
                            if (i % 2 != 1) //If we have a number in the path corresponding to an even row
                            {
                                if (path[i] % 2 != 0) //We know it has to be odd
                                {
                                    count++;  //Therefor we add to count
                                }
                            }
                            else  //If we have a number in the path corresponding to an odd row
                            {
                                if (path[i] % 2 != 1) //We know it has to be even
                                {
                                    count++; //Therefor we add to count
                                }
                            }
                        }
                        if (count == size) //Only if all parameters are met
                        {
                            container1.Add(path);  //The path is added to the selected list
                        }
                    }
                }
                else //We repeat the above in case the height of the triangle is even, and we have to take data from container1
                {
                    container2.Clear();
                    foreach (List<int> path in container1) //We run through all possible paths
                    {
                        int count = 0; //Count validates if a path alternates correctly, se below
                        for (int i = 0; i < path.Count; i++)
                        {
                            if (i % 2 != 1) //If we have a number in the path corresponding to an even row
                            {
                                if (path[i] % 2 != 0) //We know it has to be odd
                                {
                                    count++;  //Therefor we add to count
                                }
                            }
                            else  //If we have a number in the path corresponding to an odd row
                            {
                                if (path[i] % 2 != 1) //We know it has to be even
                                {
                                    count++; //Therefor we add to count
                                }
                            }
                        }
                        if (count == size) //Only if all parameters are met
                        {
                            container2.Add(path);  //The path is added to the selected list
                        }
                    }
                }
            }
            else
            {
                
            }

        }

        public void AllLists(List<List<int>> bruttolist)
        {
            int size = bruttolist.Count;
            if (size % 2 != 0)
            {
                container2.Clear();
                foreach (List<int> elem in container1)
                {
                    List<int> templiste2 = new List<int>();
                    for (int i = 0; i < size; i++)
                    {
                        templiste2.Add(bruttolist[i][elem[i]]);
                    }
                    container2.Add(templiste2);
                }
            }
            else
            {
                container1.Clear();
                foreach (List<int> elem in container2)
                {
                    List<int> templiste2 = new List<int>();
                    for (int i = 0; i < size; i++)
                    {
                        templiste2.Add(bruttolist[i][elem[i]]);
                    }
                    container1.Add(templiste2);
                }
            }
        }

        public void AllPaths(List<List<int>> bruttolist)
        {
            container1.Add(new List<int> { 0 });
            int size    = bruttolist.Count;

            for (int i = 1; i < size; i++)
            {
                if ( i % 2 != 0 )
                {
                    container2.Clear();
                    foreach (List<int> liste in container1)
                    {
                        List<int> templiste0 = new List<int>(liste);
                        templiste0.Add(liste.Last());
                        container2.Add(templiste0);

                        List<int> templiste1 = new List<int>(liste);
                        templiste1.Add(liste.Last() + 1);
                        container2.Add(templiste1);
                    }
                }
                else 
                {
                    container1.Clear();
                    foreach (List<int> liste in container2)
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

        public List<List<int>> allpaths;
        public List<List<int>> container1;
        public List<List<int>> container2;
    }
}
