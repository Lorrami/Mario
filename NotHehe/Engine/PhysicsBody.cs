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
            float angle = -Rotation * MathF.PI / 180.0F;
            float cos = MathF.Cos(angle);
            float sin = MathF.Sin(angle);

            return new Transform(
                cos, sin, Position.X,
                -sin, cos, Position.Y,
                0, 0, 1
            );
        }
    }
    private readonly List<CircleCollider> _colliders = new List<CircleCollider>();

    public void AddCollider(CircleCollider collider)
    {
        _colliders.Add(collider);
    }

    public void Collide(PhysicsBody otherBody)
    {
        
        foreach (var collider in _colliders)
        {
            foreach (var otherCollider in otherBody._colliders)
            {
                //own.Collide(unown);
            }
        }
    }

    public void DebugDraw(RenderTarget rt)
    {
        foreach(var collider in _colliders)
            collider.DebugDraw(rt, Position);
    }

}