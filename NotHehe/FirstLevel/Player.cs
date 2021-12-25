using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Player : GameObject
{
    private RectangleShape _rect = new RectangleShape(); 
    public Player()
    {
        _rect.Position = new Vector2f(50f, 50f);
        _rect.Size = new Vector2f(50f, 50f);
        _rect.FillColor = Color.Green;
    }
    public override void Update(float dt)
    {
        _keyboardCheck(dt);
    }
    public override void Render(RenderWindow window)
    {
        window.Draw(_rect);
    }
    private void _keyboardCheck(float dt)
    {
        if(Keyboard.IsKeyPressed(Keyboard.Key.D))
        {
            _move(1f * dt, 0);
        }
        if(Keyboard.IsKeyPressed(Keyboard.Key.A))
        {
            _move(-1f * dt, 0);
        }
        if(Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            _move(0, -1f * dt);
        }
        if(Keyboard.IsKeyPressed(Keyboard.Key.S))
        {
            _move(0, 1f * dt);
        }
    }
    private void _move(float dx, float dy)
    {
        _rect.Position += new Vector2f(dx, dy);
    }
}