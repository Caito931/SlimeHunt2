// Button.cs

using System;
using System.Numerics;
using Raylib_cs;

namespace Main;

class Button
{
    // Properties
    public Action? onClickAction;
    public Action? onHoverAction;
    public Action? nonHoverAction;
    public Action? onReleaseAction;
    public Vector2 pos;
    public double width;
    public double height;
    public int fontsize;
    public String? text;
    public Color color;
    public Color Dcolor;
    public Color Ccolor;
    public Color Hcolor;
    public Color Tcolor;
    public double scale;
    public bool clicked;
    public double coolDown;

    // Constructor
    public Button(Vector2 pos, double width, double height, int fontsize, String text, Color color, Color Ccolor, Color Hcolor,Color Tcolor)
    {
        this.pos = pos;
        this.width = width;
        this.height = height;
        this.fontsize = fontsize;
        this.text = text;
        this.color = color;
        this.Dcolor = color;
        this.Ccolor = Ccolor;
        this.Hcolor = Hcolor;
        this.Tcolor = Tcolor;
        this.scale = 1;
        this.clicked = false;
        this.coolDown = 0.1;
    }

    // Button Methods
    //--------------------------------

    // On Click
    public void OnClick()
    {
        if 
        (Raylib.IsMouseButtonPressed(MouseButton.Left) && 
        Raylib.GetMouseX() > pos.X && Raylib.GetMouseX() < pos.X+width &&
        Raylib.GetMouseY() > pos.Y && Raylib.GetMouseY() < pos.Y+height) // && !this.cliked
        {
            // TODO
            this.clicked = true;
            this.color = Ccolor;
            scale = 0.9;

            onClickAction?.Invoke();
        }
    }

    // On Hover
    public void OnHover()
    {
        if (Raylib.GetMouseX() > pos.X && Raylib.GetMouseX() < pos.X+width &&
            Raylib.GetMouseY() > pos.Y && Raylib.GetMouseY() < pos.Y+height && !this.clicked)
        {
            // TODO
            this.color = Hcolor;
            scale = 1.1;
            onHoverAction?.Invoke();
        }
        else
        {
            NonHover();
        }
    }

    // Non Hover
    public void NonHover()
    {
        // TODO
        this.color = Dcolor;
        scale = 1;
        nonHoverAction?.Invoke();
    }

    // On Release
    public void OnRelease()
    {
        if (Raylib.IsMouseButtonReleased(MouseButton.Left) &&
            Raylib.GetMouseX() > pos.X && Raylib.GetMouseX() < pos.X+width &&
            Raylib.GetMouseY() > pos.Y && Raylib.GetMouseY() < pos.Y+height && this.clicked)
        {
            // TODO
            this.clicked = false;
            this.color = Dcolor;
            scale = 1;
            onReleaseAction?.Invoke();
        }
    }

    // Main Methods
    //--------------------------------

    // Update
    public void Update(double dt)
    {
        OnClick();
        OnHover();
        OnRelease();
    }

    // Draw
    public void Draw()
    {
        // Calculate scaled button dimensions
        double ButtonW = width * scale;
        double ButtonH = height * scale;
        double ButtonX = pos.X + (width - ButtonW) / 2;
        double ButtonY = pos.Y + (height - ButtonH) / 2;

        // Button
        Raylib.DrawRectangleV(new Vector2((float)ButtonX, (float)ButtonY), new Vector2((float)ButtonW,(float)ButtonH), color);

        // Calculate text dimensions
        double TextWidth = (text!.Count() * fontsize*scale) / 2;
        double TextHeight = fontsize;
        double textX = ButtonX + (ButtonW - TextWidth) / 2;
        double textY = ButtonY + (ButtonH - TextHeight) / 2;

        Raylib.DrawText(Convert.ToString(text), (int)textX, (int)textY, fontsize, Tcolor);
    }
}