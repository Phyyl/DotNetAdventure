using Godot;
using System;
using System.Linq;

public partial class SoftCollision : Area2D
{
    public override void _Ready()
    {
        
    }

    public Vector2 GetPushVector
    {
        get
        {
            var areas = this.GetOverlappingAreas();
            return areas.Count > 0 ? ((Area2D)areas[0]).GlobalPosition.DirectionTo(this.GlobalPosition) : Vector2.Zero;
        }
    }
}
