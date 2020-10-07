# Mvx.Forms.PageWrapper.Android
Xamarin.Forms Page wrappers for MvvmCross Android Fragment/Activity

Inspired by [Alex Dunn's blog post](https://alexdunn.org/2018/07/19/xamarin-tip-embed-your-xamarin-forms-pages-in-your-android-activities/).

## Introduction

Wraps a Xamarin.Forms page inside a MvxActivity or MvxFragment. This allows for "native" navigation via MvvmCross. The result is that you can easily navigate between a native Activites/Fragments and a Xamarin.Forms page.

## How To Use

1. Create your Xamarin.Forms page as you normally would. No need to subclass MvxContentPage.

2. In your Android project, create a `MvxFormsActivity` or `MvxFormsFragment` to wrap your Xamarin.Forms page.
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

3. You can navigate to the ViewModel as your normall would in MvvmCross. The Xamarin.Forms page will be imbedded inside the activity/fragment. Binding works as expected.

## Known Limitations

* Toolbars defined in Xamarin.Forms are ignored.
