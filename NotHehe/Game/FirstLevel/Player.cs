using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Player : GameObject
{
    private readonly float _speed = 100.0f;
    private float RotationVector;
    private bool _isShooted = false;
    private RectangleShape _body = new RectangleShape();
    private RectangleShape _bodyInner = new RectangleShape();
    private RectangleShape _aim = new RectangleShape();

    public Player()
    {
        _body.Size = new Vector2f(50f, 50f);
        _body.Origin = _body.Size/2;
        _body.FillColor = Color.Transparent;
        _body.OutlineThickness = 4;
        _body.OutlineColor = Color.Green;
        _body.Rotation = 45;

        _bodyInner.Size = _body.Size / 3;
        _bodyInner.FillColor = Color.Yellow;
        _bodyInner.Origin = _bodyInner.Size/2;

        _aim.FillColor = Color.Red;
        _aim.Size = new Vector2f(_body.Size.X / 1.5f, _body.Size.Y / 4);
        _aim.Origin = _aim.Size / 2 + new Vector2f(_body.Size.X/2, 0);
        
        AddShape(_body);
        AddShape(_bodyInner);
        AddShape(_aim);
    }
    public override void Update(float dt)
    {
        PositionControl(dt);
        CameraControl();
        Shooting();
    }
    private void CameraControl()
    {
        float X = -Application.RelativeMousePosition.X + Position.X;
        float Y = -Application.RelativeMousePosition.Y + Position.Y;
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
        if(Mouse.IsButtonPressed(Mouse.Button.Left) && !_isShooted)
        {
            float X = Application.RelativeMousePosition.X - Position.X;
            float Y = Application.RelativeMousePosition.Y - Position.Y;
            Spawn(new Bullet(new Vector2f(X, Y)));
            //_isShooted = true;
            //new Thread(() => { Thread.Sleep(100); _isShooted = false; }).Start();
        }
    }
}