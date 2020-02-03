
namespace SpaceGame
{
    public interface INaturalBody
    {
                
        float Diameter {get; }
        float Mass {get; }
        //float RotationPeriod {get; }
        float RotationSpeed {get; }
        //float CirculationPeriod {get; }
        //float DistanceToStar {get; }

        //void SetParentSpaceBody(ISpaceBody parentSpaceBody);
        //void SetChildSpaceBody(ISpaceBody[] childSpaceBody);

        void RotationAround(float rotationSpeed);
        //void CirculationAround(float circulationPeriod);

    }
}