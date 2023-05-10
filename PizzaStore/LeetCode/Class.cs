namespace PizzaStore.LeetCode
{
    public class Solution
    {
        public string MergeAlternately(string word1, string word2)
        {
            string merged = "";
            int iter = Math.Max(word1.Length, word2.Length);
           
            for (int i = 0; i < iter; i++)
            {
                if (i<=word1.Length&&word1[i] != ' ')
                {
                    merged.Append(word1[i]);
                }
                if (i <= word2.Length && word2[i] != ' ')
                {
                    merged+=word2[i];
                }

            }
            return merged;
        }
    }
}
