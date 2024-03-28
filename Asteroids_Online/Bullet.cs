using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Online;

public class Bullet
{
    public PointF StartPoint { get; set; }
    public PointF EndPoint { get; set; }
    public Pen BulletPen { get; set; }
    public bool IsMoving { get; set; }
    public Rectangle Bounds { get; set; }

    public int DMG = 25;
    public int BULLET_SPEED = 7;
    private float radius = 3; // Размер шара

    public Bullet(PointF startPoint, PointF endPoint, Pen bulletPen, Rectangle bounds)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
        BulletPen = bulletPen;
        IsMoving = true;
        Bounds = bounds;
    }
    public void Paint(Graphics g)
    {
        if (IsMoving)
        {
            g.FillEllipse(BulletPen.Brush, EndPoint.X - radius, EndPoint.Y - radius, 2 * radius, 2 * radius);
        }
    }
}