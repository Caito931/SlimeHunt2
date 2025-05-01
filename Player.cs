
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
    public int dashSpeed;
    public int score;
    public Color color;
    public double rotation;
    public double rotationSpeed = 300;
    public String dir = "";

    // Constructor
    public Player(Vector2 pos, String id, int width, int height, int speed, int dashSpeed,int score, Color color)
    {
        this.pos = pos;
        this.id = id;
        this.width = width;
        this.height = height;
        this.speed = speed;
        this.dashSpeed = dashSpeed;
        this.score = score;
        this.color = color;
    }

    // Update
    public void Update(double dt)
    {
        Move(dt);
        KeepInBounds();
    }

    // Move
    public void Move(double dt)
    {
        // Up
        if (Raylib.IsKeyDown(KeyboardKey.W)) {pos.Y -= (float)speed * (float)dt; dir="up"; }
        // Down
        if (Raylib.IsKeyDown(KeyboardKey.S)) {pos.Y += (float)speed * (float)dt; dir="down"; }
        // Left
        if (Raylib.IsKeyDown(KeyboardKey.A)) {pos.X -= (float)speed * (float)dt; dir="left"; }
        // Right
        if (Raylib.IsKeyDown(KeyboardKey.D)) {pos.X += (float)speed * (float)dt; dir="right"; }

        // Dash
        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            if (dir == "up" && score >= 1) {pos.Y -= dashSpeed; score--;}
            if (dir == "down" && score >= 1) {pos.Y += dashSpeed; score--;}
            if (dir == "left" && score >= 1) {pos.X -= dashSpeed; score--;}
            if (dir == "right" && score >= 1) {pos.X += dashSpeed; score--;}
        }

        // Rotate
        rotation += rotationSpeed * dt;
    }

    // Keep in Bounds
    public void KeepInBounds()
    {
        // X
        if (pos.X <= 0) { pos.X = 0; }
        else if (pos.X + width >= (int)Win.Width) { pos.X = (int)Win.Width - width; }
        // Y
        if (pos.Y <= 0) { pos.Y = 0; }
        else if (pos.Y + height >= (int)Win.Height) { pos.Y = (int)Win.Height - height; }
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