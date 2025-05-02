
using System;
using System.Numerics;
using System.Security.Cryptography;
using Raylib_cs;

namespace Main;

class GameState
{
    // Random
    private static Random random = new Random();

    // Setup Stuff
    Player? player;
    private int fontsize;
    List<Slime> slimes = new List<Slime>();
    List<CircEffect> circeffects = new List<CircEffect>(); // Global

    // Load
    public void Load()
    {
        // Player
        player = new Player(new Vector2(200, 200), "1", 50, 50, 200, 100, 0, Color.Blue);
        Raylib.UnloadImage(Player.img);

        // Slimes
        slimes = Slime.SpawnSlimes(3);

        // Font
        fontsize = 24;
    }

    // Update
    public void Update()
    {
        // Delta Time
        double dt = Raylib.GetFrameTime();

        player!.Update(dt, circeffects); // Player
        foreach(Slime slime in slimes) { slime.Update(dt, player, circeffects); } // Slime
        for (int i = circeffects.Count - 1; i >= 0; i--) { circeffects[i].Update(dt, circeffects); } // Circle Effect
    }

    // Draw
    public void Draw()
    {
        // Background
        Raylib.ClearBackground(Color.RayWhite);

        player!.Draw(fontsize); // Player
        foreach(Slime slime in slimes) { slime.Draw(); } // Slime
        for (int i = circeffects.Count - 1; i >= 0; i--){ circeffects[i].Draw();} // Circle Effect

        // DEBUG
        Raylib.DrawText(Convert.ToString(Raylib.GetFPS()), GameConfig.Width-100, 0, fontsize, Color.Black);
    }
}