# Interaction System - [Adınız Soyadınız]

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 2022.3.x |
| Render Pipeline | URP |
| Case Süresi | Geliştirme aşaması |
| Tamamlanma Oranı | %15 |

---

## Kurulum

1. Repository'yi klonlayın.
2. Unity Hub'da projeyi açın.
3. `Assets/LuduInteraction/Scenes` klasörü altındaki test sahnesini oluşturup açın.

## Durum

Proje iskeleti oluşturuldu ve temel etkileşim sınıfları implement edildi.
- **Core:** `IInteractable`, `InteractionType` ve base sınıflar (`BaseInteractable`, `InstantInteractable`, `HoldInteractable`, `ToggleInteractable`) yazıldı.
- **Standartlar:** Tüm sınıflar Ludu Arts kodlama standartlarına (XML Docs, PascalCase, Namespace) uygun hazırlandı.

## Sırada Ne Var?

- `InteractionDetector` (Player raycast sistemi)
- Concrete Interactables (`Door`, `Chest` vb.)

---
