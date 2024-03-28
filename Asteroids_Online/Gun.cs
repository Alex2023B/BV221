using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Online;

public class Gun
{
    public List<Bullet> Bullets { get; } = new List<Bullet>();
    public Pen BulletPen { get; set; }

    public Gun(Pen bulletPen)
    {
        BulletPen = bulletPen;
    }
    public void Paint(Graphics g)
    {
        foreach (var bullet in Bullets)
        {
            bullet.Paint(g);
        }
    }
}
