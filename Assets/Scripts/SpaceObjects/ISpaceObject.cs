namespace SpaceGame
{
    public interface ISpaceObject : ICoordinates, ISelectable
    {
        string Name {get; }
        
    }
}