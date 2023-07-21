using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Rendering;
using D3DDemo.ViewModels;

namespace D3DDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new Transform3DPageViewModel();
    }

    private void DrawCube()
    {
        // 创建一个 Canvas 控件用于绘图
        var canvas = new Canvas();

        // 设置画布的宽度和高度
        canvas.Width = 500;
        canvas.Height = 500;

        // 设置画笔和填充颜色
        var pen = new Pen(Brushes.Black, 1);
        var fillBrush = Brushes.Red;

        // 定义立方体的顶点坐标
        var vertices = new[]
        {
            new Vector3D(0, 0, 0),
            new Vector3D(100, 0, 0),
            new Vector3D(100, 100, 0),
            new Vector3D(0, 100, 0),
            new Vector3D(0, 0, 100),
            new Vector3D(100, 0, 100),
            new Vector3D(100, 100, 100),
            new Vector3D(0, 100, 100)
        };

        // 定义立方体的面，每个面上的顶点为一个多边形
        var faces = new[]
        {
            new[] { vertices[0], vertices[1], vertices[2], vertices[3] }, // 前面
            // new[] { vertices[1], vertices[5], vertices[6], vertices[2] }, // 右面
            // new[] { vertices[5], vertices[4], vertices[7], vertices[6] }, // 上面
            // new[] { vertices[4], vertices[0], vertices[3], vertices[7] }, // 左面
            // new[] { vertices[3], vertices[2], vertices[6], vertices[7] }, // 后面
            // new[] { vertices[4], vertices[5], vertices[1], vertices[0] }  // 下面
        };

        // 绘制立方体的各个面
        foreach (var face in faces)
        {
            var points = new List<Point>();

            foreach (var vertex in face)
            {
                var point = Project3DTo2D(vertex);
                points.Add(point);
            }

            var polygon = new Polygon()
            {
                Points = points,
                Stroke = pen.Brush,
                StrokeThickness = pen.Thickness,
                Fill = fillBrush
            };

            canvas.Children.Add(polygon);
        }

        // 将Canvas控件添加到窗口中进行展示
        Content = canvas;
    }

    // 将3D坐标映射到2D平面
    private Point Project3DTo2D(Vector3D point3D)
    {
        return new Point(point3D.X + 100, point3D.Y + 100); // 在2D平面上偏移坐标，以便更好地显示立方体
    }
}