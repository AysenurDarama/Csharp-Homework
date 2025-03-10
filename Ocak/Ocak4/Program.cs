/*1️-)Döngüler(for, while) ne işe yarar? Hangisi hangi durumda kullanılır?
 
 *Döngüler, belirli bir işlemi tekrar tekrar çalıştırmak için kullanılır. 
  Koşul sağlandığı sürece kod bloğu çalışmaya devam eder.
 *for döngüsü -> Tekrar sayısı belli olan işlemler için kullanılır.
 *while döngüsü	-> Döngü koşulu sağlandığı sürece çalışır, tekrar sayısı başta belli değilse tercih edilir.
 *do-while döngüsü	-> En az bir kez çalışması gereken durumlar için kullanılır.
 
 */

//2️-)1’den 10’a kadar olan sayıları ekrana yazdıran bir for döngüsü yazın.
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(i);
}

//3️-) Kullanıcıdan alınan bir sayıya kadar olan sayıların toplamını hesaplayan bir program yazın.
Console.Write("Bir sayı giriniz: ");
int num = Convert.ToInt32(Console.ReadLine());
int sum = 0;
for(int i = 0; i <= num; i++)
{
    sum += i;
}
Console.WriteLine("sayıların toplamı: "+sum);