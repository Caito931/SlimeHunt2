
using System;
using System.Numerics;
using Raylib_cs;

namespace Main;

class CircEffect
{
    // Properties
    public Vector2 pos;
    public double radius;
    public double maxRadius;
    public double speed;
    public String mode;
    public Color color;
    public double alpha;
    private double elapsed;

    // Constructor
    public CircEffect(Vector2 pos, int radius, int maxRadius, double speed, String mode, Color color, double alpha)
    {
        this.pos = pos;
        this.radius = radius;
        this.maxRadius = maxRadius;
        this.speed = speed;
        this.mode = mode;
        this.color = color;
        this.alpha = alpha;
    }

    // Update
    public void Update(double dt, List<CircEffect> circeffects)
    {
        elapsed += dt;
        double t = Math.Min(elapsed / (maxRadius/speed), 1.0);

        // Explode
        if (mode == "Explode") {
            radius = 1 + (maxRadius - 1) * t;
            alpha = 1.0 - t;
        }
        // Implode
        else if (mode == "Implode") {
            radius = maxRadius + (maxRadius - 1) * t;
            alpha = 1.0 - t;
        }
        if (t >= 1.0)
        {
            circeffects.Remove(this);
        }
    }

    // Draw
    public void Draw()
    {
        // Draw itself
        Color fadedColor = Raylib.Fade(color, (float)alpha);
        Raylib.DrawCircle((int)pos.X, (int)pos.Y, (int)radius, fadedColor);
    }
}