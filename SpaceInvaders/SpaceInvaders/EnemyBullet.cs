using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class EnemyBullet : DirectionMovableBase
{
    public static int LastID
    {
        get;
        private set;
    }


    public int ID
    {
        get;
        set;
    }

    public EnemyBullet(Level level, ConsoleColor color = ConsoleColor.Magenta)
       : base(level)
    {
        this.color = color;
        ID = LastID++;
        Width = 3;
        Height = 1;
        Speed = 2;
        Health = 1;
    }
    public override void OnUpdate() => Move();

    public override void OnHit()
    {
        Game.Instance.UnRegisterBehaviour(this);
    }


    public override void Clear()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write("  ");
    }

    public override void Draw()
    {
        var prevColor = Console.ForegroundColor;
        Console.SetCursorPosition(X, Y);
        Console.Write("<-");
        Console.ForegroundColor = prevColor;
    }
}
