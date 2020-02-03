
namespace SpaceGame
{
    interface ISpaceBody
    {
         
        string Name {get; }
        float Diameter {get; }
        float Mass {get; }
        float RotationPeriod {get; }
        float RotationSpeed {get; }
        float CirculationPeriod {get; }
        float DistanceToStar {get; }

        void RotationAround(float rotationSpeed);
        void CirculationAround(float circulationPeriod);

    }
}