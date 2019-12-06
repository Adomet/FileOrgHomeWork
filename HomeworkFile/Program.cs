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
       public int numbercount = 0;

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
            numbercount++;
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

            Console.Write("LISCH :" + GetProbeCount(number, i) + ", ");
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

            Console.WriteLine("LISCH Packing factor :" + (100 * numbercount / mod) + " AVG Probe: " + (a / c));
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
        public int numbercount = 0;


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
            numbercount++;
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

            Console.Write("EISCH :" + GetProbeCount(number, i) + ", ");
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

            Console.WriteLine("EISCH Packing factor :" + (100 * numbercount / mod) + " AVG Probe: " + (a / c));
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
        public int numbercount = 0;

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
            numbercount++;
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

            Console.Write("LICH :" + GetProbeCount(number, i) + ", ");
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

            Console.WriteLine("LICH Packing factor :" + (100 * numbercount / (cellarsize+mod)) + " AVG Probe: " + (a / c));
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
        public int numbercount = 0;


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
            numbercount++;
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

            Console.Write("EICH :" + GetProbeCount(number, i) + ", ");
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

            Console.WriteLine("EICH Packing factor :" + (100*numbercount / (cellarsize+mod)) + " AVG Probe: " + (a / c));
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
        public int numbercount = 0;

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

            numbercount++;
            int i = number % mod;
            int root = i;
            int a = 1;
            int c = 0;
            if (numbers[i] != 0)
            {
                while (root != -1 && root != mod )
                {
                    if (numbers[root] != 0)
                    {

                        if (ContainerSwitch)
                        {
                            root += 1;
                            if (a == c)
                            {
                                ContainerSwitch = false;
                                c = 0;
                                a++;
                            }

                            else
                            {
                                c++;
                            }
                        }

                        else
                        {
                            root += 1;
                            if (a == c)
                            {
                                ContainerSwitch = true;
                                c = 0;
                                a++;
                            }

                            else
                            {
                                c++;
                            }
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
            Console.Write("BEISCH :" + GetProbeCount(number, i) + ", ");
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

            Console.WriteLine("BEISCH Packing factor :" + (100 * numbercount / mod) + " AVG Probe: " + (a / c));
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
        public int numbercount = 0;

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
            numbercount++;
            int i = number % mod;
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

            Console.Write("RLISCH :" + GetProbeCount(number, i)+", ");
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

            Console.WriteLine("RLISCH Packing factor :" + (100 * numbercount / mod) + " AVG Probe: " + (a / c));
            return (a / c);
        }
        public int FindLastOne(int link)
        {//gives stack overflow donno y check
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
            Console.WriteLine();
        }


    }


    class Program
    {
        static public LISCHContainer  LISCHContainer = new LISCHContainer  (11);
        static public LICHContainer   LICHContainer = new LICHContainer    (7,4);
        static public EISCHContainer  EISCHContainer = new EISCHContainer  (11);
        static public EICHContainer   EICHContainer = new EICHContainer    (7,4);
        static public BEISCHContainer BEISCHContainer = new BEISCHContainer(11);
        static public RLISCHContainer RLISCHContainer = new RLISCHContainer(11); 


        static void Main(string[] args)
        {
            //Container.DisplayContainer();
            //Container.SearchNumber(20);
            while (true)
            {
                int op = 7;
                Console.WriteLine();
                Console.WriteLine("1 - Add Random Numbers"); // Adds Random numbers how much given by the user
                Console.WriteLine("2 - Add User Numbers"); // Adds Number to all Algorithms ;
                Console.WriteLine("3 - Search");// Search All
                Console.WriteLine("4 - Show");// Show The Table,AVG probe and corrent packing factors
                Console.WriteLine("5 - Exit");// Gueass what
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        AddRandomToAll();
                        break;
                    case 2:
                        UserNumbersToAll();
                        break;
                    case 3:
                        SearchAll();
                        break;
                    case 4:
                        ShowState();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

            }


        }
        static public void AddRandomToAll()
        {
            Console.WriteLine("Random Number Count:");
            int  a = int.Parse(Console.ReadLine());
            int p = a;
            p = ((p * 10) / 9);
            p = FindNextPrime(p);
            int t = (p * 7) / 10;
            t = FindNextPrime(t);
            int c = (p * 4) / 10;
            c = FindNextPrime(c+1);

            LISCHContainer  = new LISCHContainer  (p);
            LICHContainer   =new LICHContainer    (t, c);
            EISCHContainer = new EISCHContainer   (p);
            EICHContainer   =new EICHContainer    (t, c);
            BEISCHContainer =new BEISCHContainer  (p);
            RLISCHContainer = new RLISCHContainer (p);

            Random rnd = new Random();
            for (int i = 0; i < a; i++)
            {
               int rndint= rnd.Next(0, a*10);
                Console.WriteLine();
                Console.WriteLine(rndint+" Added Probes:");
                LISCHContainer.insert(rndint);
                LICHContainer.insert(rndint);
                EISCHContainer.insert(rndint);
                EICHContainer.insert(rndint);
                BEISCHContainer.insert(rndint);
                RLISCHContainer.insert(rndint);
                //Change the insert so it can expend
            }

        }
        static public void UserNumbersToAll()
        {
            Console.WriteLine("Number :");
            int a = int.Parse(Console.ReadLine());

                LISCHContainer.insert(a);
                LICHContainer.insert(a);
                EISCHContainer.insert(a);
                EICHContainer.insert(a);
                BEISCHContainer.insert(a);
                RLISCHContainer.insert(a);

            
        }

        static public void SearchAll()
        {
            Console.WriteLine("Number :");
            int a = int.Parse(Console.ReadLine());

            LISCHContainer.SearchNumber(a);
            LICHContainer.SearchNumber(a);
            EISCHContainer.SearchNumber(a);
            EICHContainer.SearchNumber(a);
            BEISCHContainer.SearchNumber(a);
            RLISCHContainer.SearchNumber(a);
        }

        static public void ShowState()
        {
            LISCHContainer .DisplayContainer();
            LICHContainer  .DisplayContainer();
            EISCHContainer .DisplayContainer();
            EICHContainer  .DisplayContainer();
            BEISCHContainer.DisplayContainer();
            RLISCHContainer.DisplayContainer();

            double conmax = double.MaxValue;
            int a = 0;
            if (conmax > LISCHContainer.FindAvgProbe()) 
            {
                conmax = LISCHContainer.FindAvgProbe();
                a=1;
            }
            if (conmax > LICHContainer.FindAvgProbe())
            {
                conmax = LICHContainer.FindAvgProbe();
                a=2;
            }
            if (conmax > EISCHContainer.FindAvgProbe())
            {
                conmax = EISCHContainer.FindAvgProbe();
                a=3;
            }
            if (conmax > EICHContainer.FindAvgProbe())
            {
                conmax = EICHContainer.FindAvgProbe();
                a=4;
            }
            if (conmax > BEISCHContainer.FindAvgProbe())
            {
                conmax = BEISCHContainer.FindAvgProbe();
                a=5;
            }
            if (conmax > RLISCHContainer.FindAvgProbe())
            {
                conmax = RLISCHContainer.FindAvgProbe();
                a=6;
            }

            string str="";
            switch (a)
            {
                case 0:
                    break;
                case 1:
                    str = "LISCH";
                    break;
                case 2:
                    str = "LICH";
                    break;
                case 3:
                    str = "EISCH";
                    break;
                case 4:
                    str = "EICH";
                    break;
                case 5:
                    str = "BEISCH";
                    break;
                case 6:
                    str = "RLISCH";
                    break;
                default:
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("BEST ALgorithm is " + str + " AVG Probe:" +conmax);
        }

        static public int FindNextPrime(int a)
        {
            for(int i = a+1; ; i++)
            {
                if (IsPrime(i))
                    return i;
            }
        }

        static bool IsPrime(int a)
        {
            int c = 0;
            for(int i = 2;i<Math.Sqrt(a)+1;i++)
            {
                if(a%i == 0)
                {
                    c++;
                }
            }
         
            return c==0;
        }

        // Use for insert all of the containers
        static void insertAll(int number)
        {
        }
        }
}
