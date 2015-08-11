namespace Core.Interfaces
{
    public interface IMilitaryUnit : IBase
    {
        ICivilization Civilization { get; set; } // TODO: need a better name
        // who heads the unit? this is further down the road when I have actual people involved
        // http://en.wikipedia.org/wiki/Military_organization
        // Corps
        // Division
        // Brigade
        // Regiment
        // Battalion
        // Company
    }
}
