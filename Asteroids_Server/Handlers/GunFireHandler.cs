using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Server.Handlers;

public class GunFireHandler
{
    MathLib MathLib;
    GunFireHandler()
    {
        MathLib = new MathLib();
    }

    public void Handle(Player_Server player, Point MousePosition)
    {
        Point mousePosition = MousePosition;
        Point playerPosition = new Point(player.p.X + player.s.Width / 2, player.p.Y + player.s.Height / 2);

        // Находим ближайшую точку в радиусе 15 пикселей от центра игрока
        Point closestPoint = MathLib.FindClosestPointWithinRadius(mousePosition, playerPosition, 20);

        // Отправляем ближайшую точку в Fire метод игрока
        player.MyGun.Fire(closestPoint);
    }
}
