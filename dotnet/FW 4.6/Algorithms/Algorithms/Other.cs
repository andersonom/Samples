using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Other
    {
        public static bool IsPalindrome(string str)
        {  //string word = "Noel sees Leon."; 
            // IsPalindrome(word);
            string word = new string(Array.FindAll<char>(str.ToCharArray(), (c => char.IsLetterOrDigit(c)))).ToUpper();

            StringBuilder sb = new StringBuilder();

            foreach (var item in word.Reverse())
            {
                sb.Append(item);
            }

            string wordReverse = sb.ToString();

            if (word.Equals(wordReverse))
            {
                return true;
            }

            return false;
        }

        public static int NumberOfWays(int n)
        {
            int wayStep = n != 0 ? 1 : 0;

            int wayOnlyJumping = (n % 2) == 0 ? 1 : 0;

            int wayStepJumping = (n * (2.0 / 3.0)) % 2 == 0 ? 2 : 0;

            //if (wayOnlyJumping == 0 && n > 2)
            //    wayStepJumping = 2;//Forward and Backward

            return wayStep + wayOnlyJumping + wayStepJumping;


            //step 1
            //jump 2

        }
        private static void sum_up(List<int> numbers, int target)
        {
            sum_up_recursive(numbers, target, new List<int>());
        }

        private static void sum_up_recursive(List<int> numbers, int target, List<int> partial)
        {
            int s = 0;
            foreach (int x in partial) s += x;

            if (s == target)
                Console.WriteLine("sum(" + string.Join(",", partial.ToArray()) + ")=" + target);

            if (s >= target)
                return;

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> remaining = new List<int>();
                int n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++) remaining.Add(numbers[j]);

                List<int> partial_rec = new List<int>(partial);
                partial_rec.Add(n);
                sum_up_recursive(remaining, target, partial_rec);
            }

            Console.WriteLine("");
        }

        public static void Clothes()
        {
            var arr = new int[] { 10, 20, 30 };

            Console.WriteLine(arr.All(i => i > 20));
            Console.WriteLine(arr.Any(i => i > 20));
            Console.WriteLine(arr.Select(i => i / 2).ToList()[0]);

            var colours = new[] { "colour - red", "colour - blue", "colour - green", "colour - yellow" };
            var cloth = new[] { "cloth - cotton", "cloth - poly", "cloth - silk" };
            var type = new[] { "type - full", "type - half" };

            var combinations = from c in colours
                               from cl in cloth
                               from t in type
                               select new[] { c, cl, t };
        }
    }

    public class CollectionWrapper
    {
        private ICollection<Exception> _errors;
        private List<int> _data;

        //public List<int> _data { get; set; }

        public CollectionWrapper()
        {
            _data = new List<int>();
        }

        public void AddItem(int item)
        {
            _data.Add(item);
        }

        public void AddMany(IEnumerable<int> toAppend)
        {
            if (toAppend == null)
            {
                OnExceptionThrown(new ArgumentNullException("toAppend"));
            }

            _data.AddRange(toAppend);
        }

        public int GetElement(int index)
        {
            if (index < _data.Count)
            {
                return _data[index];
            }
            else
            {
                OnExceptionThrown(new IndexOutOfRangeException($"Range{index}"));
            }

            return 0;
        }

        public int CalculateSum()
        {
            return _data.Sum();
        }

        public IEnumerable<int> GetPage(int pageNumber, int pageSize)
        {
            return _data.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public int CalculateMedian()
        {
            var currentCount = _data.Count;
            if (currentCount == 0)
            {
                return 0;
            }

            _data.Sort();
            return _data[currentCount / 2];
        }

        public int GetItemByIndex(int index)
        {
            return _data[index];
        }

        public IEnumerable<int> GetItemsWhichSumToLessThan(int sum)
        {
            int total = 0, i = 0;
            foreach (var item in _data)
            {
                if (total + item >= sum) break;
                total += item;
                ++i;
            }
            return _data.Take(i);
        }

        public bool AreItemsUnique()
        {
            return _data.Distinct().Count() == _data.Count();
        }

        private void OnExceptionThrown(Exception ex)
        {
            if (_errors == null)
                _errors = new Collection<Exception>();

            _errors.Add(ex);
        }


    }
}

