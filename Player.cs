
using System;
using System.Numerics;
using Raylib_cs;

namespace Main;

class Player
{
    // Properties
    public Vector2 pos;
    public String id;
    public int width;
    public int height;
    public int speed;
    public Color color;

    // Constructor
    public Player(Vector2 pos, String id, int width, int height, int speed, Color color)
    {
        this.pos = pos;
        this.id = id;
        this.width = width;
        this.height = height;
        this.speed = speed;
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
    }

    // Draw
    public void Draw()
    {
        Raylib.DrawRectangle((int)pos.X, (int)pos.Y, width, height, color);
    }

}