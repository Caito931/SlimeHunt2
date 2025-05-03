
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
    public static Image img = Raylib.LoadImage("assets/ball.png");
    public static Texture2D texture = Raylib.LoadTextureFromImage(img);

    // Random
    private static Random random = new Random();

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
            pos.X = random.Next(0+width, GameConfig.Width-width); // 0 to 1000-w
            pos.Y = random.Next(0+height, GameConfig.Height-height); // 0 to 800-w

            // To Player
            if (player.timer < Player.MaxTimer) 
            {
                player.timer += points; // timer
            }
            player.slimes += points; // slime
        }
    }

    // Spawn
    public static List<Slime> SpawnSlimes(int count)
    {
        var slimes = new List<Slime>();
        if (count <=0 ) {return slimes; }

        for (int i = 0; i < count; i++) 
        {
            slimes.Add(new Slime(
                new Vector2(random.Next(0+25, GameConfig.Width-25), // x
                random.Next(0+25, GameConfig.Height-25)), // y
                50, 50, 1, Color.Green)); // w h points color
        }
        return slimes;
    }


    // Draw
    public void Draw()
    {
        // Draw itself
        //Raylib.DrawRectangle((int)pos.X, (int)pos.Y, width, height, color);
        Rectangle sourceRec = new Rectangle(0.0f, 0.0f, texture.Width, texture.Height);
        Rectangle destRec = new Rectangle(pos.X+width/2, pos.Y+height/2, width, height); // width is 50 and height also
        Vector2 origin = new Vector2(destRec.Width / 2, destRec.Height / 2);
        Raylib.DrawTexturePro(texture, sourceRec, destRec, origin, 0, Color.White);
    }

}