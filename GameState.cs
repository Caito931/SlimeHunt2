
using System;
using System.Numerics;
using System.Security.Cryptography;
using Raylib_cs;

namespace Main;

class GameState
{
    // Random
    Random random = new Random();

    // Setup Stuff
    Player player;
    int fontsize;
    List<Slime> slimes = new List<Slime>();
    List<CircEffect> circeffects = new List<CircEffect>(); // Global

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
        foreach(Slime slime in slimes) { slime.Update(dt, player, circeffects); }
        for (int i = circeffects.Count - 1; i >= 0; i--)
        {
            circeffects[i].Update(dt, circeffects);
        }
    }

    // Draw
    public void Draw()
    {
        Raylib.ClearBackground(Color.RayWhite);
        player.Draw(fontsize);
        foreach(Slime slime in slimes) { slime.Draw(); }

        for (int i = circeffects.Count - 1; i >= 0; i--)
        {
            circeffects[i].Draw();
        }

        // DEBUG
        Raylib.DrawText(Convert.ToString(Raylib.GetFPS()), (int)Win.Width-100, 0, fontsize, Color.Black);
    }
}