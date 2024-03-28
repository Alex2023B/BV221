using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Server;

public class Gun_Server
{
    public Point StartPoint { get; set; }
    public List<Bullet_Server> Bullets { get; } = new List<Bullet_Server>();
    public Rectangle Bounds { get; set; }

    public Gun_Server(Point startPoint, Rectangle bounds)
    {
        StartPoint = startPoint;
        Bounds = bounds;
    }

    public void Fire(Point endPoint)
    {
        Bullets.Add(new Bullet_Server(StartPoint, endPoint, Bounds));
    }

    public void Move()
    {
        for (int i = Bullets.Count - 1; i >= 0; i--)
        {
            Bullets[i].Move();
            if (!Bullets[i].IsMoving)
            {
                Bullets.RemoveAt(i);
            }
        }
    }
}
