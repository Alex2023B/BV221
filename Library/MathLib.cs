using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public class MathLib
{
    public MathLib() { }
    public Point FindClosestPointWithinRadius(Point target, Point origin, int radius)
    {
        int deltaX = target.X - origin.X;
        int deltaY = target.Y - origin.Y;
        double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

        if (distance <= radius)
        {
            // Точка в радиусе int radius пикселей от игрока
            return target;
        }
        else
        {
            // Находим точку в радиусе
            double scale = radius / distance;
            int newX = (int)(origin.X + deltaX * scale);
            int newY = (int)(origin.Y + deltaY * scale);
            return new Point(newX, newY);
        }
    }

    public bool IsPointInsideAsteroid(PointF point,Point p, Size s)
    {
        float distanceX = point.X - (p.X + s.Width / 2);
        float distanceY = point.Y - (p.Y + s.Height / 2);

        float a = s.Width / 2;
        float b = s.Height / 2;

        return (distanceX * distanceX) / (a * a) + (distanceY * distanceY) / (b * b) <= 1;
    }

    public bool IsAsteroidHitPlayer(RectangleF asteroidRectangle, Point playerPoint, Size playerSize )
    {
        if (asteroidRectangle.Contains(playerPoint.X + playerSize.Width / 2, playerPoint.Y + 5) ||
        asteroidRectangle.Contains(playerPoint.X + 2, playerPoint.Y + playerSize.Height / 2) ||
        asteroidRectangle.Contains(playerPoint.X + playerSize.Width - 2, playerPoint.Y + playerSize.Height / 2) ||
        asteroidRectangle.Contains(playerPoint.X + playerSize.Width / 2, playerPoint.Y + playerSize.Height))
        {
            return true;
        }
        else
            return false;
    }
}
