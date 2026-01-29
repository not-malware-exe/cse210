class HelloWorld5x
{
    public HelloWorld5x()
    {
        for (int i=0;i<5;i++)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

class Odd1_50
{
    public Odd1_50()
    {
        string str = "";
        for (int i = 0; i < 50; i++)
        {
            int odd = i % 2;
            if (odd == 1)
            {
                str += $"{i},";
            }
        }
        Console.WriteLine(str);
    }
}

class TitleCase
{
    string capitalize(string str = "")
    {
        string up_str = str.ToUpper();
        string cap_str = "";

        bool can_up = true;
        for (int i = 0;i<str.Length;i++)
        {
            char character = str[i];
            if (character == ' ')
            {
                cap_str += character;
                can_up = true;
                continue;
            }
            if (can_up)
            {
                cap_str += up_str[i];
                can_up = false;
            }
            else
            {
                cap_str += character;
            }
        }
       
        return cap_str;
    }
    public TitleCase()
    {
        Console.WriteLine(capitalize("ur mom is phat"));
    }
}