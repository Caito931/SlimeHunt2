
using System;
using System.Numerics;
using System.Security.Cryptography;
using Raylib_cs;

namespace Main;

class GameState
{
    // Random
    Random random = new Random();

    // Load Stuff
    Player player;
    int fontsize;
    List<Slime> slimes = new List<Slime>();

    // Load
    public void Load()
    {
        // Player
        player = new Player(new Vector2(200, 200), "1", 50, 50, 200, 100, 0, Color.Blue);

        // Slimes
        for (int i = 0; i < 3; i++) // 3
        {
            slimes.Add(new Slime(
                new Vector2(random.Next(0+25,(int)Win.Width-25), // x
                random.Next(0+25, (int)Win.Height-25)), // y
                25, 25, 1, Color.Green)); // w h points color
        }

        // Font
        fontsize = 24;
    }

    // Update
    public void Update()
    {
        double dt = Raylib.GetFrameTime();
        player.Update(dt);
        foreach(Slime slime in slimes) { slime.Update(dt, player); }
    }

    // Draw
    public void Draw()
    {
        Raylib.ClearBackground(Color.RayWhite);
        player.Draw(fontsize);
        foreach(Slime slime in slimes) { slime.Draw(); }

        // DEBUG
        Raylib.DrawText(Convert.ToString(Raylib.GetFPS()), (int)Win.Width-100, 0, fontsize, Color.Black);
    }
}