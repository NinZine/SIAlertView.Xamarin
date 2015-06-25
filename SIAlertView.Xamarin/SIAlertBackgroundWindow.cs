using CoreGraphics;
using UIKit;
using System;

namespace SIAlert.Xamarin
{
    public class SIAlertBackgroundWindow : UIWindow
    {
        private SIAlertViewBackgroundStyle _Style;

        public SIAlertBackgroundWindow(SIAlertViewBackgroundStyle backgroundStyle, CGRect frame) : base(frame)
        {
            _Style = backgroundStyle;
            AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            Opaque = false;
            WindowLevel = Constants.UIWindowLevelSIAlertBackground;
        }

        public override void Draw(CGRect rect)
        {
            using (CGContext context = UIGraphics.GetCurrentContext())
            {
                switch (_Style)
                {
                    case SIAlertViewBackgroundStyle.Gradient:
                        {
                            nfloat[] locations = { 0.0f, 1.0f };
                            nfloat[] colors = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.75f };
                            CGGradient gradient = new CGGradient(CGColorSpace.CreateDeviceRGB(), colors, locations);

                            CGPoint center = new CGPoint(Bounds.Size.Width / 2, Bounds.Size.Height / 2);
                            nfloat radius = (nfloat)Math.Min(Bounds.Size.Width, Bounds.Size.Height);
                            context.DrawRadialGradient(gradient, center, 0, center, radius, CGGradientDrawingOptions.DrawsAfterEndLocation);
                            break;
                        }
                    case SIAlertViewBackgroundStyle.Solid:
                        {
                            UIColor.FromWhiteAlpha(0f, 0.5f).SetColor();
                            context.SetFillColor(UIColor.FromWhiteAlpha(0f, 0.5f).CGColor);
                            context.FillRect(Bounds);
                            break;
                        }
                }
            }
        }
    }
}