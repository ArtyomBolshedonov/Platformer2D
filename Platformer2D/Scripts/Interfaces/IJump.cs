namespace Platformer2D
{
    public interface IJump
    {
        bool DoJump { get; set; }
        bool OnGround { get; }
        void Jump();
    }
}
