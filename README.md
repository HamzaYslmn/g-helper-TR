# G-Helper (GHelper)

[![Github all releases](https://img.shields.io/github/downloads/seerge/g-helper/total.svg)](https://GitHub.com/seerge/g-helper/releases/) [![GitHub release](https://img.shields.io/github/release/seerge/g-helper.svg)](https://GitHub.com/seerge/g-helper/releases/) [![GitHub stars](https://img.shields.io/github/stars/seerge/g-helper.svg?style=social&label=Star)](https://GitHub.com/seerge/g-helper/stargazers/)

Dil: Türkçe | [English](https://github.com/seerge/g-helper/blob/main/docs/README.md) | [中文](https://github.com/seerge/g-helper/blob/main/docs/README.zh-CN.md)

## Asus dizüstü bilgisayarlar için hafif Armoury Crate alternatifi

ROG Zephyrus G14, G15, Flow X13, Flow X16, TUF, Strix, Scar ve diğer modeller için kontrol aracı. Armoury Crate ile yapabileceğiniz neredeyse her şeyi yapmanıza izin veren küçük bir yardımcı program. Hem de ekstra yük ve gereksiz hizmetler olmadan.


## :gift: Temel Avantajlar

1. Sorunsuz ve otomatik GPU geçişi (tüm uygulamaları kapatmanızı vb. istemeden)
2. Tüm performans modları tamamen özelleştirilebilir (fan eğrileri ve PPT'ler ile)
3. Çok hafiftir ve neredeyse hiç kaynak tüketmez, herhangi bir hizmet yüklemez. Çalıştırmak için sadece tek bir exe
4. Tüm ayarlara kolay erişim sağlayan basit ve temiz yerel kullanıcı arayüzü
5. Çalıştırmak için yönetici ayrıcalıklarına ihtiyaç duymaz!

### [:floppy_disk: En son sürümü indirin](https://github.com/HamzaYslmn/g-helper-TR/releases/latest/download/GHelperTR.zip)

Bu uygulamayı beğendiyseniz, lütfen [Github'da :star: ile](https://github.com/HamzaYslmn/g-helper-TR) işaretleyin.
### :euro: [Bağış yapın ve G-HelperTR'yi destekleyin](https://www.buymeacoffee.com/hamzayslmn)

_Uygulama hakkında gönderi paylaşırsanız - lütfen bir bağlantı ekleyin. Teşekkürler._

![Screenshot 2023-04-13 190951](https://user-images.githubusercontent.com/5920850/231859391-c4963af4-491c-4523-95d4-0bdcfd7cfd6f.png)

### :zap: Temel Özellikler

1. **Performans modları**: Sessiz - Dengeli - Turbo (Manuel ve Varsayılan fan eğrileri)
2. **GPU modları**: Eco - Standart - Ultimate - Optimize
3. Ekran overdrive (OD) ve miniled multizone anahtarı ile dizüstü bilgisayar ekranı yenileme hızı 60hz veya 120hz (144hz, vb.)
4. Her performans modu için özel fan eğrisi editörü, güç limitleri (PPT) ve turbo boost seçimi
5. Starlight] (https://github.com/vddCore/Starlight) sayesinde anime matris kontrolü + animasyonlu GIF'ler de dahil olmak üzere benim tarafımdan bazı ince ayarlar
6. Klavye arkadan aydınlatma animasyonu ve renkleri (uyku animasyonu ve TUF modelleri için destek dahil)
7. M3, M4 tuşları ve FN+F5 (performans modu) FN+F4 (klavye animasyon modları) için özel bağlamalar
8. CPU / GPU sıcaklığını, fan hızlarını ve pil deşarj oranını izleyin
9. Pil sağlığını korumak için batarya şarj limiti

### :gear: Bataryada veya Fişe takılıyken otomatik geçiş
- Performans modları (uygulama pildeyken veya prize takılıyken kullanılan son modu hatırlar)
- Optimize GPU modu - dGPU'yu pildeyken devre dışı bırakır ve prize takılıyken etkinleştirir
- Otomatik Ekran yenileme hızı (pilde 60hz, prize takılıyken 120+ hz)
- Klavye arka ışığı bataryadayken kapatılabilir

Otomatik geçiş ve kısayol tuşlarının çalışmaya devam etmesi için uygulamanın tepside çalışır durumda kalması gerekir. Herhangi bir kaynak tüketmez. 

### :rocket: Performans Modları

Modlar, varsayılan fan eğrileri de dahil olmak üzere bios'ta saklandıkları için Armoury Crate'teki ile **aynıdır**

1. Sessiz (minimum veya hiç fan yok, toplam 70W PPT, CPU'ya 45W PPT'ye kadar) + Windows'ta en iyi güç verimliliği ayarı
2. Dengeli (dengeli fanlar, toplam 100W PPT, CPU'ya 45W PPT'ye kadar) + Windows'ta dengeli ayar
3. Turbo (yoğun fanlar, toplam 125W PPT, CPU'ya 80W PPT'ye kadar) + Windows'ta en iyi performans ayarı

PPT'ler G14 2022 için gösterilmiştir, diğer modeller için PPT'ler bios'ta ayarlandıkları için farklı olacaktır._

![Screenshot 2023-04-13 191030](https://user-images.githubusercontent.com/5920850/231859519-3cfa40f1-b06e-4cdb-b3e8-5187521ce208.png)

### :video_game: GPU Modları

1. Eko modu: yalnızca düşük güçlü entegre GPU etkin, iGPU yerleşik ekran sürücüleri
2. Standart mod (MS Hybrid): iGPU ve dGPU etkin, iGPU sürücüler yerleşik ekran
3. Ultimate modu: iGPU ve dGPU etkin, ancak dGPU yerleşik ekranı kullanıyor (yalnızca G14 2022 modelinde desteklenir)
4. Optimize edilmiş: dGPU'yu pildeyken devre dışı bırakır (Eco) ve prize takıldığında etkinleştirir (Standart)

## :question: SSS

#### M4 / Rog tuşuna her bastığımda Armory Crate yükleme açılır penceresinin görünmesini nasıl durdurabilirim?
Aşağıdaki ``C:\Windows\System32\ASUSACCI\ArmouryCrateKeyControl.exe`` dosyasını silin veya bir yere taşıyın.

Eğer hala görünüyorsa - BIOS'a gidin (açılışta F2), Gelişmiş Ayarları açın ve "Armory Control Interface "i devre dışı bırakın. 

#### Ultimate GPU modu dizüstü bilgisayarımda neden mevcut değil?
Ultimate modu (donanım tarafından) yalnızca G14 2022'de (ve muhtemelen 2022+'daki diğer modellerde) desteklenmektedir

#### G14 2020 cihazımda Eco modunu (dGPU'yu devre dışı bırak) ayarlayamıyorum
Ne yazık ki 2020 modeli donanım düzeyinde bunu desteklemiyor

#### Özel PPT'ler ve taraftar profilleri uygulamalı mıyım?
Yapmak zorunda değilsiniz, tamamen isteğe bağlıdır. Deneyimlerime göre yerleşik (bios'ta) performans modları iyi çalışıyor. Gücünüzü sınırlayın veya özel fan eğrilerini yalnızca sorun yaşarsanız uygulayın. Fan + güç bölümünde Uygula'ya tıkladığınız anda bios fan profilini "özel" olarak değerlendirecektir! (değiştirmiş olsanız da olmasanız da)

#### G-helper fan hızlarımı nasıl kontrol ediyor?
Kontrol etmez. Bios'unuz kontrol eder (armoury'de olduğu gibi). G-helper'ın yapabildiği şey - (isteğe bağlı olarak) armoury'nin kullandığı aynı uç nokta aracılığıyla 8 çift sıcaklık + fan hızı %'sinden oluşan mevcut performans moduna özel bir fan profili ayarlamaktır.

#### Fan % değerini fan RPM değerine nasıl değiştirebilirim?
Üzerlerine tıklayın

#### G-helper'da GPU sıcaklığını göremiyorum
Büyük olasılıkla ya Eco / Optimized modunu kullanıyorsunuz ve dGPU'nuz kapalı ya da Windows dGPU'yu uyku moduna geçirdi (gücü korumak için). Bu durumda G-helper GPU'nuza ulaşamaz ve okuma alamaz

#### Bu uygulamanın zaten çalıştığını söylüyor
Lütfen (G) simgesi için sistem tepsisini kontrol edin. Varsayılan olarak Windows tüm simgeleri gizlemeye isteklidir, bu nedenle hepsini görmek için ^ öğesine tıklamanız gerekebilir. Görev Çubuğuna sağ tıklayıp Görev Çubuğu Ayarları -> Diğer Sistem Tepsisi simgeleri -> G-Helper'ı her zaman AÇIK olarak işaretle seçeneğini seçmenizi tavsiye ederim.

#### Uygulama başlamıyor / veya çöküyor, ne yapmalıyım?
Başlat menüsünden "Olay Görüntüleyicisi "ni açın, Windows Günlükleri -> Uygulama'ya gidin ve G-Helper'dan bahseden son Hataları kontrol edin. Bir tane görürseniz - lütfen bu hatanın tüm ayrıntılarını içeren bir [yeni sorun] (https://github.com/seerge/g-helper/issues) gönderin.

#### MyASUS uygulamasını G-Helper ile birlikte kullanabilir miyim?
Elbette kullanabilirsiniz! Tek sorun, MyASUS'un daha önce ayarladığınız pil şarj limitini geçersiz kılabilmesidir. Böyle bir durumda tavsiyem, hem MyASUS hem de G-Helper'da aynı limiti (yani %80) ayarlamanız olacaktır.

#### Mikrofonu Sessize Al özelliğini M3 olarak nasıl ayarlayabilirim?
Bu işlev Asus Optimizasyon Hizmeti tarafından gerçekleştirilir (bu nedenle G-yardımcısı bu işleve müdahale etmez ve dokunmaz). Bu hizmetin açık ve çalışır durumda olduğundan emin olun

#### Farklı "Görsel stilleri" nasıl ayarlayabilirim?
Şahsen ben bunların büyük bir hayranı değilim, çünkü renkleri çok yanlış yapıyorlar. Ama eğer isterseniz - Nvidia Control panel ya da AMD Adrenaline (uygun ekran bölümleri) kullanarak ekran renklerini ayarlayabilirsiniz. Eğer gerçekten istiyorsanız [MS Store'dan kendi ASUS yardımcı programını] da kullanabilirsiniz (https://apps.microsoft.com/store/detail/gamevisual/9P4K1LFTXSH8?hl=nl-nl&gl=nl&rtc=1)

#### Nvidia GPU çekirdeğini / belleğini overclock edebilir miyim?
Şu anda nvidia GPU'ya sahip değilim, bu yüzden uygulamaya güvenli bir şekilde hız aşırtma ekleyemiyorum. Ancak bunu yapmak için "msi afterburner" kullanabilirsiniz ve GPU'nuzla çok daha fazlasını yapabilirsiniz, çünkü bu konuda çok daha uzmanlaşmıştır :)

#### G-helper'ı nasıl kaldırabilirim?
G-helper tek bir exe'dir ve sisteme hiçbir şey yüklemez. Kaldırmak için - sadece exe'yi silebilirsiniz :) Herhangi bir özel fan profili veya PPT uyguladıysanız - kaldırmadan önce favori performans modunuzu (örneğin dengeli) seçmenizi ve Fanlar + Güç altında "Fabrika varsayılanları" nı tıklamanızı tavsiye ederim.

#### G-helper nedir?
Asus dizüstü bilgisayarlar için hafif bir Armoury Crate alternatifidir. Armoury Crate ile yapabileceğiniz neredeyse her şeyi yapmanıza izin veren küçük bir yardımcı programdır, hem de ekstra yük ve gereksiz hizmetler olmadan.


-----------------------------

## :euro: [Proje Desteği](https://www.buymeacoffee.com/hamzayslmn)
#### If you like the app you can make a [buymeacoffee](https://www.buymeacoffee.com/hamzayslmn)
[![QR Code](https://avatars.mds.yandex.net/get-images-cbir/4568516/xyJA1-1KkL77yTJ6hzvPvA7337/ocr)](hhttps://www.buymeacoffee.com/hamzayslmn)

----------------

### Nasıl kurulur

1. En son sürümü [**Releases Page**](https://github.com/HamzaYslmn/g-helper-TR/releases) adresinden indirin.
2. İstediğiniz bir klasöre açın
3. Çalıştır **GHelper.exe**

### Gereksinimler (zorunlu)

- Microsoft [.NET7](https://dotnet.microsoft.com/en-us/download). Büyük olasılıkla zaten sahipsiniz. Aksi takdirde resmi web sitesinden [indirebilirsiniz](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.202-windows-x64-installer).

- Asus Sistem Kontrol Arayüzü](https://dlcdnets.asus.com/pub/ASUS/nb/Image/CustomComponent/ASUSSystemControlInterfaceV3/ASUSSystemControlInterfaceV3.exe). MyASUS uygulamasını yüklediyseniz veya yüklediyseniz, bu "sürücü" muhtemelen hala yerindedir (MyASUS kaldırıldıktan sonra bile). Alternatif olarak - indirip kurabilirsiniz

### Öneriler (isteğe bağlı)

- Ekran veya klavye parlaklık ayarı gibi temel dizüstü bilgisayar kısayol tuşlarının çalışmasını sağladığı için "Asus Optimizasyon Hizmeti "ni çalışır durumda tutmanızı öneririm.

- İsteğe bağlı olarak(!) [bu debloat bat dosyasını](https://raw.githubusercontent.com/seerge/g-helper/main/debloat.bat) yönetici olarak çalıştırarak gereksiz hizmetleri devre dışı bırakabilir / kaldırabilirsiniz. Hizmetleri geri yüklemek için - bunun yerine [this bloat bat file](https://raw.githubusercontent.com/seerge/g-helper/main/bloat.bat) çalıştırın.

- Armoury Crate hizmetleri ile birlikte bir uygulama kullanmanız önerilmez, çünkü aynı ayarları yaparlar. Kendi kaldırma aracını kullanarak kaldırabilirsiniz](https://dlcdnets.asus.com/pub/ASUS/mb/14Utilities/Armoury_Crate_Uninstall_Tool.zip?model=armoury%20crate). Her ihtimale karşı, daha sonra her zaman geri yükleyebilirsiniz.

-------------------------------

Asus Zephyrus G14 2022 (AMD Radeon iGPU ve dGPU ile) için tasarlanmış ve geliştirilmiştir. Ancak ilgili ve desteklenen özellikler için 2021 ve 2020 G14, G15, X FLOW ve diğer ROG modelleri için potansiyel olarak çalışabilir ve çalışmalıdır.

Uygulamayı imzalamak için henüz bir Microsoft sertifikam yok, bu nedenle başlatıldığında Windows Defender'dan bir uyarı alırsanız (Windows Bilgisayarınızı Korudu), Daha Fazla Bilgi -> Yine de Çalıştır'a tıklayın. Alternatif olarak Visual Studio kullanarak projeyi kendiniz derleyebilir ve çalıştırabilirsiniz :)

Ayarlar dosyası ``%AppData%\GHelper`` adresinde saklanır

------------------

Debloating, pilden tasarruf etmenize ve dizüstü bilgisayarınızı biraz daha serin tutmanıza yardımcı olur

![Pilinizden tasarruf etmenize yardımcı olur](https://raw.githubusercontent.com/seerge/g-helper/main/docs/screenshots/screen-5w.png)

---------

## Güçlü kullanıcı ayarları

### Her mod için özel güç planları

config.json dosyasında (``%AppData%\GHelper`` altında) özel güç planı GUID'sini manuel olarak ekleyebilirsiniz (değiştirilebilen "gerçek" güç planı veya g-helper'ın varsayılan olarak ayarladığı gibi "kaplama" güç planı olabilir)

Format aşağıdaki gibidir: ``"scheme_<mode>" : "GUID" ``

Burada ``mode = 0 (dengeli), 1 (turbo), 2 (sessiz)``

```
"scheme_0": "2ac1d0e0-17a7-44ed-8091-d88ef75a4eb0",
"scheme_1": "381b4222-f694-41f0-9685-ff5bb260df2e"
```

Json yapısını koruduğunuzdan emin olun (yani fazladan veya eksik virgüller vb. ile bozmayın) - aksi takdirde uygulama onu okuyamaz ve bunun yerine yeni bir yapılandırma oluşturur.

### Özel kısayol tuşu eylemleri

Uygulama M3, M4 ve FN+F4 kısayol tuşları için özel eylemleri destekler. Bunları ayarlamak için ilgili kısayol tuşunun yanındaki "Özel" seçeneğini seçin ve aşağıdakilerden birini yapın:

1. Herhangi bir özel uygulamayı çalıştırmak için - "eylem" metin alanına exe'nin tam yolunu girin, örneğin:
``C:\Program Files\EA Games\Battlefield 2042\BF2042.exe``

2. Herhangi bir Windows tuşunu simüle etmek için - "eylem" alanına uygun tuş kodunu girin, örneğin Print screen için ``0x2C``. 
Tuş kodlarının tam listesi https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes

![Screenshot 2023-04-13 172537](https://user-images.githubusercontent.com/5920850/231837470-df913847-cf8a-43e1-80b6-5eb6e9eaee4e.png)

------------
**Yasal Uyarılar**
"ROG", "TUF" ve "Armoury Crate" AsusTek Computer, Inc. şirketine ait ticari markalardır. Bunlar veya AsusTek Computer'a ait herhangi bir varlık üzerinde hiçbir hak iddia etmiyorum ve bunları yalnızca bilgilendirme amacıyla kullanıyorum.

YAZILIM, TİCARİ ELVERİŞLİLİK, BELİRLİ BİR AMACA UYGUNLUK VE İHLAL ETMEME GARANTİLERİ DAHİL ANCAK BUNLARLA SINIRLI OLMAMAK ÜZERE AÇIK VEYA ZIMNİ HİÇBİR GARANTİ OLMAKSIZIN "OLDUĞU GİBİ" SUNULMAKTADIR. BU YAZILIMIN YANLIŞ KULLANIMI SİSTEM KARARSIZLIĞINA VEYA ARIZAYA NEDEN OLABİLİR.