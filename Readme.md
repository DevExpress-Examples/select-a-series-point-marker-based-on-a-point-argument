<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/189593629/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T828686)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
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
