using System;
using Microsoft.Maui.Controls;

namespace XTomStudio.Helpers
{
    public class ParallaxBehavior : Behavior<ScrollView>
    {
        public static readonly BindableProperty ParallaxViewProperty =
           BindableProperty.Create(nameof(ParallaxView), typeof(View), typeof(ParallaxBehavior));

        public View ParallaxView
        {
            get => (View)GetValue(ParallaxViewProperty);
            set => SetValue(ParallaxViewProperty, value);
        }

        protected override void OnAttachedTo(ScrollView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Scrolled += OnScrolled;
        }

        protected override void OnDetachingFrom(ScrollView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Scrolled -= OnScrolled;
        }

        private void OnScrolled(object sender, ScrolledEventArgs e)
        {
            if (ParallaxView != null)
            {
                ParallaxView.TranslationY = e.ScrollY * 0.5; // Adjust the factor as needed
            }
        }
    }
}
