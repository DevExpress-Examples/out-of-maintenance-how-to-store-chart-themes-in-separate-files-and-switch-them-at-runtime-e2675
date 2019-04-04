<!-- default file list -->
*Files to look at*:

* [Theme1.xaml](./CS/Themes/Theme1.xaml) (VB: [Theme1.xaml](./VB/Themes/Theme1.xaml))
* [Theme2.xaml](./CS/Themes/Theme2.xaml) (VB: [Theme2.xaml](./VB/Themes/Theme2.xaml))
* [Theme3.xaml](./CS/Themes/Theme3.xaml) (VB: [Theme3.xaml](./VB/Themes/Theme3.xaml))
* [ThemeSelector.cs](./CS/ThemeSelector.cs) (VB: [ThemeSelector.vb](./VB/ThemeSelector.vb))
* [Window1.xaml](./CS/Window1.xaml) (VB: [Window1.xaml](./VB/Window1.xaml))
* [Window1.xaml.cs](./CS/Window1.xaml.cs) (VB: [Window1.xaml.vb](./VB/Window1.xaml.vb))
<!-- default file list end -->
# How to store chart themes in separate files and switch them at runtime


<p>This example illustrates how to apply external themes to ChartControl at runtime. Themes are stored in separate XAML files in the \Themes subdirectory of a root application directory. The actual chart themes are stored in the form of standard WPF Styles (see the <a href="http://msdn.microsoft.com/en-us/library/ms745683.aspx"><u>Styling and Templating</u></a> MSDN article). This example is focused on styling chart's palette (<a href="http://documentation.devexpress.com/#WPF/DevExpressXpfChartsChartControl_Palettetopic"><u>ChartControl.Palette Property</u></a>). The ThemeSelector.CurrentThemeDictionary attached property is used to manage themes. Whenever its value is changed, a special ResourceDictionary is loaded into the application context and inserted into the merged resource dictionaries collection of a target framework element. Then WPF re-renders its child elements accordingly.</p>

<br/>


