
using System;
using System.Numerics;
using Raylib_cs;

namespace Main;

class Program
{
    public static void Main()
    {
        // Set Game State
        GameState gm = new GameState();

        // Init Window
        Raylib.InitWindow((int)Win.Width, (int)Win.Height, "Slime Hunt 2");

        // Loop
        while (!Raylib.WindowShouldClose())
        {
            // Update Stuff
            gm.Update();

            // Draw Stuff
            Raylib.BeginDrawing();
                gm.Draw();
            Raylib.EndDrawing();
        }

        // Exit
        Raylib.CloseWindow();
    }
}

// Window Properties
public enum Win
{
    Width = 1000,
    Height = 800
}