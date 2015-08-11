namespace Core.Interfaces
{
    public interface IRace : IBase
    {
        ILanguage NativeTongue { get; set; }
        ILanguage CommonTongue { get; set; }
        IMythology Mythos { get; set; }
        int LifeSpan { get; }
        int SexualMaturity { get; }

        // cahracteristics of the race (brutish, intelligent, etc...)
        // naturally friendly/hostile towards?
        // what else?
        // inherently magical?
    }
}
