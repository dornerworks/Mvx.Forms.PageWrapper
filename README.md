# Mvx.Forms.PageWrapper
Xamarin.Forms Page wrappers for MvvmCross the Android Fragment/Activity and the iOS ViewController

Inspired by Alex Dunn's blog posts:
* [Xamarin.Tip – Embed Your Xamarin.Forms Pages in Your Android Activities](https://alexdunn.org/2018/07/19/xamarin-tip-embed-your-xamarin-forms-pages-in-your-android-activities/).
* [Xamarin.Tip – Embed Your Xamarin.Forms Pages in Your iOS ViewControllers](https://alexdunn.org/2018/08/08/xamarin-tip-embed-your-xamarin-forms-pages-in-your-ios-viewcontrollers/)

## Introduction

Wraps a Xamarin.Forms Page inside a MvvmCross view. This allows for "native" navigation via MvvmCross. The result is that you can easily navigate between a native view and a embedded Xamarin.Forms page.

## How To Use

1. Create your Xamarin.Forms page by subclassing `MvxEmbeddedContentPage`.
2a. In your Android project, create a `MvxFormsActivity` or `MvxFormsFragment` to wrap your Xamarin.Forms page.
```C#
public class MyFormsFragment : MvxFormsFragment<MyPage, MyViewModel>
{
  protected override void OnCreate(Bundle savedInstanceState)
  {
    base.OnCreate(savedInstanceState);
    Page.BackgroundColor = Color.Red;
    ...
  }
}
```
2b. In your iOS project, create a `MvxFormsViewController` to wrap your Xamarin.Forms page.
```C#
public class MyFormsViewController : FormsViewController<MyPage, MyViewModel>
{
  public override void ViewDidLoad()
  {
    base.ViewDidLoad();
    Page.BackgroundColor = Color.Red;
    ...
  }
}
```

3. You can navigate to the ViewModel as your normall would in MvvmCross. The Xamarin.Forms page will be imbedded inside the activity/fragment. Binding works as expected.

## Customization

You can override the CreatePage method to handle the construction of the page.
```C#
protected override MyPage CreatePage()
{
  return new MyPage(paramter1, parameter2)
  {
    ViewModel = ViewModel
  };
}
```

### Android

You can override the `Frame` that the `MvxEmbeddedContentPage` is embedded into.

```c#
protected override UIView FragmentLayoutId()
{
  return Resource.Id.some_other_frame;
}
```

### iOS

You can override the `UIView` that the `MvxEmbeddedContentPage` is embedded into.

```c#
protected override UIView PageContainerView()
{
  return _someOtherView;
}
```

## Known Limitations

* Toolbars defined in Xamarin.Forms are ignored.
