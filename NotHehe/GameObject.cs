using SFML.Graphics;
using SFML.System;


abstract class GameObject{
    public Vector2f Position = new Vector2f(0, 0);

    public abstract void Update(float dt);

    public abstract void Render(RenderWindow window);
}