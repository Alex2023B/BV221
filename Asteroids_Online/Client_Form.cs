using System.Drawing.Drawing2D;
using System.Numerics;

namespace Asteroids_Online;

public partial class Client_Form : Form
{
    Player player; // ��������� ��������
    public Client_Form()
    {
        InitializeComponent();
    }

    private void RotateImage(Graphics g, Image image, Point center, float angle)
    {
        // �������� ������� �������������
        Matrix matrix = new Matrix();

        // ���������� ����� ��������
        matrix.Translate(center.X, center.Y);

        // ��������� ����������� �� �������� ���� (� ��������)
        matrix.Rotate(angle);

        // ����� ��������� � ��������� ���������
        matrix.Translate(-center.X, -center.Y);

        // ��������� ������� ������������� � ����������� ������
        g.Transform = matrix;
        g.DrawImage(image, player.p.X, player.p.Y, player.s.Width, player.s.Height);

        // �������� ������� �������������
        g.ResetTransform();
    }








}
