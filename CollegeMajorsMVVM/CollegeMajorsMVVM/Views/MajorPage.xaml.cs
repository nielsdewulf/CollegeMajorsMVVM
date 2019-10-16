using CollegeMajorsMVVM.ViewModels;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegeMajorsMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MajorPage : ContentPage
    {
        MajorViewModel view;
        public MajorPage(MajorViewModel mvm)
        {
            InitializeComponent();
            BindingContext = this.view = mvm;
        }

        public void OnCanvasViewPaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKColor bg = new SKColor(173, 216, 230);
            SKColor front = new SKColor(255, 192, 203);
            DrawGraph(view.Major.ShareOfWomen, bg, front, args);
        }
        public void OnCanvasViewPaintSurface_unemp(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKColor bg = new SKColor(0, 128, 0);
            SKColor front = new SKColor(139, 0, 0);
            DrawGraph(view.Major.UnemploymentRate, bg, front, args);
        }
        public void DrawGraph(double percentage, SKColor bgColor, SKColor frontColor, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKRect rect = new SKRect(13, 13, info.Height - 13, info.Height - 13);
            float startAngle = (float)0;
            float sweepAngle = (float)percentage / 100 * 360;

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = bgColor,
                StrokeWidth = 25


            };

            SKPaint arcPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = frontColor,
                StrokeWidth = 25


            };

            canvas.DrawOval(rect, paint);

            using (SKPath path = new SKPath())
            {
                path.AddArc(rect, startAngle, sweepAngle);
                canvas.DrawPath(path, arcPaint);
            }

        }
    }
}