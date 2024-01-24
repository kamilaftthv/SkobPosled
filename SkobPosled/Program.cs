class Program
{
    static void Main()
    {
        Console.WriteLine("введите программный код со скобками:");
        string code = Console.ReadLine();
        if (IsCorrectBracket(code))
        {
            Console.WriteLine("правильная последовательность");
        }
        else
        {
            Console.WriteLine("неправильная последовательность");
        }
        CountChar(code);
    }
    static bool IsCorrectBracket(string code)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char symbol in code)
        {
            if (IsOpeningBracket(symbol))
            {
                stack.Push(symbol);
            }
            else if (IsClosingBracket(symbol))
            {
                if (stack.Count == 0 || !IsPair(stack.Pop(), symbol))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
    static bool IsOpeningBracket(char bracket)
    {
        return bracket == '(' || bracket == '{' || bracket == '[';
    }
    static bool IsClosingBracket(char bracket)
    {
        return bracket == ')' || bracket == '}' || bracket == ']';
    }
    static bool IsPair(char openBracket, char closeBracket)
    {
        return (openBracket == '(' && closeBracket == ')')||
               (openBracket == '{' && closeBracket == '}')||
               (openBracket == '[' && closeBracket == ']');
    }
    static void CountChar(string code)
    {
        int EnUpperCase = 0;
        int EnLowerCase = 0;
        int RuUpperCase = 0;
        int RuLowerCase = 0;
        int digits = 0;
        int other = 0;
        foreach (char symbol in code)
        {
            if (char.IsUpper(symbol))
            {
                if (char.IsLetter(symbol) && symbol <= 'Z')
                {
                    EnUpperCase++;
                }
                else if (symbol >= 'А' && symbol <= 'Я')
                {
                    RuUpperCase++;
                }
            }
            else if (char.IsLower(symbol))
            {
                if (char.IsLetter(symbol) && symbol <= 'z')
                {
                    EnLowerCase++;
                }
                else if (symbol >= 'а' && symbol <= 'я')
                {
                    RuLowerCase++;
                }
            }
            else if (char.IsDigit(symbol))
            {
                digits++;
            }
            else
            {
                other++;
            }
        }
        Console.WriteLine("EnUpperCase: " + EnUpperCase);
        Console.WriteLine("EnLowerCase: " + EnLowerCase);
        Console.WriteLine("RuUpperCase: " + RuUpperCase);
        Console.WriteLine("RuLowerCase: " + RuLowerCase);
        Console.WriteLine("Digits: " + digits);
        Console.WriteLine("Other: " + other);
    }
}