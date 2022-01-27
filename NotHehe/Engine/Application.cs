using SFML.Window;
using SFML.Graphics;
using SFML.System;

class Application
{
    private static readonly ContextSettings DefaultContextSettings = new ContextSettings(0, 0, 0);
    private static readonly Vector2u WindowSize = new Vector2u(720, 540);

    private static RenderWindow _window = new RenderWindow(new VideoMode(WindowSize.X, WindowSize.Y), "Mario",
        Styles.Default, DefaultContextSettings);

    private LevelRenderer _renderer = new LevelRenderer(_window, true);
    private Level _currentLevel = new FirstLevel();

    public static Vector2i RelativeMousePosition
    {
        get
        {
            return Mouse.GetPosition(_window);
        }
    }

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
            
            _renderer.Render(_currentLevel);
            _renderer.SwapBuffers();
        }
    }

    private void OnWindowClose(object? window, EventArgs e)
    {
        _window.Close();
    }
}