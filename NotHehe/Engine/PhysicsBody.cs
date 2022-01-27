using SFML.Graphics;
using SFML.System;

class PhysicsBody
{
    public Vector2f Position = new Vector2f(0.0f, 0.0f);
    public float Rotation;
    public Transform Transform
    {
        get
        {
            Transformable transformable = new Transformable();
            transformable.Position = Position;
            transformable.Rotation = Rotation;
            return transformable.Transform;
        }
    }
 
}