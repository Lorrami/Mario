using SFML.System;


static class Vector2fMath 
{
    public static float Length(this Vector2f vec)
    {
        return MathF.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
    } 
}