using System.Security.Cryptography.X509Certificates;

abstract class DirectionMovableBase : MovableBase
{
    public int Speed { get; protected set; }
    public Direction Direction
    {
        get;
        set;
    }
    public int Health
    {
        get;
        protected set;
    }
    public int Width
    {
        get;
        protected set;
    }

    public int Height
    {
        get;
        protected set;
    }


    protected readonly Level level;


    public DirectionMovableBase(Level level)
    {
        this.level = level;
    }


    public void Move(Direction direction)
    {
        Direction = direction;
        switch (direction)
        {
            case Direction.Left:
                if (X - Speed > 0 && !level[X - 1, Y])
                {
                    MoveTo(X - Speed, Y);
                }
                else
                {
                    OnHit();
                }
                break;

            case Direction.Right:
                if (X + Speed < level.Width - 1 && !level[X + Width, Y])
                {
                    MoveTo(X + Speed, Y);
                }
                else
                {
                    OnHit();
                }
                break;

            case Direction.Up:
                if (Y-Speed > 0 && !level[X, Y - 1])
                {
                    MoveTo(X, Y - Speed);
                }
                else
                {
                    OnHit();
                }
                break;

            case Direction.Down:
                if (Y + Speed < level.Height - 1 && !level[X, Y + Height])
                {
                    MoveTo(X, Y + Speed);
                }
                else
                {
                    OnHit();
                }
                break;
        }
    }

    public void Move() => Move(Direction);

    public virtual void OnHit() { }
}