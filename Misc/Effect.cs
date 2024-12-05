using Godot;
using System;

public partial class Effect : AnimatedSprite2D
{
    public string AnimationName = "default";

    public override void _Ready()
    {
        this.Connect("animation_finished", new Callable(this, "OnAnimationFinished"));

        this.Visible = true;
        this.Play(this.AnimationName);
    }

    public void OnAnimationFinished()
    {
        QueueFree();
    }
}