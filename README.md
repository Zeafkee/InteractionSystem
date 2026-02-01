# Interaction System - [Adınız Soyadınız]

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.2.7f2 |
| Render Pipeline | URP |
| Case Süresi | Tamamlandı |
| Tamamlanma Oranı | %100 (+Bonus) |

---

## Kurulum

1. Repository'yi klonlayın.
2. Unity Hub'da projeyi açın.
3. `Assets/InteractionSystem/Scenes/TestScene` sahnesini açın.
4. Play tuşuna basın.

## Özellikler

### Core Interaction System
- **Raycast Detection:** Oyuncu kamerasından raycast ile etkileşim nesneleri algılanır.
- **Input System:** New Input System entegrasyonu ile E tuşu etkileşimleri yönetir.
- **Interaction Types:** 
  - **Instant:** Anında etkileşim (Key Pickup).
  - **Hold:** Basılı tutma gerektiren etkileşim (Chest).
  - **Toggle:** Aç/Kapa durumu olan etkileşim (Door, Switch).

### Interactable Objects
1.  **Door:** Kilitlenebilir kapı sistemi. Anahtar (Key) gerektirir. DOTween ile yumuşak animasyon.
2.  **Chest:** Basılı tutarak açılan sandık. İçinden eşya çıkar. DOTween ile kapak animasyonu.
3.  **Switch:** Unity Event ile diğer nesneleri tetikleyen şalter. Animator entegrasyonu.
4.  **Key:** Envantere eklenen toplanabilir nesne.

### UI & Inventory
- **Interaction UI:** Dinamik prompt metni ve hold progress bar.
- **Inventory System:** 1x6 grid yapısında, fixed slot mantığı ile çalışan görsel envanter.

### Bonus Özellikler
- **Save/Load Sistemi:** Kapı, sandık, şalter durumu ve toplanan anahtarlar JSON formatında kaydedilir.
- **Save Manager:** Inspector'dan save dosyasını silme ve yönetme imkanı.
- **Interaction Highlight:** Odaklanılan nesneye outline materyali eklenir.
- **Ses Efektleri:** Etkileşim sırasında ses çalma özelliği.

## Mimari Kararlar

- **BaseInteractable:** Tüm etkileşim nesneleri için ortak soyut sınıf. Kod tekrarını önler. `ISaveable` ve `IInteractable` implemente eder.
- **Event-Driven UI:** UI scriptleri, Player scriptlerinden gelen C# eventlerini dinler (`OnFocus`, `OnInventoryChanged`). Loose coupling sağlar.
- **Collider Caching:** `InteractionDetector` her frame `GetComponent` çağırmamak için dictionary tabanlı cache kullanır.
- **Editor Tool:** `Generate Save IDs` editör aracı ile sahnedeki tüm etkileşimli nesnelere otomatik Unique ID atanır.

## Ludu Arts Standartlarına Uyum

- **Naming Conventions:** `m_` prefix kullanımı, PascalCase isimlendirmeler.
- **Code Style:** Region kullanımı, XML dokümantasyonları.
- **Folder Structure:** İstenilen hiyerarşiye tam uyum.

---
