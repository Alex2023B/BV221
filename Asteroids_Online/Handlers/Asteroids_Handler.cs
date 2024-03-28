using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Asteroids_Online.Handlers;

public class Asteroids_Handler
{
    static public Image img;
    public RectangleF asteroidRectangle;
    public Asteroids_Handler() { }
    public void PaintAsteroid(Graphics g, PointF p, Size s)
    {
        asteroidRectangle = new RectangleF(p, s);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.DrawImage(img, asteroidRectangle);
    }
    public void PaintAsteroids(Graphics g, Asteroid[] asteroids)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        foreach (Asteroid asteroid in asteroids)
        {
            asteroidRectangle = new RectangleF(asteroid.p, asteroid.s);
            g.DrawImage(img, asteroidRectangle);
        }
    }
}
