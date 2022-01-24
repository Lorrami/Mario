using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Player : GameObject
{
    private readonly float _speed = 100.0f;
    private Vector2i MousePos;
    private RenderWindow _window;
    public Player(RenderWindow _window)
    {
        this._window = _window;
        Size = new Vector2f(50f, 50f);
        Origin = Size/2;
        FillColor = Color.Green;
    }
    public override void Update(float dt)
    {
        PositionControl(dt);
        CameraControl();
        Shooting();
    }
    private void CameraControl()
    {
        MousePos = Mouse.GetPosition();
    }
    private void PositionControl(float dt)
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
    private void Shooting()
    {
        if(Mouse.IsButtonPressed(Mouse.Button.Left))
        {
            Spawn(new Bullet(new Vector2f(1, 0)));
        }
    }
}