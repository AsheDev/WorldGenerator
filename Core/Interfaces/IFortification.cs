namespace Core.Interfaces
{
    public interface IFortification : IBase
    {
        ICivilization ControlledBy { get; set; }
    }
}
