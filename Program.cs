
using System;
using Raylib_cs;

namespace Main;

class Program
{
    public static void Main()
    {
        // Init Window
        Raylib.InitWindow((int)Win.Width, (int)Win.Height, "Slime Hunt 2");

        // Loop
        while (!Raylib.WindowShouldClose())
        {
            // Update Stuff
            GameState.Update();

            // Draw Stuff
            Raylib.BeginDrawing();
                GameState.Draw();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}

// Window Properties
public enum Win
{
    Width = 1000,
    Height = 800
}