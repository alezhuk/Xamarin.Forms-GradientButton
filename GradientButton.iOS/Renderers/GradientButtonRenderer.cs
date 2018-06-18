using System;
using System.Linq;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using GradientButton.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(GradientButtonRenderer))]
namespace GradientButton.iOS.Renderers
{
    public class GradientButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradient = new CAGradientLayer()
                {
                    StartPoint = new CGPoint(0, 0.5),
                    EndPoint = new CGPoint(1, 0.5)
                };
                gradient.Locations = new NSNumber[] { .0f, 1f };
                gradient.CornerRadius = Element.CornerRadius;
                gradient.NeedsDisplayOnBoundsChange = true;
                gradient.MasksToBounds = true;

                gradient.Colors = new CGColor[]
                {
                    UIColor.FromRGB(157, 64, 168).CGColor,
                    UIColor.FromRGB(126, 45, 200).CGColor
                };

                var layer = Control?.Layer.Sublayers.FirstOrDefault();
                Control?.Layer.InsertSublayerBelow(gradient, layer);
            }
        }

        public override CGRect Frame
        {
            get
            {
                return base.Frame;
            }
            set
            {
                if (value.Width > 0 && value.Height > 0)
                {
                    foreach (var layer in Control?.Layer.Sublayers.Where(layer => layer is CAGradientLayer))
                    {
                        layer.Frame = new CGRect(0, 0, value.Width, value.Height);
                    }
                }
                base.Frame = value;
            }
        }
    }
}
