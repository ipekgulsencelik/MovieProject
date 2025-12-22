namespace Movie.Domain.Entities.Enum
{
    public enum CategoryStatus
    {
        Pending = 0,   // ⏳ Onay Bekliyor
        Active = 1,    // ✅ Yayında
        Passive = 2,   // ⛔ Gizli
        Archived = 3   // 🗄️ Arşiv
    }
}