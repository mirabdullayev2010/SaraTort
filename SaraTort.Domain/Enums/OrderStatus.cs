namespace SaraTort.Domain.Enums;

public enum OrderStatus
{
    Pending = 1,     // Kutilmoqda
    Confirmed = 2,   // Tasdiqlandi (Tayyorlanmoqda)
    Ready = 3,       // Tort tayyor
    InDelivery = 4,  // Kuryer yo'lda
    Delivered = 5,   // Yetkazib berildi
    Cancelled = 6    // Bekor qilindi
}