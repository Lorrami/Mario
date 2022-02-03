using System.ComponentModel.DataAnnotations;
using SFML.Graphics;
using SFML.System;

abstract class Collider
{
    public static readonly Color DebugOutlineColor = Color.Green;
    public static readonly float DebugOutlineThickness = 2;
    public Vector2f Position;
    public abstract bool IsCollided(Collider other);
    
    public abstract void DebugDraw(RenderTarget rt, Vector2f ownerPosition);
}

class CircleCollider : Collider
{
    private readonly CircleShape _debugShape;
    public readonly float Radius;

    public CircleCollider(float radius)
    {
        Radius = radius;
        _debugShape = new CircleShape(radius);
        _debugShape.FillColor = Color.Transparent;
        _debugShape.OutlineColor = DebugOutlineColor;
        _debugShape.OutlineThickness = DebugOutlineThickness;
        _debugShape.Origin = new Vector2f(Radius/2.0f, Radius/2.0f);
    }

    public override bool IsCollided(Collider other)
    {
        return false;
    }

    public override void DebugDraw(RenderTarget rt, Vector2f ownerPosition)
    {
        _debugShape.Position = ownerPosition + Position;
        rt.Draw(_debugShape, new RenderStates(BlendMode.Alpha));
    }
}

class BoxCollider : Collider
{
    private RectangleShape _debugShape;
    public readonly Vector2f Size;
    
    public BoxCollider(float width, float height)
    {
        _debugShape = new RectangleShape(new Vector2f(width, height));
        _debugShape.FillColor = Color.Transparent;
        _debugShape.OutlineColor = DebugOutlineColor;
        _debugShape.OutlineThickness = DebugOutlineThickness;
        Size = new Vector2f(width, height);
    } 
    
    public override bool IsCollided(Collider other)
    {
        return false;
    }

    public override void DebugDraw(RenderTarget rt, Vector2f ownerPosition)
    {
        _debugShape.Position = ownerPosition + Position;
        rt.Draw(_debugShape, new RenderStates(BlendMode.Add));
    }
}