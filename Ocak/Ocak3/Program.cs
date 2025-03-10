/*1-)Koşullu ifadeler(if-else) ne işe yarar? Gerçek hayattan bir örnek verin.
 
    Koşullu ifadeler Belirli bir şartın sağlanıp sağlanmadığını kontrol eder ve programın akışını bu duruma göre yönlendirir.
 */
Console.Write("Yaşınızı giriniz: ");
int age = Convert.ToInt32(Console.ReadLine());

if (age >= 18)
{
    Console.WriteLine("Ehliyet alabilirsiniz.");
}
else
{
    Console.WriteLine("Ehliyet alamazsınız.");
}

//2-)Kullanıcıdan bir sayı alıp tek mi çift mi olduğunu bulan bir C# programı yazın.

Console.Write("Bir sayı giriniz: ");
int num = Convert.ToInt32(Console.ReadLine());

if(num%2 == 0)
{
    Console.WriteLine("Çift");
}
else
{
    Console.WriteLine("Tek");
}

//-3️-)Girilen bir sayının pozitif, negatif veya sıfır olup olmadığını belirleyen bir program yazın.

Console.Write("Bir sayı giriniz: ");
int num = Convert.ToInt32(Console.ReadLine());

if(num > 0)
{
    Console.WriteLine("Pozitif");
}
else if(num < 0)
{
    Console.WriteLine("Negatif");
}
else
{
    Console.WriteLine("Sıfır");
}