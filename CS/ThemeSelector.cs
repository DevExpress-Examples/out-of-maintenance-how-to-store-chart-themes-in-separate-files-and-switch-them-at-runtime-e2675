using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Styling {
    public class ThemeResourceDictionary : ResourceDictionary { }

    public class ThemeSelector : DependencyObject {
        public static readonly DependencyProperty CurrentThemeDictionaryProperty = DependencyProperty.RegisterAttached(
            "CurrentThemeDictionary",
            typeof(Uri),
            typeof(ThemeSelector),
            new UIPropertyMetadata(null, CurrentThemeDictionaryChanged));

        public static Uri GetCurrentThemeDictionary(DependencyObject obj) {
            return (Uri)obj.GetValue(CurrentThemeDictionaryProperty);
        }

        public static void SetCurrentThemeDictionary(DependencyObject obj, Uri value) {
            obj.SetValue(CurrentThemeDictionaryProperty, value);
        }

        private static void CurrentThemeDictionaryChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e) {
            if (obj is FrameworkElement) {
                ApplyTheme(obj as FrameworkElement, GetCurrentThemeDictionary(obj));
            }
        }

        private static void ApplyTheme(FrameworkElement targetElement, Uri dictionaryUri) {
            ThemeResourceDictionary themeDictionary = new ThemeResourceDictionary();

            if (dictionaryUri != null) {
                themeDictionary.Source = dictionaryUri;

                // add the new dictionary to the collection of merged dictionaries of the target object
                targetElement.Resources.MergedDictionaries.Insert(0, themeDictionary);
            }

            // find if the target element already has a theme applied
            List<ThemeResourceDictionary> existingDictionaries =
                (from dictionary in targetElement.Resources.MergedDictionaries.OfType<ThemeResourceDictionary>()
                 select dictionary).ToList();

            // remove the existing dictionaries 
            foreach (ThemeResourceDictionary thDictionary in existingDictionaries) {
                if (themeDictionary == thDictionary) continue;  // don't remove the newly added dictionary
                targetElement.Resources.MergedDictionaries.Remove(thDictionary);
            }
        }
    }
}