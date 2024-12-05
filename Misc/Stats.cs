using Godot;
using System;

public partial class Stats : Node
{
    [Signal]
    public delegate void ZeroHpEventHandler();
    public event ZeroHpEventHandler OnZeroHp;

    [Signal]
    public delegate void HpChangedEventHandler();
    public event HpChangedEventHandler OnHpChanged;

    [Signal]
    public delegate void MaxHpChangedEventHandler();
    public event MaxHpChangedEventHandler OnMaxHpChanged;

    [Export]
    private int maxHP = 1;

    public int MaxHP
    {
        get { return this.maxHP; }
        set
        {
            maxHP = value;

            this.EmitSignal("MaxHpChanged");
            OnMaxHpChanged?.Invoke();
        }
    }
    
    private int hp;

    public int HP
    {
        get { return this.hp; }
        set
        {
            hp = value > MaxHP ? MaxHP : value;

            this.EmitSignal("HpChanged");
            OnHpChanged?.Invoke();

            if (this.hp <= 0)
            {
                // triggers both signal and C# event
                this.EmitSignal("ZeroHp");
                OnZeroHp?.Invoke();
            }
        }
    }

    public static int Test{get;set;}

    public override void _Ready()
    {
        this.HP = this.MaxHP;
    }
}
