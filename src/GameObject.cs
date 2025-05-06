// GameObject.cs

using System;
using System.Numerics;
using Raylib_cs;

namespace Main;

class GameObject
{
    // Objects
    public static Player? player;
    public static int fontsize;
    public static List<Slime> slimes = new List<Slime>();
    public static Button? StartBtn;
    public static Button? QuitBtn;
    public static List<CircEffect> circeffects = new List<CircEffect>(); // Global
    public static List<Button> buttons = new List<Button>(); // Global
}