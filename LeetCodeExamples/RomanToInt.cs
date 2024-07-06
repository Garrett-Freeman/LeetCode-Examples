using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExamples
{
    public class RomanToInt
    { 
        private static Dictionary<char, int> RomanValues { get; set; } = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
            {'H', 10000},
            {'G', 100000},
            {'F', 1000000},
            {'E', 10000000},
            {'J', 100000000},
            {'K', 1000000000}
        };

        /// <summary>
        /// O(n) time complexity because we iterate through the string
        /// O(1) space complexity because we use a dictionary with a fixed size
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual int ConvertRomanToInt(string value)
        {
            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (i + 1 < value.Length && RomanValues[value[i]] < RomanValues[value[i + 1]])
                {
                    result -= RomanValues[value[i]];
                }
                else
                {
                    result += RomanValues[value[i]];
                }
            }

            return result;
        }

        /// <summary>
        /// O(n) time complexity because we iterate through the string
        /// O(1) space complexity because we use a dictionary with a fixed size
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual string ConvertIntToRoman(int value)
        {
            StringBuilder result = new StringBuilder();
            char[] chars = value.ToString().ToCharArray();
            int charCount = chars.Length;

            for (int i = 0; i < charCount; i++)
            {
                int digit = chars[i] - '0';
                int position = charCount - i - 1;

                if (digit == 0)
                {
                    continue;
                }

                if (digit <= 3)
                {
                    for (int j = 0; j < digit; j++)
                    {
                        result.Append(RomanValues.FirstOrDefault(x => x.Value == (int)Math.Pow(10, position)).Key);
                    }
                }
                else if (digit == 4)
                {
                    result.Append(RomanValues.FirstOrDefault(x => x.Value == (int)Math.Pow(10, position)).Key);
                    result.Append(RomanValues.FirstOrDefault(x => x.Value == 5 * (int)Math.Pow(10, position)).Key);
                }
                else if (digit == 5)
                {
                    result.Append(RomanValues.FirstOrDefault(x => x.Value == 5 * (int)Math.Pow(10, position)).Key);
                }
                else if (digit <= 8)
                {
                    result.Append(RomanValues.FirstOrDefault(x => x.Value == 5 * (int)Math.Pow(10, position)).Key);
                    for (int j = 0; j < digit - 5; j++)
                    {
                        result.Append(RomanValues.FirstOrDefault(x => x.Value == (int)Math.Pow(10, position)).Key);
                    }
                }
                else if (digit == 9)
                {
                    result.Append(RomanValues.FirstOrDefault(x => x.Value == (int)Math.Pow(10, position)).Key);
                    result.Append(RomanValues.FirstOrDefault(x => x.Value == (int)Math.Pow(10, position + 1)).Key);
                }
            }


            return result.ToString();
        }
    }
}
