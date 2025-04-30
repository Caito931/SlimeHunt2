
using System;
using System.Numerics;
using Raylib_cs;

namespace Main;

class GameState
{
    // Load Stuff

    // Player
    Player player = new Player(new Vector2(200, 200), "1", 50, 50, 200, Color.Blue);

    // Update
    public void Update()
    {
        // TODO
        double dt = Raylib.GetFrameTime();
        player.Update(dt);
    }

    // Draw
    public void Draw()
    {
        // TODO
        Raylib.ClearBackground(Color.RayWhite);
        player.Draw();
    }
}