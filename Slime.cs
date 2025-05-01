
using System;
using System.Numerics;
using Raylib_cs;

namespace Main;

class Slime
{
    // Properties
    public Vector2 pos;
    public int width;
    public int height;
    public int points;
    public Color color;

    // Random
    Random random = new Random();

    // Constructor
    public Slime(Vector2 pos, int width, int height, int points, Color color)
    {
        this.pos = pos;
        this.width = width;
        this.height = height;
        this.points = points;
        this.color = color;
    }

    // Update
    public void Update(double dt, Player player, List<CircEffect> circeffects)
    {
        Collide(player, circeffects);
    }

    // Collide
    public void Collide(Player player, List<CircEffect> circeffects)
    {
        // Player and Slime Rectangles
        Rectangle pRect = new Rectangle(player.pos, player.width, player.height);
        Rectangle sRect = new Rectangle(pos, width, height);
        // If True
        if (Raylib.CheckCollisionRecs(pRect, sRect)) 
        {
            circeffects.Add(new CircEffect(new Vector2(pos.X, pos.Y), 1, 1, 50, 100, "Explode", Color.Lime, 1.0)); // effect
            pos.X = random.Next(0+width, (int)Win.Width-width); // 0 to 1000-w
            pos.Y = random.Next(0+height, (int)Win.Height-height); // 0 to 800-w
            player.slimes += points; // slime
            player.timer += points; // timer
        }
    }


    // Draw
    public void Draw()
    {
        // Draw itself
        Raylib.DrawRectangle((int)pos.X, (int)pos.Y, width, height, color);
    }

}