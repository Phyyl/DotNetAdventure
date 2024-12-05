using Godot;
using System;

public partial class Grass : Node2D
{
	private PackedScene grassEffect = (PackedScene)ResourceLoader.Load("res://Misc/GrassEffect.tscn");

	public override void _Ready()
	{        
	}

	public void _on_Hurtbox_area_entered(Area2D area)
	{
		this.QueueFree();

		var animatedSprite = (Effect)this.grassEffect.Instantiate();
		animatedSprite.GlobalPosition = this.GlobalPosition;
		this.GetParent().AddChild(animatedSprite);
	}
}
