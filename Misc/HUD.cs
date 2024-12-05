using Godot;
using System;

public partial class HUD : CanvasLayer
{
    TextureRect heartBg;
    TextureRect heartFg;

    PlayerStats stats;

    public override void _Ready()
    {
        this.heartBg = this.GetNode<TextureRect>(new NodePath("Control/HeartBackground"));
        this.heartFg = this.GetNode<TextureRect>(new NodePath("Control/HeartForeground"));

        this.stats = GetNode<PlayerStats>("/root/PlayerStats");

        this.stats.OnHpChanged += UpdateHPUI;
        this.stats.OnMaxHpChanged += UpdateMaxHPUI;

        this.UpdateMaxHPUI();
        this.UpdateHPUI();
    }
    
    private void UpdateHPUI()
    {
        this.heartFg.SetSize(new Vector2(this.stats.HP * 15, 11));
        this.heartFg.SetSize(new Vector2(this.stats.HP * 15, 11));
    }
    
    private void UpdateMaxHPUI()
    {
        this.heartBg.SetSize(new Vector2(this.stats.MaxHP * 15, 11));
        this.heartBg.SetSize(new Vector2(this.stats.MaxHP * 15, 11));
    }
}