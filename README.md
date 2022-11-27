# ATM İşlem Kurgusu
Bu çalışmada, banka müşterilerinin ATM üzerinden gerçekleştirdiği bazı işlemler üzerinde çalışma yapılacaktır. Uygulamada 4 adet rest api metodu ihtiyacı bulunmaktadır.
Giriş Yapma
Müşteri tablosunda yer alacak bir bilgi ile giriş yapma işlemi sonucunda JWT token dönen bir metot gerekmektedir (Kullanıcı Adı-Şifre yada Kart No-Şifre olabilir). Alınan JWT token, diğer metot çağrımlarında bearer token olarak gönderilecektir.

Hesaptaki Bakiye Bilgisi Görüntüleme
Müşteriye ait hesap hareketleri üzerinden hesaplanarak getirilecek bakiye bilgisidir.

Para Çekme
Bu metot çağrıldığında, metoda geçilen parametre miktarında, işlemi yapan müşterinin hesabına para çekme işlemi kaydedilecektir. Eğer ki müşterinin bakiyesi yetersiz ise, bu metot dönüşünde bir bilgilendirme mesajı dönülecektir. (“Yetersiz Bakiye” vb.).
Bu işlem esnasında, ID haricinde bir işlem numarası oluşturulması gerekmektedir. İşlem numarası 10000’den başlamalı ve birer birer artmalıdır.
Bu işlem gerçekleştirildiğinde, güvenlik amacı ile, müşterinin mail adresine mail gönderimi gerçekleştirilecektir. (Mail içeriği önemsizdir)

Para Yatırma
Bu metot çağrıldığında, metoda geçilen parametre miktarında, işlemi yapan müşterinin hesabına para yatırma işlemi kaydedilecektir.
Bu işlem gerçekleştirildiğinde, güvenlik amacı ile, müşterinin mail adresine mail gönderimi gerçekleştirilecektir. (Mail içeriği önemsizdir)
Çalışma .Net 5 ya da .Net 6 versiyonları ile Entity Framework Code First yaklaşımı kullanılmaldır. 
Veritabanı yönetim sistemi olarak Sql Server, Mysql ya da Postgresql tercih etmeniz beklenmektedir.
Bu çalışmada, yalnızca rest api geliştirilmesi beklenmekte ve önyüzde olarak bir çalışma yapılması istenmemektedir.

Veritabanına kaydedilecek varsayılan değerler (Örnek bir müşteri kaydı, parametre vb.), ister seeder ile ister model builder yöntemleri ile kaydedilmesi beklenmektedir. 
Store Procedure, View, Sequence ve benzeri sql yapılarını kullanabilirsiniz. Kullanmanız dahilinde, proje ile birlikte bizlere iletmeniz beklenmektedir.
