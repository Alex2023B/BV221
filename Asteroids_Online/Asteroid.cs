using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Online;

public class Asteroid
{
    // расположение эллипса
    public int INDEX;
    public PointF p;
    public Size s;
    public static Rectangle limits { get; set; } = new Rectangle(0, 0, 1920, 1080);
    public Asteroid(Point p, Size s)
    {
        this.p = p;
        this.s = s;
    }
}