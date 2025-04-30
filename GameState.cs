
using System;
using System.Numerics;
using System.Security.Cryptography;
using Raylib_cs;

namespace Main;

class GameState
{
    // Load Stuff

    // Player
    Player player = new Player(new Vector2(200, 200), "1", 50, 50, 200, 0, Color.Blue);

    // Slime
    Slime slime = new Slime(new Vector2(400, 600), 25, 25, 1, Color.Green);

    // Font
    int fontsize = 24;

    // Update
    public void Update()
    {
        double dt = Raylib.GetFrameTime();
        player.Update(dt);
        slime.Update(dt, player);
    }

    // Draw
    public void Draw()
    {
        Raylib.ClearBackground(Color.RayWhite);
        player.Draw(fontsize);
        slime.Draw();
    }
}