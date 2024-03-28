using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Server;

public class Player_Server
{
    public float angle { get; set; }
    public int INDEX;
    public Size s = new Size(20, 30);
    public Point p;
    public Point velocity = new Point(3, 3); // Изменил скорость для более плавного движения
    public static Rectangle limits { get; set; } = new Rectangle(0, 0, 1920, 1080);
    public bool leftKeyPressed = false;
    public bool rightKeyPressed = false;
    public bool upKeyPressed = false;
    public bool downKeyPressed = false;
    public Gun_Server MyGun;
    public int HP = 100;
    public Player_Server()
    {
        p.X = 100;
        p.Y = 100;
        MyGun = new Gun_Server(new Point((int)p.X, (int)p.Y), limits);
    }

    public RectangleF playerRectanglr; // Переименовал playerRectanglr в playerRectangle

    public void KeyDown(Keys e)
    {
        // Использование switch для более читаемого кода
        switch (e)
        {
            case Keys.W:
                upKeyPressed = true;
                break;
            case Keys.S:
                downKeyPressed = true;
                break;
            case Keys.A:
                leftKeyPressed = true;
                break;
            case Keys.D:
                rightKeyPressed = true;
                break;
        }
    }

    public void KeyUp(Keys e)
    {
        // Использование switch для более читаемого кода
        switch (e)
        {
            case Keys.W:
                upKeyPressed = false;
                break;
            case Keys.S:
                downKeyPressed = false;
                break;
            case Keys.A:
                leftKeyPressed = false;
                break;
            case Keys.D:
                rightKeyPressed = false;
                break;
        }
    }

    public void Move()
    {
        // Оптимизированный код для движения и проверки столкновений
        int newX = p.X + (leftKeyPressed ? -velocity.X : rightKeyPressed ? velocity.X : 0);
        int newY = p.Y + (upKeyPressed ? -velocity.Y : downKeyPressed ? velocity.Y : 0);

        // Проверка столкновений с границами
        if (newX >= limits.Left && newX + s.Width <= limits.Right)
            p.X = newX;
        if (newY >= limits.Top && newY + s.Height <= limits.Bottom)
            p.Y = newY;

        // Обновление позиции оружия
        MyGun.StartPoint = new Point(p.X + s.Width / 2, p.Y + s.Height / 2);
    }
}