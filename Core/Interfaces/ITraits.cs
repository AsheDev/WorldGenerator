namespace Core.Interfaces
{
    public interface ITraits : IBase
    {
        bool Healthy { get; set; } // is it a positive, healthy trait?
    }
}
