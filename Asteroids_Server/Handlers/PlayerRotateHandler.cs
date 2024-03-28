using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Server.Handlers;

public class PlayerRotateHandler
{
    public PlayerRotateHandler() { }

    public void Handle(Player_Server player,Point MousePosition)
    {
        float playerCenterX = player.p.X + player.s.Width / 2;
        float playerCenterY = player.p.Y + player.s.Height / 2;

        // Вычислите разницу между положением мыши и центром игрока
        float deltaX = MousePosition.X - playerCenterX;
        float deltaY = MousePosition.Y - playerCenterY;

        // Используйте функцию Math.Atan2 для вычисления угла
        double angleRadians = Math.Atan2(deltaY, deltaX);

        // Преобразуйте радианы в градусы, если это необходимо
        float angleDegrees = (float)(angleRadians * (180 / Math.PI));
        player.angle = angleDegrees;
        // В переменной angleDegrees теперь содержится угол между центром игрока и положением мыши

    }

}
