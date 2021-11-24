namespace Console
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (input == "")
            {
                return 0;
            }
            var result = int.Parse(input);
            return result;
        }
    }
}