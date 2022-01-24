using SFML.System;
using SFML.Graphics;

class Bullet: GameObject{
    private readonly Vector2f _direction;
    private readonly float _speed = 300;
    private float _lifetime = 0;
    public Bullet(Vector2f direction){
        _direction = direction / (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
        Size = new Vector2f(10, 10);
        Origin = Size/2;
        FillColor = Color.Red;
    }
    public override void Update(float dt)
    {
        _lifetime += dt;
        if(_lifetime > 3)
            Destroy();
        
        Position += _direction * _speed * dt;
    }
}