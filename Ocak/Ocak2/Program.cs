/*1-)C#’ta kullanılan temel veri tipleri nelerdir? (int, double, string vb.)
 
 * Sayısal veri tipleri
     byte -> 0 ile 255 arasında tamsayı (1 byte)
     short -> -32,768 ile 32,767 arasında tamsayı (2 byte)
     int -> -2,147,483,648 ile 2,147,483,647 arasında tamsayı (4 byte)
     long -> Çok büyük tamsayılar için (8 byte)
     float -> Ondalıklı sayılar için (7 basamak hassasiyet) (4 byte)
     double -> Ondalıklı sayılar için (15-16 basamak hassasiyet) (8 byte)
     decimal -> Finansal işlemler için yüksek hassasiyetli ondalık (16 byte)

 * Metinsel veri tipleri
     char ->Tek bir karakter (2 byte)
     string ->Metin ifadeleri (Dinamik)

 *Mantıksal veri tipleri
     bool -> true ve false değerlerini tutar(1 byte)
 */

/*2-)Aşağıdaki değişkenlerin bellek kullanımını karşılaştırın:
•	int x = 5;
•	double y = 5.2;
•	string name = "Mehmet";

   double, int’ten 2 kat daha fazla bellek kullanır.
   string, uzunluğuna bağlı olarak dinamik şekilde bellek kullanır.
   "Mehmet" kelimesi 6 harf içerdiği için yaklaşık 12 byte + metadata kadar bellek tüketebilir.
*/

//3-)Kullanıcıdan iki sayı alıp toplamını ekrana yazdıran bir program yazın.

Console.Write("Birinci sayıyı giriniz: ");
double num1 = Convert.ToDouble(Console.ReadLine());
Console.Write("İkinci sayıyı giriniz: ");
double num2 = Convert.ToDouble(Console.ReadLine());
double sum = num1 + num2;
Console.WriteLine("Toplam: "+ sum);