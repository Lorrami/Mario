using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Player : GameObject
{
    private readonly float _speed = 100.0f, _rotationSpeed = 100.0f;
    private Vector2i MousePos;
    private float RotationVector;
    public Player()
    {
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
        float X = -Mouse.GetPosition().X + Position.X + _rotationSpeed;
        float Y = -Mouse.GetPosition().Y + Position.Y + _rotationSpeed;
        RotationVector = Convert.ToSingle(Math.Atan2(Y, X)) * 180.0f/3.14159265f;
        Console.WriteLine(RotationVector);
        Rotation = RotationVector;
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
            Spawn(new Bullet(new Vector2f(RotationVector + 1, RotationVector)));
        }
    }
}