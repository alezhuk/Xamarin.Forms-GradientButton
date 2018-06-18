using System;
using Android.Content;
using GradientButton.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(GradientButtonRenderer))]
namespace GradientButton.Droid.Renderers
{
    public class GradientButtonRenderer : ButtonRenderer
    {
        public GradientButtonRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            var btn = this.Control as Android.Widget.Button;
            btn?.SetBackgroundResource(Resource.Drawable.gradient_button_style);
        }
    }
}
