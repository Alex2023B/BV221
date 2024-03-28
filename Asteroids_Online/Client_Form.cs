using System.Drawing.Drawing2D;
using System.Numerics;

namespace Asteroids_Online;

public partial class Client_Form : Form
{
    Player player; // временная заглушка
    public Client_Form()
    {
        InitializeComponent();
    }

    private void RotateImage(Graphics g, Image image, Point center, float angle)
    {
        // Создайте матрицу трансформации
        Matrix matrix = new Matrix();

        // Установите центр вращения
        matrix.Translate(center.X, center.Y);

        // Поверните изображение на заданный угол (в градусах)
        matrix.Rotate(angle);

        // Снова вернитесь в начальное положение
        matrix.Translate(-center.X, -center.Y);

        // Примените матрицу трансформации к изображению игрока
        g.Transform = matrix;
        g.DrawImage(image, player.p.X, player.p.Y, player.s.Width, player.s.Height);

        // Сбросьте матрицу трансформации
        g.ResetTransform();
    }








}
