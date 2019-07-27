using System.Linq;

namespace Array
{
    public class ArrayGenerator
    {
        private readonly int smallSubArraySize = 4;
        private readonly int spaceForSmallSubArray = 2;

        public int[] Generate(int N)
        {
            if (N <= 0)
            {
                return new int[] { };
            }

            var array = new int[N];

            for (int i = 0; i < N; i += smallSubArraySize)
            {
                if (i + smallSubArraySize > N)
                {
                    array = FillSmallSubArray(array, i);
                }
                else
                {
                    array = FillFullSubArray(array, i);
                }
            }

            return array;
        }


        /// <summary>
        /// Will generate 2 pairs which sum to +1 and -1 what always will give 0
        /// 
        /// e.g. [2,-3,-4,5]
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="Shift"></param>
        /// <returns>Array</returns>
        private int[] FillFullSubArray(int[] Array, int Shift)
        {
            Array[Shift] = Shift + spaceForSmallSubArray;
            Array[Shift + 1] = (Shift + 1 + spaceForSmallSubArray) * (-1);
            Array[Shift + 2] = (Shift + 2 + spaceForSmallSubArray) * (-1);
            Array[Shift + 3] = Shift + 3 + spaceForSmallSubArray;

            return Array;
        }

        /// <summary>
        /// Fill leftovers
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="Shift"></param>
        /// <returns>Array</returns>
        private int[] FillSmallSubArray(int[] Array, int Shift)
        {
            if (Array.Count() - Shift == 1)
            {
                Array[Shift] = 0;
            }

            if (Array.Count() - Shift == 2)
            {
                Array[Shift] = -1;
                Array[Shift + 1] = 1;
            }

            if (Array.Count() - Shift == 3)
            {
                Array[Shift] = 0;
                Array[Shift + 1] = -1;
                Array[Shift + 2] = 1;
            }

            return Array;
        }
    }
}
