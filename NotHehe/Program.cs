using System;
using SFML.Graphics;
using SFML.Window;

class Program
{
    static void Main()
    {
        Huita();
    }

    private static void Huita()
    {
        _gameInizialization();
    }

    private static void _gameInizialization()
    {
        RenderWindow _window = new RenderWindow(new VideoMode(100, 100), "Mario");
        while (_window.IsOpen)
        {
            
        }
    }
}