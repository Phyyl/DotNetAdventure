using Godot;
using System;

public partial class Hurtbox : Area2D
{
    [Export]
    private Vector2 HitEffectOffset = Vector2.Zero;

    [Export]
    private float InvicibilityTime = 0.1f;

    [Export]
    private bool ShowHitEffect = true;

    private PackedScene hitEffect = (PackedScene)ResourceLoader.Load("res://Misc/HitEffect.tscn");
    
    private CollisionShape2D collision;
    private Timer timer;

    public override void _Ready()
    {
        this.collision = this.GetNode<CollisionShape2D>(new NodePath("CollisionShape2D"));
        this.timer = this.GetNode<Timer>(new NodePath("Timer"));
    }

    public void _on_Hurtbox_area_entered(Area2D area)
    {
        this.CreateHitEffect();
        this.collision.SetDeferred("disabled", true);
        this.timer.Start(InvicibilityTime);
    }

    public void _on_Timer_timeout()
    {
        this.collision.Disabled = false;
    }

    public void CreateHitEffect()
    {     
        if (this.ShowHitEffect)
        {
            var animatedSprite = (Effect)this.hitEffect.Instantiate();
            animatedSprite.GlobalPosition = this.GlobalPosition + HitEffectOffset;
            this.GetTree().CurrentScene.AddChild(animatedSprite);
        }
    }
}
