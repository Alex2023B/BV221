using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Server;

public class Bullet_Server
{
    public PointF StartPoint { get; set; }
    public PointF EndPoint { get; set; }
    public bool IsMoving { get; set; }
    public Rectangle Bounds { get; set; }

    public int DMG = 25;
    public int BULLET_SPEED = 7;
    private float radius = 3; // Размер шара, может быть понадобится в будущем.

    public Bullet_Server(PointF startPoint, PointF endPoint, Rectangle bounds)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
        IsMoving = true;
        Bounds = bounds;
    }

    public void Move()
    {
        if (IsMoving)
        {
            double angle = Math.Atan2(EndPoint.Y - StartPoint.Y, EndPoint.X - StartPoint.X);
            float stepX = (float)(Math.Cos(angle) * BULLET_SPEED); // Регулировка скорость пули здесь
            float stepY = (float)(Math.Sin(angle) * BULLET_SPEED);

            PointF newPoint = new PointF(EndPoint.X + stepX, EndPoint.Y + stepY);
            // Проверка столкновения с границей
            if ((!Bounds.Contains((int)newPoint.X, (int)newPoint.Y)))
            {
                IsMoving = false;
            }
            else
            {
                EndPoint = newPoint;

            }
        }
    }
}