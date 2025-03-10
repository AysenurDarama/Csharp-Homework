/*1️-)C# programlama dili nedir? Hangi alanlarda kullanılır?
 
 C#, Microsoft tarafından geliştirilen, .NET platformunda çalışan, nesne yönelimli (OOP) bir programlama dilidir. 
 C, C++ ve Java dillerinden esinlenerek tasarlanmıştır.

 Kullanım Alanları:
 -Masaüstü Uygulamaları(Windows Forms, WPF)
 -Web Uygulamaları(ASP.NET, Blazor)
 -Mobil Uygulamalar(Xamarin, MAUI)
 -Oyun Geliştirme(Unity)
 -Bulut ve Sunucu Tabanlı Uygulamalar
 -Gömülü Sistemler ve IoT
*/

/*2️-)Bir programın çalışması için temel bileşenler nelerdir? (Derleyici, RAM, CPU vb.)
 
   Bir programın çalışması için donanım ve yazılım bileşenlerine ihtiyaç vardır:

 - Derleyici (Compiler) – Kaynak kodunu makine diline çevirir.
 - İşletim Sistemi (OS) – Programın çalışmasını ve sistem kaynaklarına erişimini sağlar.
 - RAM (Bellek) – Programın çalışma sırasında verileri geçici olarak depoladığı alan.
 - CPU (İşlemci) – Programın komutlarını işler ve yürütür.
 - Depolama (HDD/SSD) – Program dosyalarının ve verilerin saklandığı alan.
 - .NET Runtime (CLR - Common Language Runtime) – C# programlarının çalışmasını sağlayan sanal makine.

 */

//3-)Kullanıcıdan adını alıp ekrana yazdıran basit bir C# programı yazın.
Console.Write("Adınızı Giriniz: ");
string name = Console.ReadLine();
Console.WriteLine("İsminiz: " + name);