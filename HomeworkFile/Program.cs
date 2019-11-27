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
            if (links[link] == 0) 
            return link;
            else
            return  FindLastOne(links[link]);
        }

        public void DisplayContainer()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
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
            LContainer.DisplayContainer();

            Console.ReadKey();
        }
    }
}
