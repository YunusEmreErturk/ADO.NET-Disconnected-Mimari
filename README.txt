ADO.NET Disconnected mimari kullanılarak yaptığım basit Console uygulaması (Kelime Oyunu).
Oyun şu şekilde oynanmaktadır;
1-)Kullanicidan 1 harf istenir.
2-)Alinan harf ile başlayan "Name"lerden birincisi seçilir ve seçilen Name'in son harfi ile başlayan 
Name'ler bulunur ve ilk seçilen Name silinir.Yeni bulunan Name'in en son harfi seçilir ...Bu şekilde bulunacak Name kalmayana kadar oyun devam eder.
3-)En son kullanıcıya kaç kelime bulunduğu söylenir ve silinen veriler tekrar yüklenir.Oyun başa döner.

Örnek verecek olursak Kullanici 'A' harfi girdi diyelim;

AHMET,AYDIN,AYSE =>>>AHMET seçilir 'T' harfi alinir ve AHMET Silinir.Ardından 'T' harfi ile başlayanlar sıralanır.TUNA,TARIK,TARKAN =>>>TUNA seçilir 'A'  harfi alınır TUNA Silinir.AYDIN,AYSE =>>> AYDIN seçilir 'N' harfi alınır ve AYDIN Silinir.                          Bu sefer A harfi başlayan sadece AYŞE Kalır.
En son gelen harfle kelime bulunamazsa oyun biter .Veriler yüklenir ve oyun tekrar başlar.

@Author Yunus Emre Erturk ====> yemrerturk@gmail.com / www.muhendiserturk.com  
