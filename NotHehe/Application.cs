using SFML.Window;
using SFML.Graphics;
using SFML.System;

class Application
{
    private RenderWindow _window = new RenderWindow(new VideoMode(720, 540), "Mario");
    public void Run()
    {
        while(_window.IsOpen)
        {
            _window.Display();
            _window.Clear();
            _window.DispatchEvents();
        }
    }
}