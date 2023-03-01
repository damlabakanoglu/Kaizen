using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FirstQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kullanıcının yönlendirilmesi bu alanda yapılmıştır
            Console.WriteLine("Üretilmesi talep edilen kod sayısını giriniz:");
            var requestCount = Console.ReadLine();
            int number;
            var response = new List<string>();
            do
            {
                //Kullanıcının tam sayı değeri dışında değer girmesi engellenmesi amaçlı aşağıdaki kod bloğu eklenmiştir
                if (!int.TryParse(requestCount, out number))
                {
                    Console.WriteLine("Hatalı giriş yaptınız. Sadece rakamlardan oluşan değer girişi yapılabilir ! Talep edilen kod sayısı :");
                    requestCount = Console.ReadLine();

                }
                
            } while (!int.TryParse(requestCount, out number));
           
            response = GenerateCode(number);
            foreach (var item in response)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }


        public static char[] Characters = { 'A', 'C', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z', '2', '3', '4', '5', '7', '9' };
        public static List<string> CodeList = new List<string>();


        public static bool CheckCode(string request)
        {
            // statik bir liste oluşturularak bu liste içerisinde oluşturulan kodlar tutulmaktadır aşağıdaki kod bloğunda
            // duplicate kontrolü sağlanmakta ve aynı zamanda kodların sadece harflerden oluşup tahmin edilebilir kelime oluşturulmaması sağlanmıştır
            var result = false;
            if(!Regex.IsMatch(request, "^[a-zA-Z]+$"))
            {
                if (CodeList != null && CodeList.Count > 0)
                {
                    result = !CodeList.Contains(request);
                }
                else
                {
                    return true;
                }
            }
            return result;

        }
        public static List<string> GenerateCode(int requestedCount)
        {
            //verilen değerler üzerinde kod oluşturma işlemi bu alanda yapılmaktadır
            var random = new Random();
            
            var counter = 0;
            while (counter < requestedCount)
            {
                var code = "";
                do
                {
                    var randomIndex = random.Next(0, Characters.Length);
                    code += Characters[randomIndex];
                } while (code.Length < 8);
               

                //oluşturulan kodun uygunluğu kontrol edilip dönen sonuca göre listeye eklenmesi sağlanmıştır
                var checkResponse = CheckCode(code);
                if (checkResponse)
                {
                    CodeList.Add(code);
                    counter++;
                }
                else
                {
                    code = "";
                }
            }
            return CodeList;

        }
    }
}
