namespace Platformer2D
{
    public interface IJump
    {
        bool OnGround { get; }
        void Jump();
    }
}
