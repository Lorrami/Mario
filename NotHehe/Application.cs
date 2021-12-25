using SFML.Window;
using SFML.Graphics;
using SFML.System;

class Application
{
    private RenderWindow _window = new RenderWindow(new VideoMode(720, 540), "Mario");
    private Level _currentLevel = new Level();

    public void Run()
    {
        while(_window.IsOpen)
        {
            _window.DispatchEvents();
            _currentLevel.Update(0);
            _window.Clear();
            _currentLevel.Render(_window);
            _window.Display();
        }
    }
}