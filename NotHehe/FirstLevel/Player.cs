using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Player : GameObject
{
    private RectangleShape _rect = new RectangleShape(); 
    private const float _speed = 40.0f;
    public Player()
    {
        _rect.Position = new Vector2f(50f, 50f);
        _rect.Size = new Vector2f(50f, 50f);
        _rect.FillColor = Color.Green;
    }
    public override void Update(float dt)
    {
        KeyboardCheck(dt);
    }
    public override void Render(RenderWindow window)
    {
        window.Draw(_rect);
    }
    private void KeyboardCheck(float dt)
    {
        if(Keyboard.IsKeyPressed(Keyboard.Key.D))
        {
            Move(_speed * dt, 0);
        }
        if(Keyboard.IsKeyPressed(Keyboard.Key.A))
        {
            Move(-_speed * dt, 0);
        }
        if(Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            Move(0, -_speed * dt);
        }
        if(Keyboard.IsKeyPressed(Keyboard.Key.S))
        {
            Move(0, _speed * dt);
        }
    }
    private void Move(float dx, float dy)
    {
        _rect.Position += new Vector2f(dx, dy);
    }
}