using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkFile 
{

    // Insert Algorithms LISCH
    // Not Celler 
    // Got root end of the chain

    public class LISCHContainer
    {
       private int mod=0;
       private int[] numbers=null;
       private int[] links = null;
       private int root;
    

       public LISCHContainer(int m_mod)
        {
            mod = m_mod;
            numbers = new int[mod];
            links = new int[mod];
            root = mod-1;
            for (int i = 0; i < links.Length; i++)
            {
                links[i] = -128;
            }
        }
        public void insert(int number)
        {
            
            int i = number % mod;
            int lastvisited = i;
            if (numbers[i] != 0)
            {
                while (root != -1) {
                    if (numbers[root] != 0)
                    {
                    root -=1;
                    }
                    else
                    {
                        numbers[root] = number;
                        links[FindLastOne(i)] = root;
                        break;
                    }
                }
            }
            else
                numbers[i] = number;
        }

        public double FindAvgProbe()
        {
            double a = 0;
            double c = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    a = a+ GetProbeCount(numbers[i], numbers[i]%mod);
                    c++;
                }
            }

            Console.WriteLine("EICH AVG Probe:" + (a / c));
            return (a / c);
        }
        public int FindLastOne (int link)
        {
            if (links[link] == -128) 
            return link;
            else
            return  FindLastOne(links[link]);
        }

        public int SearchNumber(int number)
        {
            int i = number % mod;

            int a =isNumberEQ(number, i);
            if(a==-128)
            {
                Console.WriteLine(number +": Not exits");
            }
            else
            {

                
            Console.WriteLine("Your Number:"+number+" is at:" + a + " Probe Cout is :"+ (GetProbeCount(number, i)));
            }
            return a;
        }

        public int isNumberEQ(int number,int i)
        {
            if (numbers[i] == number ) 
                return i;
            else if(links[i]== -128)
            {
                return -128;
            }
            else
                return isNumberEQ(number, links[i]);
        }
        public int GetProbeCount(int number, int i)
        {
            int a =i;
            int count = 1;
            while (links[a]!=-128)
            {
                if (numbers[a] == number)
                {
                    break;
                }
                else
                {
                    a = links[a];
                    count++;
                }
                
            }

            return count;
        }

        public void DisplayContainer()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if(links[i]==-128)
                    Console.Write("|" + i + "|" + numbers[i] + "|" + "??" + "|");
                else
                Console.Write("|" + i + "|" + numbers[i] + "|" +links[i]+"|");
                Console.WriteLine();
            }
            FindAvgProbe();
        }
    
    
    }

    // Insert Algorithms EISCH
    // NO Celler 
    // Got root Inserts a new record into a positon on the probe chain immediately after the record stored at its home address

    public class EISCHContainer
    {
        private int mod = 0;
        private int[] numbers = null;
        private int[] links = null;
        private int root;


        public EISCHContainer(int m_mod)
        {
            mod = m_mod;
            numbers = new int[mod];
            links = new int[mod];
            root = mod - 1;
            for (int i = 0; i < links.Length; i++)
            {
                links[i] = -128;
            }
        }
        public void insert(int number)
        {

            int i = number % mod;
            int lastvisited = i;
            if (numbers[i] != 0)
            {
                while (root != -1)
                {
                    if (numbers[root] != 0)
                    {
                        root -= 1;
                    }
                    else
                    {
                        numbers[root] = number;
                        //connet the chain back
                        if (links[i] != -128)
                        {
                            links[root] = links[i];
                            links[i] = root;
                        }
                        else
                            links[i] = root;
                        break;
                    }
                }
            }
            else
                numbers[i] = number;
        }

        public double FindAvgProbe()
        {
            double a = 0;
            double c = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    a = a + GetProbeCount(numbers[i], numbers[i] % mod);
                    c++;
                }
            }

            Console.WriteLine("EICH AVG Probe:" + (a / c));
            return (a / c);
        }
        public int SearchNumber(int number)
        {
            int i = number % mod;

            int a = isNumberEQ(number, i);
            if (a == -128)
            {
                Console.WriteLine(number + ": Not exits");
            }
            else
            {


                Console.WriteLine("Your Number:" + number + " is at:" + a + " Probe Cout is :" + (GetProbeCount(number, i)));
            }
            return a;
        }

        public int isNumberEQ(int number, int i)
        {
            if (numbers[i] == number)
                return i;
            else if (links[i] == -128)
            {
                return -128;
            }
            else
                return isNumberEQ(number, links[i]);
        }
        public int GetProbeCount(int number, int i)
        {
            int a = i;
            int count = 1;
            while (links[a] != -128)
            {
                if (numbers[a] == number)
                {
                    break;
                }
                else
                {
                    a = links[a];
                    count++;
                }

            }

            return count;
        }

        public void DisplayContainer()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (links[i] == -128)
                    Console.Write("|" + i + "|" + numbers[i] + "|" + "??" + "|");
                else
                    Console.Write("|" + i + "|" + numbers[i] + "|" + links[i] + "|");
                Console.WriteLine();
            }
            FindAvgProbe();
        }


    }

    // Insert Algorithms LICH
    // Got Celler 
    // Got root end of the chain
    public class LICHContainer
    {
        private int mod = 0;
        private int cellarsize = 0;
        private int listsize = 0;
        private int[] numbers = null;
        private int[] links = null;
        private int root;


        public LICHContainer(int m_mod,int m_cellarsize)
        {
            mod = m_mod;
            cellarsize = m_cellarsize;
            listsize = mod + cellarsize;
            numbers = new int[listsize];
            links = new int[listsize];
            root = listsize - 1;
            for (int i = 0; i < links.Length; i++)
            {
                links[i] = -128;
            }
        }
        public void insert(int number)
        {

            int i = number % mod;
            int lastvisited = i;
            if (numbers[i] != 0)
            {
                while (root != -1)
                {
                    if (numbers[root] != 0)
                    {
                        root -= 1;
                    }
                    else
                    {
                        numbers[root] = number;
                        links[FindLastOne(i)] = root;
                        break;
                    }
                }
            }
            else
                numbers[i] = number;
        }
        public double FindAvgProbe()
        {
            double a = 0;
            double c = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    a += GetProbeCount(numbers[i], i);
                    c++;
                }
            }

            Console.WriteLine("EICH AVG Probe:" + (a / c));
            return (a / c);
        }
        public int FindLastOne(int link)
        {
            if (links[link] == -128)
                return link;
            else
                return FindLastOne(links[link]);
        }

        public int SearchNumber(int number)
        {
            int i = number % mod;

            int a = isNumberEQ(number, i);
            if (a == -128)
            {
                Console.WriteLine(number + ": Not exits");
            }
            else
            {
                Console.WriteLine("Your Number:" + number + " is at:" + a + " Probe Cout is :" + (GetProbeCount(number, i)));
            }
            return a;
        }

        public int isNumberEQ(int number, int i)
        {
            if (numbers[i] == number)
                return i;
            else if (links[i] == -128)
            {
                return -128;
            }
            else
                return isNumberEQ(number, links[i]);
        }
        public int GetProbeCount(int number, int i)
        {
            int a = i;
            int count = 1;
            while (links[a] != -128)
            {
                if (numbers[a] == number)
                {
                    break;
                }
                else
                {
                    a = links[a];
                    count++;
                }

            }

            return count;
        }

        public void DisplayContainer()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (links[i] == -128)
                    Console.Write("|" + i + "|" + numbers[i] + "|" + "??" + "|");
                else
                    Console.Write("|" + i + "|" + numbers[i] + "|" + links[i] + "|");
                Console.WriteLine();
                if (i == (numbers.Length - cellarsize)-1)
                    Console.WriteLine("|=======|");
            }
            FindAvgProbe();
        }


    }



    // Insert Algorithms EICH
    // Got Celler 
    // Got root Iserts a new record into a positon on the probe chain immediately after the record stored at its home address

    public class EICHContainer
    {
        private int mod = 0;
        private int cellarsize = 0;
        private int listsize = 0;
        private int[] numbers = null;
        private int[] links = null;
        private int root;


        public EICHContainer(int m_mod, int m_cellarsize)
        {
            mod = m_mod;
            cellarsize = m_cellarsize;
            listsize = mod + cellarsize;
            numbers = new int[listsize];
            links = new int[listsize];
            root = listsize - 1;
            for (int i = 0; i < links.Length; i++)
            {
                links[i] = -128;
            }
        }
        public void insert(int number)
        {

            int i = number % mod;
            int lastvisited = i;
            if (numbers[i] != 0)
            {
                while (root != -1)
                {
                    if (numbers[root] != 0)
                    {
                        root -= 1;
                    }
                    else
                    {
                        numbers[root] = number;
                        //connet the chain back
                        if (links[i] != -128)
                        {
                            links[root] = links[i];
                            links[i] = root;
                        }
                        else
                            links[i] = root;
                        break;
                    }
                }
            }
            else
                numbers[i] = number;
        }
        public double FindAvgProbe()
        {
            double a = 0;
            double c = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    a = a + GetProbeCount(numbers[i], numbers[i] % mod);
                    c++;
                }
            }

            Console.WriteLine("EICH AVG Probe:" + (a / c));
            return (a / c);
        }
        public int FindLastOne(int link)
        {
            if (links[link] == -128)
                return link;
            else
                return FindLastOne(links[link]);
        }

        public int SearchNumber(int number)
        {
            int i = number % mod;

            int a = isNumberEQ(number, i);
            if (a == -128)
            {
                Console.WriteLine(number + ": Not exits");
            }
            else
            {


                Console.WriteLine("Your Number:" + number + " is at:" + a + " Probe Cout is :" + (GetProbeCount(number, i)));
            }
            return a;
        }





        public int isNumberEQ(int number, int i)
        {
            if (numbers[i] == number)
                return i;
            else if (links[i] == -128)
            {
                return -128;
            }
            else
                return isNumberEQ(number, links[i]);
        }
        public int GetProbeCount(int number, int i)
        {
            int a = i;
            int count = 1;
            while (links[a] != -128)
            {
                if (numbers[a] == number)
                {
                    break;
                }
                else
                {
                    a = links[a];
                    count++;
                }

            }

            return count;
        }

        public void DisplayContainer()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (links[i] == -128)
                    Console.Write("|" + i + "|" + numbers[i] + "|" + "??" + "|");
                else
                    Console.Write("|" + i + "|" + numbers[i] + "|" + links[i] + "|");
                Console.WriteLine();
                if (i == (numbers.Length - cellarsize) - 1)
                    Console.WriteLine("|=======|");
            }
            FindAvgProbe();
        }


    }

    // Insert Algorithms BEISCH
    // no Celler 
    // Alternating sides when inserting the number top buttom side Make switch with a bool ex: true goes up false goes down

    public class BEISCHContainer
    {
        private int mod = 0;
        private int[] numbers = null;
        private int[] links = null;
        private int root;
        private bool ContainerSwitch = false;


        public BEISCHContainer(int m_mod)
        {
            mod = m_mod;
            numbers = new int[mod];
            links = new int[mod];
            root = mod - 1;
            for (int i = 0; i < links.Length; i++)
            {
                links[i] = -128;
            }
        }
        public void insert(int number)
        {

            int i = number % mod;
            int root = i;
            if (numbers[i] != 0)
            {
                while (root != -1 || root != mod+1 )
                {
                    if (numbers[root] != 0)
                    {

                        if (ContainerSwitch)
                        {
                            root += 1;
                            ContainerSwitch = false;
                        }
                        else
                        {
                            root -= 1;
                            ContainerSwitch = true;
                        }
                    }
                    else
                    {
                        numbers[root] = number;
                        //connet the chain back
                        if (links[i] != -128)
                        {
                            links[root] = links[i];
                            links[i] = root;
                        }
                        else
                            links[i] = root;
                        break;
                    }
                }
            }
            else
                numbers[i] = number;
        }

        public double FindAvgProbe()
        {
            double a = 0;
            double c = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    a = a + GetProbeCount(numbers[i], numbers[i] % mod);
                    c++;
                }
            }

            Console.WriteLine("EICH AVG Probe:" + (a / c));
            return (a / c);
        }
        public int SearchNumber(int number)
        {
            int i = number % mod;

            int a = isNumberEQ(number, i);
            if (a == -128)
            {
                Console.WriteLine(number + ": Not exits");
            }
            else
            {


                Console.WriteLine("Your Number:" + number + " is at:" + a + " Probe Cout is :" + (GetProbeCount(number, i)));
            }
            return a;
        }

        public int isNumberEQ(int number, int i)
        {
            if (numbers[i] == number)
                return i;
            else if (links[i] == -128)
            {
                return -128;
            }
            else
                return isNumberEQ(number, links[i]);
        }
        public int GetProbeCount(int number, int i)
        {
            int a = i;
            int count = 1;
            while (links[a] != -128)
            {
                if (numbers[a] == number)
                {
                    break;
                }
                else
                {
                    a = links[a];
                    count++;
                }

            }

            return count;
        }

        public void DisplayContainer()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (links[i] == -128)
                    Console.Write("|" + i + "|" + numbers[i] + "|" + "??" + "|");
                else
                    Console.Write("|" + i + "|" + numbers[i] + "|" + links[i] + "|");
                Console.WriteLine();
            }
            FindAvgProbe();
        }


    }

    // Insert Algorithms RLISCH
    // no Celler 
    // Rondom Insertion
    // Shuffle the random root list then choose based on that list in for loop

    public class RLISCHContainer
    {
        private int mod = 0;
        private int[] numbers = null;
        private int[] links = null;
        private int root;
        private int randomturn = 0;
        private Random rd= new Random ();
        private int[] randomintarr = null;


        public RLISCHContainer(int m_mod)
        {
            mod = m_mod;
            numbers = new int[mod];
            links = new int[mod];
            root = mod - 1;
            randomturn = mod - 1;
            randomintarr = MakeRandomINTArray(mod);
           
            for (int i = 0; i < links.Length; i++)
            {
                links[i] = -128;
            }
        }
        public void insert(int number)
        {

            int i = number % mod;
            int lastvisited = i;
            if (numbers[i] != 0)
            {
                while (root != -1)
                {
                    root = randomintarr[randomturn];
                    if (numbers[root] != 0)
                    {
                        if (randomturn != 0)
                            randomturn -= 1;  
                    }
                    else
                    {
                        numbers[root] = number;
                        links[FindLastOne(i)] = root;
                        break;
                    }
                }
            }
            else
                numbers[i] = number;
        }

        public double FindAvgProbe()
        {
            double a = 0;
            double c = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    a = a + GetProbeCount(numbers[i], numbers[i] % mod);
                    c++;
                }
            }

            Console.WriteLine("EICH AVG Probe:" + (a / c));
            return (a / c);
        }
        public int FindLastOne(int link)
        {
            if (links[link] == -128)
                return link;
            else
                return FindLastOne(links[link]);
        }

        public int SearchNumber(int number)
        {
            int i = number % mod;

            int a = isNumberEQ(number, i);
            if (a == -128)
            {
                Console.WriteLine(number + ": Not exits");
            }
            else
            {


                Console.WriteLine("Your Number:" + number + " is at:" + a + " Probe Cout is :" + (GetProbeCount(number, i)));
            }
            return a;
        }

        public int[] MakeRandomINTArray (int arraysize)
        {
            int[] rndintarray = new int[arraysize];

            for (int i = 0; i < arraysize; i++)
            {
                rndintarray[i] = i;
            }

            SuffleINTArray(rndintarray);
            //DisplayArray(rndintarray);
            return rndintarray;
        }

        public int[] SuffleINTArray(int[] m_array)
        {
            for (int t = 0; t < m_array.Length; t++)
            {
                int tmp = m_array[t];
                int r = rd.Next(t, m_array.Length);
                m_array[t] = m_array[r];
                m_array[r] = tmp;
            }
            return m_array;
        }
        public void DisplayArray(int [] m_intarr)
        {
            for (int i = 0; i < m_intarr.Length; i++)
            {

                Console.Write(m_intarr[i]+", ");
            }
            
            Console.WriteLine();
        }

        public int isNumberEQ(int number, int i)
        {
            if (numbers[i] == number)
                return i;
            else if (links[i] == -128)
            {
                return -128;
            }
            else
                return isNumberEQ(number, links[i]);
        }
        public int GetProbeCount(int number, int i)
        {
            int a = i;
            int count = 1;
            while (links[a] != -128)
            {
                if (numbers[a] == number)
                {
                    break;
                }
                else
                {
                    a = links[a];
                    count++;
                }

            }

            return count;
        }

        public void DisplayContainer()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (links[i] == -128)
                    Console.Write("|" + i + "|" + numbers[i] + "|" + "??" + "|");
                else
                    Console.Write("|" + i + "|" + numbers[i] + "|" + links[i] + "|");
                Console.WriteLine();
            }
            FindAvgProbe();
        }


    }


    class Program
    {

        int[] numberlist;

        static void Main(string[] args)
        {
            //LISCHContainer  Container = new LISCHContainer(11);
            //LICHContainer   Container = new LICHContainer(7,4);
            //EISCHContainer  Container = new EISCHContainer(11);
            //EICHContainer   Container = new EICHContainer(7,4);
            //BEISCHContainer Container = new BEISCHContainer(11);
            //RLISCHContainer Container = new RLISCHContainer(11);
            //Container.DisplayContainer();
            //Container.SearchNumber(20);
            bool exit = false;
            while(!exit)
            {
                int op = 7;
                Console.WriteLine("Which Algorithm you want to use?");
                Console.WriteLine("1 - LISCH");
                Console.WriteLine("2 - EISCH");
                Console.WriteLine("3 - LICH");
                Console.WriteLine("4 - EICH");
                Console.WriteLine("5 - BEISCH");
                Console.WriteLine("6 - RLISCH");
                Console.WriteLine("7 - Exit");
                op = int.Parse(Console.ReadLine());
                if (op == 7 || op == 0)
                break;
                else
                {
                    switch (op)
                    {
                        case 1:
                            UseLISCH();
                            break;
                        case 2:
                            UseEISCH();
                            break;
                        case 3:
                            UseLICH();
                            break;
                        case 4:
                            UseEICH();
                            break;
                        case 5:
                            UseBEISCH();
                            break;
                        case 6:
                            UseRLISCH();
                            break;
                        default:                     
                            exit = true;
                            Environment.Exit(0);
                            break;
                            
                 
                    }
                }


            }

        }

        private static void UseLISCH()
        {
            Console.WriteLine("What is the mod of the algorithm?");
            int mod = int.Parse(Console.ReadLine());
            LISCHContainer Container = new LISCHContainer(mod);

            int op = 0;
            while (true)
            {


                Console.WriteLine("Options:");
                Console.WriteLine("1-Add");
                Console.WriteLine("2-Search");
                Console.WriteLine("3-Show");
                Console.WriteLine("4-Exit");
                op = int.Parse(Console.ReadLine());
                int a = 0;
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Add Key:");
                         a = int.Parse(Console.ReadLine());
                        Container.insert(a);
                        break;
                    case 2:
                        Console.WriteLine("Search Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.SearchNumber(a);
                        break;
                    case 3:
                        Container.DisplayContainer();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }



            }
        }

        private static void UseEISCH()
        {
            Console.WriteLine("What is the mod of the algorithm?");
            int mod = int.Parse(Console.ReadLine());
            EISCHContainer Container = new EISCHContainer(mod);

            int op = 0;
            while (true)
            {


                Console.WriteLine("Options:");
                Console.WriteLine("1-Add");
                Console.WriteLine("2-Search");
                Console.WriteLine("3-Show");
                Console.WriteLine("4-Exit");
                op = int.Parse(Console.ReadLine());
                int a = 0;
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Add Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.insert(a);
                        break;
                    case 2:
                        Console.WriteLine("Search Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.SearchNumber(a);
                        break;
                    case 3:
                        Container.DisplayContainer();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }



            }
        }

        private static void UseLICH()
        {
            Console.WriteLine("What is the mod of the algorithm?");
            int mod = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the size of cellar?");
            int cellarsize = int.Parse(Console.ReadLine());
            LICHContainer Container = new LICHContainer(mod, cellarsize);

            int op = 0;
            while (true)
            {


                Console.WriteLine("Options:");
                Console.WriteLine("1-Add");
                Console.WriteLine("2-Search");
                Console.WriteLine("3-Show");
                Console.WriteLine("4-Exit");
                op = int.Parse(Console.ReadLine());
                int a = 0;
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Add Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.insert(a);
                        break;
                    case 2:
                        Console.WriteLine("Search Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.SearchNumber(a);
                        break;
                    case 3:
                        Container.DisplayContainer();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }



            }
        }

        private static void UseEICH()
        {
            Console.WriteLine("What is the mod of the algorithm?");
            int mod = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the size of cellar?");
            int cellarsize = int.Parse(Console.ReadLine());
            EICHContainer Container = new EICHContainer(mod, cellarsize);

            int op = 0;
            while (true)
            {


                Console.WriteLine("Options:");
                Console.WriteLine("1-Add");
                Console.WriteLine("2-Search");
                Console.WriteLine("3-Show");
                Console.WriteLine("4-Exit");
                op = int.Parse(Console.ReadLine());
                int a = 0;
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Add Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.insert(a);
                        break;
                    case 2:
                        Console.WriteLine("Search Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.SearchNumber(a);
                        break;
                    case 3:
                        Container.DisplayContainer();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }



            }
        }

        private static void UseBEISCH()
        {
            Console.WriteLine("What is the mod of the algorithm?");
            int mod = int.Parse(Console.ReadLine());
            BEISCHContainer Container = new BEISCHContainer(mod);

            int op = 0;
            while (true)
            {


                Console.WriteLine("Options:");
                Console.WriteLine("1-Add");
                Console.WriteLine("2-Search");
                Console.WriteLine("3-Show");
                Console.WriteLine("4-Exit");
                op = int.Parse(Console.ReadLine());
                int a = 0;
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Add Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.insert(a);
                        break;
                    case 2:
                        Console.WriteLine("Search Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.SearchNumber(a);
                        break;
                    case 3:
                        Container.DisplayContainer();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }



            }
        }

        private static void UseRLISCH()
        {
            Console.WriteLine("What is the mod of the algorithm?");
            int mod = int.Parse(Console.ReadLine());
            RLISCHContainer Container = new RLISCHContainer(mod);

            int op = 0;
            while (true)
            {


                Console.WriteLine("Options:");
                Console.WriteLine("1-Add");
                Console.WriteLine("2-Search");
                Console.WriteLine("3-Show");
                Console.WriteLine("4-Exit");
                op = int.Parse(Console.ReadLine());
                int a = 0;
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Add Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.insert(a);
                        break;
                    case 2:
                        Console.WriteLine("Search Key:");
                        a = int.Parse(Console.ReadLine());
                        Container.SearchNumber(a);
                        break;
                    case 3:
                        Container.DisplayContainer();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }



            }
        }


        // Use for insert all of the containers
        static void insertAll(int number)
        {
        }
        }
}
