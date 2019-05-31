<!-- default file list -->
*Files to look at*:
* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
<!-- default file list end -->

# How to: Select a Series Point Marker Based on a Point Argument

This example shows how to select a point marker type depending on a point argument.

![](Images/result.png)

* Create a subclass of [DataTemplateSelector](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.datatemplateselector), override the [SelectTemplate](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.datatemplateselector.selecttemplate) method to create a custom date template selector, and provide logic to select an appropriate marker type.

* Use [ContentControl](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol) to specify the [CustomMarker2DModel.PointTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Charts.CustomMarker2DModel.PointTemplate) property.

* Assign the custom data template selector object to the [ContentControl.ContentTemplateSelector](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.contentcontrol.contenttemplateselector) property.


```xaml
<dxc:ChartControl>
    <dxc:XYDiagram2D EnableAxisXNavigation="True">
        <dxc:LineSeries2D
            DataSource="{Binding DataItems, RelativeSource={RelativeSource AncestorType=Window, Mode=FindAncestor}}"
            MarkerVisible="True"
            ArgumentDataMember="DateTimeStamp"
            ValueDataMember="Value">
            <dxc:LineSeries2D.MarkerModel>
                <dxc:CustomMarker2DModel>
                    <dxc:CustomMarker2DModel.PointTemplate>
                        <ControlTemplate>
                            <ContentControl
                                Content="{Binding SeriesPoint}"
                                ContentTemplateSelector="{StaticResource myDataTemplateSelector}"/>
                        </ControlTemplate>
                    </dxc:CustomMarker2DModel.PointTemplate>
                </dxc:CustomMarker2DModel>
            </dxc:LineSeries2D.MarkerModel>
        </dxc:LineSeries2D>
    </dxc:XYDiagram2D>
</dxc:ChartControl>
```