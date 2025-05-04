// GameState.cs

using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
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
    Button? StartBtn;
    Button? QuitBtn;
    List<CircEffect> circeffects = new List<CircEffect>(); // Global
    List<Button> buttons = new List<Button>(); // Global

    // Load
    public void Load()
    {
        // Player
        player = new Player(new Vector2(200, 200), "1", 50, 50, 200, 100, 0, Color.Blue);
        Raylib.UnloadImage(Player.img);

        // Start Button
        StartBtn = new Button(new Vector2(GameConfig.Width/2-100,300), 200, 50, 24, "Start", Color.DarkGreen, Color.Green, Color.Green, Color.Black);

        // Quit Button
        QuitBtn = new Button(new Vector2(GameConfig.Width/2-100, 400), 200, 50, 24, "Quit", Color.DarkGreen, Color.Green, Color.Green, Color.Black);

        // Start
        StartBtn!.onReleaseAction = () =>
        {
            GameConfig.menuOpen = false;
        };
        
        // Quit
        QuitBtn!.onReleaseAction = () =>
        {
            Raylib.CloseWindow();
        };

        // Buttons
        buttons.Add(StartBtn);
        buttons.Add(QuitBtn);

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

        if (GameConfig.menuOpen) 
        {
            // Menu Logic
            //--------------------------------

            foreach (Button btn in buttons) { btn!.Update(dt); }
        }
        else
        {
            // Game Logic
            //--------------------------------

            player!.Update(dt, circeffects); // Player
            foreach(Slime slime in slimes) { slime.Update(dt, player, circeffects); } // Slime
            for (int i = circeffects.Count - 1; i >= 0; i--) { circeffects[i].Update(dt, circeffects); } // Circle Effect
        }
    }

    // Draw
    public void Draw()
    {
        // Background
        Raylib.ClearBackground(Color.RayWhite);

        if (GameConfig.menuOpen)
        {
            // Menu Draw
            //--------------------------------

            foreach (Button btn in buttons) { btn!.Draw(); }

            // Title
            String TitleText = "Slime Hunt 2!";
            Raylib.DrawText(TitleText, GameConfig.Width/2-(TitleText.Count()*48/4), 100, 48, Color.DarkGreen);
        }
        else
        {
            // Game Draw
            //--------------------------------

            player!.Draw(fontsize); // Player
            foreach(Slime slime in slimes) { slime.Draw(); } // Slime
            for (int i = circeffects.Count - 1; i >= 0; i--){ circeffects[i].Draw();} // Circle Effect

            // DEBUG
            Raylib.DrawText(Convert.ToString(Raylib.GetFPS()), GameConfig.Width-100, 0, fontsize, Color.Black);
        }
    }
}