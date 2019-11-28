using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkFile
{

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
        }
    
    
    }


    class Program
    {
        
        static void Main(string[] args)
        {
            LISCHContainer LContainer = new LISCHContainer(11);
            LContainer.insert(13);
            LContainer.insert(24);
            LContainer.insert(35);
            LContainer.insert(36);
            LContainer.insert(47);
            LContainer.insert(46);
            LContainer.insert(55);
            LContainer.insert(43);
            LContainer.insert(41);
            LContainer.insert(42);
            LContainer.insert(666);
            LContainer.DisplayContainer();
            LContainer.SearchNumber(666);
            

            Console.ReadKey();
        }
    }
}
