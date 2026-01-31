# LLM Kullanım Dokümantasyonu

> Bu dosyayı case boyunca kullandığınız LLM (ChatGPT, Claude, Copilot vb.) etkileşimlerini belgelemek için kullanın.

## Özet

| Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | 2 |
| Kullanılan araçlar | Gemini |
| En çok yardım alınan konular | Mimari Tasarım, Base Class Yapısı |
| Tahmini LLM ile kazanılan süre | 30 dk |

---

## Prompt 1: Proje Kurulumu
**Konu:** Klasör ve proje yapısı kurulumu.
**Durum:** Tamamlandı.

---

## Prompt 2: Core Interaction Mimarisinin Kurulması

**Araç:** Gemini
**Tarih/Saat:** 2026-01-31

**Prompt:**
> "I want to code myself on creating interfaces, classes, interactions etc. ... just give me plain classes and I will fill them." (Followed by request to separate logic into Base classes)

**Alınan Cevap (Özet):**
> `IInteractable` arayüzü ve `InteractionType` enum'u oluşturuldu. Ardından, kod tekrarını önlemek ve genişletilebilirliği sağlamak için `BaseInteractable` soyut sınıfı ve ondan türeyen `Instant`, `Hold`, `Toggle` base sınıfları implement edildi.

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [x] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Etkileşim sisteminin temeli olan soyut sınıflar (Abstract Classes) hiyerarşik bir yapıda oluşturuldu. BaseInteractable üzerinde Debug logları ve durum yönetimi gibi logic değişiklikleri yapıldı.

---
