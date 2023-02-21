using System.Text;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {

        string[] Words = Enter_Information().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < Words.Length; i++)
        {
            Console.Write(Swap_Letters_1(Words[i]) + " ");
        }
    }

    public static string Enter_Information()
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;
        Console.WriteLine("Введите предложение: ");
        string Str = Console.ReadLine();
        Console.WriteLine("Результат замены: ");
        return Str;
    }


    public static string Swap_Letters_1(string Str)
    {
        int last_index_int = Str.Length - 1;
        var last_index = Convert.ToString(Str[last_index_int]);
        var First_index = Convert.ToString(Str[0]);
        Str = Str.Remove(last_index_int);
        if (last_index_int >= 1)
        {
            Str = Str.Remove(0, 1);
            Str = Str.Insert(0, last_index);
        }
        Str = Str.Insert(last_index_int, First_index);
        return Str;
    }
}