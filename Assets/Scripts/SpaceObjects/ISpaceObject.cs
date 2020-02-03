namespace SpaceGame
{
    public interface ISpaceObject : IPosition, ISelectable
    {
        string Name {get; }
    }
}