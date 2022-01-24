using SFML.Window;
using SFML.Graphics;
using SFML.System;

class Application
{
    private static RenderWindow _window = new RenderWindow(new VideoMode(720, 540), "Mario");
    private Level _currentLevel = new FirstLevel();

    public Application()
    {
        _window.Closed += OnWindowClose;
    }

    public void Run()
    {
        Clock cl = new Clock();
        while(_window.IsOpen)
        {
            float dt = cl.ElapsedTime.AsSeconds();
            cl.Restart();
            _window.DispatchEvents();
            _currentLevel.Update(dt);
            _window.Clear();
            _currentLevel.Render(_window);
            _window.Display();
        }
    }

    private void OnWindowClose(object? window, EventArgs e)
    {
        _window.Close();
    }
}