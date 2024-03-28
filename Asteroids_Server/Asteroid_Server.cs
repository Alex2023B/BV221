using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Asteroids_Server;

internal class Asteroid_Server
{
    static Random rand = new Random();
    // расположение эллипса
    public PointF p;
    public Size s;
    public int HP;
    public int DMG;
    // случайная скорость и направление
    PointF velocity = new PointF((rand.Next(50) - 25) / 10.0F, (rand.Next(50) - 25) / 10.0F);
    // это необходимо установить в начале программы
    public static Rectangle limits { get; set; } = new Rectangle(0, 0, 1920, 1080);
    public Asteroid_Server(Point p, Size s)
    {
        this.p = p;
        this.s = s;
        //brush = brushes[rand.Next(0, 8)];
        HP = rand.Next(s.Width, s.Width * 2);
        DMG = rand.Next(1, s.Width - 15);

    }
    //Brush brush;
    public RectangleF asteroidRectangle;
    public void Move(List<Asteroid_Server> otherAsteroids)
    {
        p.X += velocity.X;
        p.Y += velocity.Y;
        foreach (Asteroid_Server otherAsteroid in otherAsteroids)
        {
            if (otherAsteroid != this)
            {
                double distance = Math.Sqrt(Math.Pow(p.X - otherAsteroid.p.X, 2) + Math.Pow(p.Y - otherAsteroid.p.Y, 2));

                // Измените это расстояние на то, которое считается достаточным для отталкивания

                double minDistance = 0;
                if (this.s.Height < otherAsteroid.s.Height)
                {
                    minDistance = this.s.Height;
                }
                else
                {
                    minDistance = otherAsteroid.s.Height;
                }

                if (distance < minDistance)
                {
                    double angle = Math.Atan2(p.Y - otherAsteroid.p.Y, p.X - otherAsteroid.p.X);
                    float speed = rand.Next(15, 30) / 10;
                    // Устанавливаем новое направление движения, чтобы оттолкнуть астероиды
                    velocity.X = (float)(Math.Cos(angle) * speed);
                    velocity.Y = (float)(Math.Sin(angle) * speed);

                    // Также изменяем скорость другого астероида
                    otherAsteroid.velocity.X = (float)(Math.Cos(angle + Math.PI) * speed);
                    otherAsteroid.velocity.Y = (float)(Math.Sin(angle + Math.PI) * speed);
                }
            }
        }

        if ((p.X < limits.Left && velocity.X < 0) || (p.X > limits.Right - s.Width && velocity.X > 0))
        {
            velocity.X = -velocity.X;
        }

        if ((p.Y < limits.Top && velocity.Y < 0) || (p.Y > limits.Bottom - s.Height && velocity.Y > 0))
        {
            velocity.Y = -velocity.Y;
        }
    }
}
