using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Online;

public class Player
{
    public float angle { get; set; }
    public int INDEX;
    public Size s = new Size(20, 30);
    public Point p;
    public Gun MyGun;
    public int HP = 100;
    public Player(PictureBox pictureBox)
    {
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox.BackColor = Color.Transparent;
        p.X = 100;
        p.Y = 100;
        MyGun = new Gun(Pens.White);
    }

    public RectangleF playerRectanglr; // Переименовал playerRectanglr в playerRectangle

    public void Paint(Graphics g)
    {
        playerRectanglr = new RectangleF(p.X, p.Y, s.Width, s.Height);
        // Удалено отображение изображения внутри PictureBox, так как оно не используется в методе Paint

        // Нарисуйте игрока непосредственно на Graphics объекте
        g.FillRectangle(Brushes.White, playerRectanglr);
    }
}