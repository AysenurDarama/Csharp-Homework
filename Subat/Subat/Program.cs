/*1️-)Dizi(Array) nedir? Ne işe yarar? Gerçek hayattan bir örnek verin.
 Dizi (Array), aynı türdeki birden fazla veriyi tek bir değişkende saklamaya yarayan bir veri yapısıdır.
 Dizi elemanları bellekte ardışık olarak saklanır ve her elemanın bir indeksi (index) vardır.

 string[] meyveler = { "Elma", "Armut", "Muz" };
 int[] notlar = { 45, 50, 60, 80, 100 }; 
*/

//2️-)5 elemanlı bir int dizisi oluşturup, kullanıcıdan aldığı değerlerle diziyi dolduran ve ekrana yazdıran bir program yazın.

int[] numbers = new int[5];
for(int i = 0; i<numbers.Length; i++)
{
    Console.Write($"{i + 1}.sayıyı giriniz: ");
    numbers[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Girilen sayılar: ");
foreach (int num in numbers){
    Console.WriteLine(num);
} 

//3️-)Bir dizinin içindeki en büyük sayıyı bulan bir C# programı yazın.
int[] numbers = { 5, 12, 14, 25, 6, 28, 45, 56, 78 };
int max = numbers[0];
for(int i = 0; i<numbers.Length; i++)
{
    if (numbers[i] > numbers[0])
    {
        max = numbers[i];
    }
}
Console.WriteLine("En büyük sayı: " + max);



