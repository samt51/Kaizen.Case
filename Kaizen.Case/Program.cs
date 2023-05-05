using System;
using System.Text;

namespace Kaizen.Case
{
    class Program
    {
        static readonly string CharPool = "ACDEFGHKLMNPRTXYZ234579";
        static readonly int CodeLength = 8;



        static void Main(string[] args)
        {
            // Kodların karakter kümesi
            string characters = "ACDEFGHKLMNPRTXYZ234579";

            // Rastgele sayı üretmek için kullanılacak nesne
            Random random = new Random();

            // Kod uzunluğu
            int length = 8;

            // Kod sayısı
            int count = 100;

            // Kodları saklamak için kullanılacak dizi
            string[] codes = new string[count];

            // Kod üretimi
            for (int i = 0; i < count; i++)
            {
                StringBuilder codeBuilder = new StringBuilder();

                // Kodun her bir karakteri rastgele seçilir
                for (int j = 0; j < length; j++)
                {
                    char c = characters[random.Next(characters.Length)];
                    codeBuilder.Append(c);
                }

                string code = codeBuilder.ToString();

                // Kod daha önce oluşturulmuşsa, tekrar oluşturulur
                while (Array.IndexOf(codes, code) >= 0)
                {
                    codeBuilder.Clear();
                    for (int j = 0; j < length; j++)
                    {
                        char c = characters[random.Next(characters.Length)];
                        codeBuilder.Append(c);
                    }
                    code = codeBuilder.ToString();
                }

                codes[i] = code;
            }

            // Oluşturulan kodlar yazdırılır
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(codes[i]);
            }

            Console.ReadKey();
        }
    }
 



}

