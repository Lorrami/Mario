using SFML.Graphics;
using SFML.System;
using SFML.Window;

class FirstLevel : Level
{
    public FirstLevel(RenderWindow _window)
    {
        SpawnObject(new Player(_window), new Vector2f(100.0f, 100.0f));
    }
}