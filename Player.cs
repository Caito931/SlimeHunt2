
using System;
using System.Numerics;
using Raylib_cs;
using rlgl = Raylib_cs.Rlgl;

namespace Main;

class Player
{
    // Properties
    public Vector2 pos;
    public String id;
    public int width;
    public int height;
    public int speed;
    public int score;
    public Color color;
    public double rotation;
    public double rotationSpeed = 200;

    // Constructor
    public Player(Vector2 pos, String id, int width, int height, int speed, int score, Color color)
    {
        this.pos = pos;
        this.id = id;
        this.width = width;
        this.height = height;
        this.speed = speed;
        this.score = score;
        this.color = color;
    }

    // Update
    public void Update(double dt)
    {
        Move(dt);
    }

    // Move
    public void Move(double dt)
    {
        // Up
        if (Raylib.IsKeyDown(KeyboardKey.W)) {pos.Y -= (float)speed * (float)dt; }
        // Down
        if (Raylib.IsKeyDown(KeyboardKey.S)) {pos.Y += (float)speed * (float)dt; }
        // Left
        if (Raylib.IsKeyDown(KeyboardKey.A)) {pos.X -= (float)speed * (float)dt; }
        // Right
        if (Raylib.IsKeyDown(KeyboardKey.D)) {pos.X += (float)speed * (float)dt; }

        // Rotate
        rotation += rotationSpeed * dt;
    }

    // Draw
    public void Draw(int fontsize)
    {
        // Draw itself
        Rectangle pRect = new Rectangle(pos.X+width/2, pos.Y+height/2, width, height);
        Raylib.DrawRectanglePro(pRect, new Vector2(width/2, height/2), (float)rotation, color);
        //Raylib.DrawRectangle((int)pos.X, (int)pos.Y, width, height, color);

        // Draw score
        Raylib.DrawText($"Total Slimes: {Convert.ToString(score)}", 0, 0, fontsize, Color.Black);
    }

}