using System;

public class Solution {

    public IList<string> LetterCombinations(string digits,int i = 0) {
        Dictionary<char,char[]> digitLetters = new Dictionary<char,char[]>()
        {
            {'2',['a','b','c']},
            {'3',['d','e','f']},
            {'4',['g','h','i']},
            {'5',['j','k','l']},
            {'6',['m','n','o']},
            {'7',['p','q','r','s']},
            {'8',['t','u','v']},
            {'9',['w','x','y','z']}
        };
        IList<string> returningCombinations = [];

        foreach (char letter in digitLetters[digits[i]])
        {
            if (i < digits.Length)
            {
                IList<string> resultCombinations = LetterCombinations(digits,i+1);
                foreach (string resultCombination in resultCombinations)
                {
                    returningCombinations.Add(resultCombination + letter);
                }
            }
            else
            {
                returningCombinations.Add(new string([letter]));
            }
        }

        return returningCombinations;
    }
}