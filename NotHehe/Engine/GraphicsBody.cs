using SFML.Graphics;
using SFML.System;

class GraphicsBody
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

    private readonly List<Shape> _shapes = new List<Shape>();
    
    public void AddShape(Shape shape)
    {
        _shapes.Add(shape);
    }

    public void Draw(RenderTarget target)
    {
        RenderStates states = RenderStates.Default;
        states.Transform = Transform;
        
        foreach(var shape in _shapes)
            target.Draw(shape, states);
    }
}