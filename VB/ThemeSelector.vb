Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows

Namespace Styling

    Public Class ThemeResourceDictionary
        Inherits ResourceDictionary

    End Class

    Public Class ThemeSelector
        Inherits DependencyObject

        Public Shared ReadOnly CurrentThemeDictionaryProperty As DependencyProperty = DependencyProperty.RegisterAttached("CurrentThemeDictionary", GetType(Uri), GetType(ThemeSelector), New UIPropertyMetadata(Nothing, AddressOf CurrentThemeDictionaryChanged))

        Public Shared Function GetCurrentThemeDictionary(ByVal obj As DependencyObject) As Uri
            Return CType(obj.GetValue(CurrentThemeDictionaryProperty), Uri)
        End Function

        Public Shared Sub SetCurrentThemeDictionary(ByVal obj As DependencyObject, ByVal value As Uri)
            obj.SetValue(CurrentThemeDictionaryProperty, value)
        End Sub

        Private Shared Sub CurrentThemeDictionaryChanged(ByVal obj As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            If TypeOf obj Is FrameworkElement Then
                Call ApplyTheme(TryCast(obj, FrameworkElement), GetCurrentThemeDictionary(obj))
            End If
        End Sub

        Private Shared Sub ApplyTheme(ByVal targetElement As FrameworkElement, ByVal dictionaryUri As Uri)
            Dim themeDictionary As ThemeResourceDictionary = New ThemeResourceDictionary()
            If dictionaryUri IsNot Nothing Then
                themeDictionary.Source = dictionaryUri
                ' add the new dictionary to the collection of merged dictionaries of the target object
                targetElement.Resources.MergedDictionaries.Insert(0, themeDictionary)
            End If

            ' find if the target element already has a theme applied
            Dim existingDictionaries As List(Of ThemeResourceDictionary) =(From dictionary In targetElement.Resources.MergedDictionaries.OfType(Of ThemeResourceDictionary)() Select dictionary).ToList()
            ' remove the existing dictionaries 
            For Each thDictionary As ThemeResourceDictionary In existingDictionaries
                If themeDictionary Is thDictionary Then Continue For ' don't remove the newly added dictionary
                targetElement.Resources.MergedDictionaries.Remove(thDictionary)
            Next
        End Sub
    End Class
End Namespace
