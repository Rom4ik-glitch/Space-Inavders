using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Enemy : DirectionMovableBase
{
    public Enemy(Level level, ConsoleColor color = ConsoleColor.Red)
       : base(level)
    {
        this.color = color;
        Width = 7;
        Height = 4;
        Speed = 1;
        Health = 1;
    }
    public override void OnHit()
    {
        Game.Instance.UnRegisterBehaviour(this);
    }
    public override void OnUpdate()
    {
        Move();
        Shoot();
    }
    int delay = 0;
    public void Shoot()
    {
        
        delay++;
        if (delay == 35)
        {
            delay = 0;
            var Enemy_bullet = new EnemyBullet(level);
            var Enemy_bullet1 = new EnemyBullet(level);
            Enemy_bullet.MoveTo(X, Y);
            Enemy_bullet1.MoveTo(X, Y + 3);
            Enemy_bullet.Move(Direction.Left);
            Enemy_bullet1.Move(Direction.Left);
            Game.Instance.RegisterBehaviour(Enemy_bullet);
            Game.Instance.RegisterBehaviour(Enemy_bullet1);
        }
    }
    public override void Clear()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write("      ");
        Console.SetCursorPosition(X, Y + 1);
        Console.Write("       ");
        Console.SetCursorPosition(X, Y + 2);
        Console.Write("       ");
        Console.SetCursorPosition(X, Y + 3);
        Console.Write("      ");
    }

    public override void Draw()
    {
        var prevColor = Console.ForegroundColor;
        Console.ForegroundColor = color;

        Console.SetCursorPosition(X, Y);
        Console.Write("  <---");
        Console.SetCursorPosition(X, Y + 1);
        Console.Write(".---/ |");
        Console.SetCursorPosition(X, Y + 2);
        Console.Write("'---\\ |");
        Console.SetCursorPosition(X, Y + 3);
        Console.Write("  <--");

        Console.ForegroundColor = prevColor;
    }
}
