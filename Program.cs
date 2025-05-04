// Program.cs

using System;
using System.Numerics;
using Raylib_cs;

namespace Main;

class Program
{
    public static void Main()
    {
        // Init Window
        Raylib.InitWindow(GameConfig.Width, GameConfig.Height, "Slime Hunt 2");
        Raylib.SetTargetFPS(60);

        // Set Game State
        GameState gm = new GameState();

        // Load Stuff
        gm.Load();

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

// TODO
// 1- Adicionar Sprites/Imagens (x)
// 2- Adicionar Um Menu (x)
// 3- Adicionar Mais Efeitos
// 4- Adicionar Restart