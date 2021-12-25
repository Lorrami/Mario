using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Player : GameObject
{
    private const float _speed = 40.0f;
    public Player()
    {
        Position = new Vector2f(50f, 50f);
        Size = new Vector2f(50f, 50f);
        FillColor = Color.Green;
    }
    public override void Update(float dt)
    {
        KeyboardCheck(dt);
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
        Position += new Vector2f(dx, dy);
    }
}