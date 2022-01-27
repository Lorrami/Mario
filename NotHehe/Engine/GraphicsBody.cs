using SFML.Graphics;

class GraphicsBody: PhysicsBody
{
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