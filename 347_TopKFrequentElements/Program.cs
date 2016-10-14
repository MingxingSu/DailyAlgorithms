using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _347_TopKFrequentElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] {6, 0, 1, 4, 9, 7, -3, 1, -4, -8, 4, -7, -3, 3, 2, -3, 9, 5, -4, 0};
            int k = 5;
            Solution s = new Solution();
            var output = s.TopKFrequent_V3(input, k);
            Console.WriteLine("Top {0} element of int array:{1} is {2}", k, string.Join(",", input), string.Join(",", output));
        }
    }
    public class Solution
    {
        //Using array sort to sort the frequency
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            //Caculate frequency
            var freqs = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (freqs.ContainsKey(n)) freqs[n]++;
                else freqs[n] = 1;
            }

            //Build heap
            int[] heap = new int[freqs.Count];

            int pos = 0;
            foreach (var kv in freqs)
            {
                heap[pos++] = kv.Value;
            }

            Array.Sort(heap);
            int[] maxHeap = new int[k];
            int len = heap.Length - 1;
            for (int i = 0; i < k; i++)
            {
                int key = freqs.FirstOrDefault(x => x.Value == heap[len - i]).Key;
                maxHeap[i] = key;
                freqs[key] = 0;
            }

            return maxHeap;
        }

        //Using an array to save numbers to a bucket whose index is the frequency
        public IList<int> TopKFrequent_V2(int[] nums, int k)
        {
            //Caculate frequency
            var freqs = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (freqs.ContainsKey(n)) freqs[n]++;
                else freqs[n] = 1;
            }

            List<int>[] bucket = new List<int>[nums.Length + 1];

            foreach (var kv in freqs)
            {
                int freq = kv.Value;
                if (bucket[freq] == null)bucket[freq] = new List<int>();
                bucket[freq].Add(kv.Key);
            }
            List<int> res = new List<int>();
            for (int i = bucket.Length - 1; i > 0 && k > 0;--i)
            {
                if (bucket[i] != null)
                {
                    res.AddRange(bucket[i]);
                    k -= bucket[i].Count;
                }
            }

            return res;
        }

        //using max heap
        public IList<int> TopKFrequent_V3(int[] nums, int k)
        {
            //Caculate frequency
            var freqs = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (freqs.ContainsKey(n)) freqs[n]++;
                else freqs[n] = 1;
            }

            return null;
        }

    }
}
