// Player.cs

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
    public int dashSpeed;
    public int slimes;
    public Color color;
    public double rotation;
    public double rotationSpeed = 300;
    public String dir = "";
    public double timer = 10;
    public static Image img = Raylib.LoadImage("assets/player.png");
    public static Texture2D texture = Raylib.LoadTextureFromImage(img);
    public const int MaxTimer = 10;

    // Constructor
    public Player(Vector2 pos, String id, int width, int height, int speed, int dashSpeed,int slimes, Color color)
    {
        this.pos = pos;
        this.id = id;
        this.width = width;
        this.height = height;
        this.speed = speed;
        this.dashSpeed = dashSpeed;
        this.slimes = slimes;
        this.color = color;
    }

    // Update
    public void Update(double dt, List<CircEffect> circeffects)
    {
        Move(dt, circeffects);
        KeepInBounds();
        UpdateTimer(dt);
    }

    // Move
    public void Move(double dt, List<CircEffect> circeffects)
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
            if (slimes >= 1) 
            {
                // Past Effect
                circeffects.Add(new CircEffect(new Vector2(pos.X+width/2, pos.Y+height/2), 50, 1, 50, 75, "Implode", Color.SkyBlue, 1.0));
                
                // Actions
                if (dir == "up") {pos.Y -= dashSpeed; slimes--;}
                if (dir == "down") {pos.Y += dashSpeed; slimes--;}
                if (dir == "left") {pos.X -= dashSpeed; slimes--;}
                if (dir == "right") {pos.X += dashSpeed; slimes--;}
                
                // New Effect
                circeffects.Add(new CircEffect(new Vector2(pos.X+width/2, pos.Y+height/2), 50, 1, 50, 75, "Implode", Color.SkyBlue, 1.0));
            }
        }

        // Rotate
        rotation += rotationSpeed * dt;
    }

    // Keep in Bounds
    public void KeepInBounds()
    {
        // X
        if (pos.X <= 0) { pos.X = 0; }
        else if (pos.X + width >= GameConfig.Width) { pos.X = GameConfig.Width - width; }
        // Y
        if (pos.Y <= 0) { pos.Y = 0; }
        else if (pos.Y + height >= GameConfig.Height) { pos.Y = GameConfig.Height - height; }
    }

    // Update Timer
    public void UpdateTimer(double dt)
    {
        if (timer > Player.MaxTimer ) { timer = Player.MaxTimer; }
        else if (timer > 0) { timer -= 1 * dt; }
        else if (timer <= 0) {Raylib.CloseWindow();}
    }

    // Draw
    public void Draw(int fontsize)
    {
        // Draw itself
        // Rectangle pRect = new Rectangle(pos.X+width/2, pos.Y+height/2, width, height);
        // Raylib.DrawRectanglePro(pRect, new Vector2(width/2, height/2), (float)rotation, color);

        // Draw Image
        Rectangle sourceRec = new Rectangle(0.0f, 0.0f, texture.Width, texture.Height);
        Rectangle destRec = new Rectangle(pos.X+width/2, pos.Y+height/2, width, height); // width is 50 and height also
        Vector2 origin = new Vector2(destRec.Width / 2, destRec.Height / 2);
        Raylib.DrawTexturePro(texture, sourceRec, destRec, origin, (float)rotation, Color.White);

        //Raylib.DrawRectangle((int)pos.X, (int)pos.Y, width, height, color);

        // Draw score
        Raylib.DrawText($"Total Slimes: {Convert.ToString(slimes)}", 0, 0, fontsize, Color.Black);

        // Draw Timer
        Vector2 timerPos = new Vector2(GameConfig.Width/2 -250, 15);
        Vector2 timerSize = new Vector2((float)timer*50, 50);
        Raylib.DrawRectangleV(timerPos, timerSize, Color.Green); // Accept Float Values
        //Raylib.DrawRectangle((int)Win.Width/2 -250, 15, (int)timer*50, 50, Color.Green); // Normal
    }

}