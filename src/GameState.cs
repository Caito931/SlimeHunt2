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

    // Load
    public void Load()
    {
        // Player
        GameObject.player = new Player(new Vector2(200, 200), "1", 50, 50, 200, 100, 0, Color.Blue);
        Raylib.UnloadImage(Player.img);

        // Start Button
        GameObject.StartBtn = new Button(new Vector2(GameConfig.Width/2-100,300), 200, 50, 24, "Start", Color.DarkGreen, Color.Green, Color.Green, Color.Black);

        // Quit Button
        GameObject.QuitBtn = new Button(new Vector2(GameConfig.Width/2-100, 400), 200, 50, 24, "Quit", Color.DarkGreen, Color.Green, Color.Green, Color.Black);

        // Start
        GameObject.StartBtn!.onReleaseAction = () =>
        {
            GameConfig.menuOpen = false;
        };
        
        // Quit
        GameObject.QuitBtn!.onReleaseAction = () =>
        {
            Raylib.CloseWindow();
        };

        // Buttons
        GameObject.buttons.Add(GameObject.StartBtn);
        GameObject.buttons.Add(GameObject.QuitBtn);

        // Slimes
        GameObject.slimes = Slime.SpawnSlimes(3);

        // Font
        GameObject.fontsize = 24;
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

            foreach (Button btn in GameObject.buttons) { btn!.Update(dt); }
        }
        else
        {
            // Game Logic
            //--------------------------------

            // Player
            GameObject.player!.Update(dt, GameObject.circeffects); 
            
            // Slime
            foreach(Slime slime in GameObject.slimes) 
            { 
                slime.Update(dt, GameObject.player, GameObject.circeffects); 
            } 
            
            // Circle Effect
            for (int i = GameObject.circeffects.Count - 1; i >= 0; i--) 
            { 
                GameObject.circeffects[i].Update(dt, GameObject.circeffects); 
            } 
            
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

            foreach (Button btn in GameObject.buttons) { btn!.Draw(); }

            // Title
            String TitleText = "Slime Hunt 2!";
            Raylib.DrawText(TitleText, GameConfig.Width/2-(TitleText.Count()*48/4), 100, 48, Color.DarkGreen);
        }
        else
        {
            // Game Draw
            //--------------------------------

            // Player
            GameObject.player!.Draw(GameObject.fontsize); 

            // Circle Effect
            foreach(Slime slime in GameObject.slimes) 
            {
                slime.Draw(); 
            }
            
            // Circle Effect
            for (int i = GameObject.circeffects.Count - 1; i >= 0; i--)
            { 
                GameObject.circeffects[i].Draw();
            } 

            // DEBUG
            Raylib.DrawText(Convert.ToString(Raylib.GetFPS()), GameConfig.Width-100, 0, GameObject.fontsize, Color.Black);
        }
    }
}