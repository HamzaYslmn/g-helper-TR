# PROJE SONLANDI, Türkçe Dil desteği geldi. 

Eklediğim optimizasyonları da geliştirici uygulamaya ekledi. @hkaancaliskan çeviriyi sağlamış. Yani önceki gibi artık benim çevirim olmayacak.
https://github.com/seerge/g-helper







# [G-Helper-TR (GHelper)](https://github.com/HamzaYslmn/g-helper-TR)

![https://img.shields.io/github/downloads/HamzaYslmn/g-helper-TR/total?style=for-the-badge](https://img.shields.io/github/downloads/HamzaYslmn/g-helper-TR/total?style=for-the-badge)
![https://img.shields.io/github/v/release/HamzaYslmn/g-helper-TR.svg?style=for-the-badge](https://img.shields.io/github/v/release/HamzaYslmn/g-helper-TR.svg?style=for-the-badge)
![https://img.shields.io/github/stars/HamzaYslmn/g-helper-TR?color=e3b341&style=for-the-badge](https://img.shields.io/github/stars/HamzaYslmn/g-helper-TR?color=e3b341&style=for-the-badge)

## Asus ROG Zephyrus G14, G15, Flow X13, Flow X16 ve diğer modeller için açık kaynaklı Armory Crate alternatifi

Fazladan yük ve gereksiz hizmetler olmadan Armoury Crate ile yapabileceğiniz neredeyse her şeyi yapmanızı sağlayan küçük bir yardımcı programdır.

### :gift: Temel avantajları

1. Sorunsuz ve otomatik GPU geçişleri (tüm uygulamalarınızı kapatmanızı vb. istemeden)
2. Tüm performans modları tamamen özelleştirilebilir (fan eğrileri ve PPT'lerle)
3. Çok hafiftir ve neredeyse hiç kaynak tüketmez, hiçbir hizmet yüklemez. Sadece çalıştırılacak tek bir exe dosyası
4. Tüm ayarlara kolay erişim sağlayan basit ve temiz kullanıcı arayüzü

### [:floppy_disk: En son sürümü indirin](https://github.com/HamzaYslmn/g-helper-TR/releases/latest/download/GHelperTR.zip)

Bu uygulamayı beğendiyseniz, lütfen [Github'da :star: ile](https://github.com/seerge/g-helper) işaretleyin.

![https://user-images.githubusercontent.com/78810304/228032141-8146a3de-d440-46cc-b047-a681e6c017af.png](https://user-images.githubusercontent.com/78810304/228032141-8146a3de-d440-46cc-b047-a681e6c017af.png)

### :zap: Temel özellikler

1. Dahili **Performans modları**: Sessiz - Dengeli - Turbo (varsayılan fan eğrileriyle)
2. **GPU modları**: Eco - Standart - Ultimate - Otomatik
3. Dizüstü bilgisayar ekran yenileme hızı 60hz veya 120hz (modelinize bağlı olarak 144hz vb.) display overdrive (OD) ile birlikte
4. Her performans modu için varsayılan ve özel fan profilleri
5. Her performans modu için güç sınırları (PPT)
6. CPU turbo boost modu
7. Klavye arkadan aydınlatmalı animasyon ve renkler
8. [Starlight](https://github.com/vddCore/Starlight) sayesinde anime matrix kontrolü + benim tarafımdan bazı ayarlamalar (animasyonlu GIF'ler dahil)
9. FN+F5 performans modlarını döndürür, FN+F4 klavye animasyon modlarını döndürür
10. M3 ve M4 tuşları için tuş atamaları
11. Pil sağlığını korumak için pil şarj sınırı
12. CPU / GPU sıcaklıklarını, fan hızlarını ve pil deşarj hızını takip edin

### :apple: Şarjda veya prize takılıyken modların otomatik olarak değiştirilmesi

- Performans modları (uygulama, bataryada veya takılıyken kullanılan son modu hatırlar)
- Otomatik GPU modu - bataryada dGPU'yu devre dışı bırakır ve takıldığında etkinleştirir
- Otomatik Ekran yenileme hızı (bataryada 60hz, takılıyken 120+ hz)

Otomatik geçiş ve kısayol tuşlarının çalışması için uygulamanın tepside çalışır durumda olması gereklidir. Herhangi bir kaynak tüketmez.

### :rocket: Performans Modları

Modlar **Armory Crate**'tekiyle aynıdır (bios'ta depolandığı için) ve varsayılan fan eğrilerini içerir

1. Sessiz  - Windows'ta en iyi güç verimliliği ayarı
2. Dengeli - Windows'ta Dengeli ayarı
3. Turbo   - Windows'ta En İyi Performans ayarı

Diğer modeller için PPT'ler G14 2022 için gösterilir, çünkü bios'ta ayarlanmışlardır.

### :video_game: GPU Modları

1. Eco modu : Sadece düşük güç tüketimli entegre GPU etkinleştirildi, iGPU yerleşik ekranı sürüyor.
2. Standart mod (MS Hybrid): iGPU ve dGPU etkinleştirildi, iGPU yerleşik ekranı sürüyor.
3. Ultimate modu(MUX): iGPU ve dGPU etkinleştirildi, ancak dGPU yerleşik ekranı sürer.  **(2022++)**
4. Otomatik : Bataryada dGPU'yu devre dışı bırakır (Eco) ve prize takıldığında etkinleştirir (Standart).

### :question: SSS

### M4 / Rog tuşuna her bastığımda Armory Crate kurulumu / açılış penceresi nasıl durdurulur?

Her M4 / Rog tuşuna bastığımda Armory Crate yükleme açılır penceresini nasıl durdurabilirim?
BIOS'a gidin (başlangıçta F2), Gelişmiş Ayarları açın ve "Armory Control Intrerface"i devre dışı bırakın. 
Hala görünüyorsa - "C:\Windows\System32\ASUSACCI\ArmouryCrateKeyControl.exe" dosyasını silin veya bir yere taşıyın

### Neden Ultimate GPU modu benim dizüstü bilgisayarımda mevcut değil?
Ultimate modu (donanım tarafından) sadece 2022+ modellerde destekleniyor.

#### G14 2020 cihazımda Eco modunu (dGPU'yu devre dışı bırak) ayarlayamıyorum
Maalesef 2020 modelinde bunu donanım düzeyinde desteklemiyor.

#### Özel PPT'ler ve Fan profilleri uygulamalı mıyım?
Gerekli değil, tamamen isteğe bağlı. Deneyimlerimden, bios'ta bulunan performans modları iyi çalışıyor. Güç sınırlaması yapın veya özel fan eğrileri uygulayın, ancak sadece sorunlarınız varsa. Fan + güç bölümünde Uygula'yı tıkladığınız anda bios, fan profilini "özel" olarak düşünecektir! (düzenlemiş olsanız da olmasanız da)

#### G-helper fan hızlarımı nasıl kontrol ediyor?
Kontrol etmiyor. Bios'unuz kontrol ediyor (armoury ile aynı durumda). G-helper, aynı uç noktayı kullanarak (isteğe bağlı olarak) mevcut performans moduna 8 çift sıcaklık + fan hızı% 'lik özel bir fan profilini ayarlayabilir.

#### Fan % değerini (fan RPM değerini) nasıl değiştirebilirim?
Üzerlerine tıklayın

#### G-helper'da GPU sıcaklığını göremiyorum.
Muhtemelen Eco / Optimized modunu kullanıyorsunuz ve dGPU'nuz kapalı durumda veya Windows güç tasarrufu için dGPU'yu uyku moduna almış olabilir. Bu durumlarda G-helper GPU'nuzu okuyamayacak ve sıcaklık okumaları alamayacaktır.

#### Uygulama başlatılmıyor / veya çöktü, ne yapmalıyım?

Başlangıç ​​menüsünden "Olay Görüntüleyicisi"ni açın, Windows Kayıtları -> Uygulama'ya gidin ve G-Helper'ı belirten son Hataları kontrol edin. Bir tane görürseniz - lütfen bu hatanın tüm ayrıntılarıyla bir [Hata Raporu](https://github.com/seerge/g-helper/issues) gönderin.

#### G-helper'ı nasıl kaldırabilirim?

G-helper tek bir exe'dir ve sisteme hiçbir şey yüklemez. Kaldırmak için - exe'yi sadece silmeniz yeterlidir :) 
Standart moda geçtikten sonra, özel fan profillerini ve PPT'leri uygulamayı kaldırmadan önce temizlemenizi öneririm.

---

### Nasıl yüklenir

1. **[Sürümler sayfasından](https://github.com/HamzaYslmn/g-helper-TR/releases)** en son sürümü indirin
2. Seçtiğiniz bir klasöre çıkartın (Tavsiyem: C:\G-HelperTR)
3. **GHelperTR.exe**'yi çalıştırın

### Gereksinimler

- Uygulama için [.NET7](https://dotnet.microsoft.com/en-us/download) yüklü olmalıdır. Muhtemelen zaten sizde yüklüdür. Yoksa Otomatik olarak indirmek için uyarı balonu çıkar.
- "Asus Optimization Service" adlı hizmetin çalışmasını öneririm, çünkü ekran veya klavye parlaklığı gibi temel dizüstü bilgisayar kısayollarını çalışır durumda tutar. Eğer MyASUS uygulaması yüklediyseniz, hizmetin MyASUS kaldırıldıktan sonra bile muhtemelen hala çalışıyor olduğunu unutmayın. Bu Uygulama [Asus Sistem Kontrol Arayüzü'nün](https://www.asus.com/support/FAQ/1047338/)parçasıdır, eğer sizde kurulu değilse çalışmaz.
- Uygulamayı Armory Crate ile birlikte kullanmanız önerilmez, çünkü aynı ayarları düzenlerler. [Kendi kaldırma aracını kullanarak](https://dlcdnets.asus.com/pub/ASUS/mb/14Utilities/Armoury_Crate_Uninstall_Tool.zip?model=armoury%20crate) ArmouryCreate'i kaldırabilirsiniz. Her ihtimale karşı, her zaman geri yükleyebilirsiniz.

- Gereksiz hizmetleri otomatik olarak devre dışı bırakmak/kaldırmak için [bu bat dosyasını](https://github.com/HamzaYslmn/g-helper-TR/blob/main/debloat.bat) yönetici olarak çalştırın.

Not: G-Helper uygulamasını çalıştırmak için yönetici izinlerine ihtiyaç yoktur!

---

Asus Zephyrus G14 2022 (AMD Radeon iGPU ve dGPU ile birlikte) için tasarlanmış ve geliştirilmiştir. Ancak ilgili ve desteklenen özellikler için potansiyel olarak G14 2021 ve 2020, G15, X FLOW ve diğer ROG modellerinde çalışabilir.

Uygulamayı imzalamak için henüz bir Microsoft sertifikam yok, bu nedenle başlatma sırasında Windows Defender'dan bir uyarı alırsanız (Windows PC'nizi korudu), Daha Fazla Bilgi -> Yine de Çalıştır'a tıklayın. Alternatif olarak, Visual Studio kullanarak projeyi kendiniz derleyip çalıştırabilirsiniz :)

Ayarlar dosyası `%AppData%\\GHelper`'da saklanır.
---

[HHzimetleri Devre Dışı Bırakmak (debloat.bat)](https://github.com/HamzaYslmn/g-helper-TR/blob/main/debloat.bat), pilinizi ve dizüstü bilgisayarınızı biraz daha serin tutmanıza yardımcı olur.

![https://raw.githubusercontent.com/seerge/g-helper/main/docs/screenshots/screen-5w.png](https://raw.githubusercontent.com/seerge/g-helper/main/docs/screenshots/screen-5w.png)

---

**Açıklamalar**
"ROG", "TUF" ve "Armoury Crate" AsusTek Computer, Inc.'in ticari markalarıdır ve bunlara veya AsusTek Computer'a ait herhangi bir varlığa sahip olduğumu iddia etmiyorum ve bu uygulamayı sadece bilgilendirme amaçlı kullanıyorum.

BU YAZILIM "OLDUĞU GİBİ" SAĞLANMAKTADIR VE HERHANGİ BİR TÜRDE, AÇIK VEYA ZIMNİ BİR GARANTİSİ BULUNMAMAKTADIR. SATILABİLİRLİK, BELİRLİ BİR AMACA UYGUNLUK VEYA İHLAL ETMEME GARANTİLERİ DE DAHİL OLMAK ÜZERE HİÇBİR GARANTİSİ BULUNMAMAKTADIR. BU YAZILIMIN YANLIŞ KULLANIMI, SİSTEM İSTİKRARSIZLIĞINA VEYA ARIZALANMAYA NEDEN OLABİLİR. SORUMLULUK SİZE AİTTİR.

