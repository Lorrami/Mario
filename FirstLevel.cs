using SFML.Graphics;
using SFML.System;
using SFML.Window;

class FirstLevel : Level
{
    public FirstLevel()
    {
        SpawnObject(new Player(), new Vector2f(100.0f, 100.0f));
    }
}