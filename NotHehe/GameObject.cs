using SFML.Graphics;
using SFML.System;


abstract class GameObject{
    public Level? OwningLevel{private get; set;}

    public abstract void Update(float dt);

    public abstract void Render(RenderWindow window);
}