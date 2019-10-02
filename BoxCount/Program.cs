using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxCount
{
    class BoxCounter
    {
        static int largeSize;
        static int smallSize;

        public BoxCounter(int large, int small) {
            largeSize = large;
            smallSize = small;
        }

        public static int CountBoxes(int items, int largeBoxes, int smallBoxes) {

            Console.WriteLine("Item number: " + items);
            Console.WriteLine("Available large boxes: " + largeBoxes);
            Console.WriteLine("Available small boxes: " + smallBoxes);
            
            int largeBoxesNeeded = 0;
            int smallBoxesNeeded = 0;

            if(largeBoxes > 0)
            {
                for (int i = 1; i <= largeBoxes; i++)
                {
                    if (i * largeSize <= items)
                        largeBoxesNeeded = i;
                }
            }
            
            if(largeBoxesNeeded * largeSize < items)
            {
                if (smallBoxes > 0)
                {
                    for (int i = 1; i <= smallBoxes; i++)
                    {
                        if (i * smallSize < items - largeBoxesNeeded * largeSize + smallSize)
                            smallBoxesNeeded = i;
                    }
                }
                
            }

            //Did the items fit in the available boxes?
            if(largeBoxesNeeded * largeSize + smallBoxesNeeded * smallSize < items)
            {
                Console.WriteLine("The items did not fit in the available boxes!");

            }
            else
            {
                Console.WriteLine("Large boxes needed: " + largeBoxesNeeded);
                Console.WriteLine("    Size of a large box: " + largeSize);
                
                Console.WriteLine("Small boxes needed: " + smallBoxesNeeded);
                Console.WriteLine("    Size of a small box: " + smallSize);
                
                Console.WriteLine("Boxes needed overall: " + (largeBoxesNeeded + smallBoxesNeeded));
            }

            return 0;
        }
        
        static void Main(string[] args)
        {
            BoxCounter myBoxCounter = new BoxCounter(5,2);

            CountBoxes(21, 4, 2);
            
            Console.ReadKey();
            
        }
    }
}
