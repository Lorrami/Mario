using SFML.Graphics;
using SFML.System;

class Player : GameObject
{
    private RectangleShape _rect = new RectangleShape(); 
    public override void Update(float dt)
    {
        _rect.Size = new Vector2f(50f, 50f);
        _rect.Position = new Vector2f(50f, 50f);
        _rect.FillColor = Color.Green;

    }
    public override void Render(RenderWindow window)
    {
        window.Draw(_rect);
    }
}