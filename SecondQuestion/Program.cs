using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SecondQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //aşağıdaki kodda paylaşılan json dosyasını bin klasörü içerisinden alarak response adında oluşturulan sınıfı liste formatında deserialize eder
            string jsonRequest = File.ReadAllText("response.json");
            var response = JsonConvert.DeserializeObject<List<Response>>(jsonRequest);

          
            //Verilen koordinat değerlerinin console ekranından büyük olması durumunda hataya düşmemesi için ekran boyutu belirlenmiştir
            Console.SetBufferSize(700, 1200);


            // görseldeki görüntüye yakın olması için başlangıç noktasının değeri 0'a eşitlenmiştir
            Console.SetCursorPosition(0, response[0].BoundingPoly.Vertices[0].Y);
            Console.Write(response[0].Description);
            Console.ReadLine();

            //Aşağıda yoruma alınan kod bloğu her bir öğenin verilen koordinat değerlerinin orta noktası hesaplanıp bulunan yeni koordinata göre 
            //ekrana yansıtma işlemi yapmaktadır fakat koordinatların uyumsuz olması sebebiyle beklenen görüntü karşılanamamaktadır

            #region | Öğe bazlı yapılan işlemleri içeren kod bloğu |
           
            // ilk öğede geri kalan öğelerin birleşimi yer aldığı için tekrarlamayı engellemek adına listeden kaldırılmıştır

            //response.Remove(response[0]);

            //foreach (var item in response) 
            //{ 
            //    //Description içinde yer alan yazının başlangıç koordinatı belirlenmiştir
            //    var coordinates = Calculate(item.BoundingPoly.Vertices);
            //    Console.SetCursorPosition(coordinates.X,coordinates.Y);

            //    //Yazının sınırı belirlenmiştir sol üst köşe ve sağ alt köşe koordinatlarının yatay düzlemdeki uzunluğu belirlenip yazı için sınır belirlenmiştir.
            //    Console.Write(item.Description.PadRight(item.BoundingPoly.Vertices[1].X - item.BoundingPoly.Vertices[0].X));

            //}
            #endregion


        }

        //verilen koordinatlara göre orta nokta hesaplamak için aşağıdaki method yoruma alınan kod bloğu içierisinde kullanılmıştır

        public static Vertices Calculate(List<Vertices> vertices)
        {
            var response = new Vertices();
            var centerX = 0;
            var centerY = 0;

            centerX = vertices[0].X + vertices[1].X;
            centerY = vertices[0].Y + vertices[3].Y;

            response.X = centerX / 2;
            response.Y = centerY / 2;
            return response;
        }
        
    }
}