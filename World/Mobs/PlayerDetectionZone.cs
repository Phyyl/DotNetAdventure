using Godot;
using System;

public partial class PlayerDetectionZone : Area2D
{
    public Player Player;

    public override void _Ready()
    {
        
    }

    public void _on_PlayerDetectionZone_body_entered(Player body)
    {
        this.Player = body;
    }

    public void _on_PlayerDetectionZone_body_exited(Player body)
    {
        this.Player = null;
    }
}
