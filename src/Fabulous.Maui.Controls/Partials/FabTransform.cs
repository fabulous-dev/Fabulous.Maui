using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabTransform: ITransform
{
    new double TranslationX { get; set; }
    new double TranslationY { get; set; }
    new double Scale { get; set; }
    new double ScaleX { get; set; }
    new double ScaleY { get; set; }
    new double Rotation { get; set; }
    new double RotationX { get; set; }
    new double RotationY { get; set; }
    new double AnchorX { get; set; }
    new double AnchorY { get; set; }
}

public static class FabTransform
{
    public static void SetTranslationX(IFabTransform target, double value) => target.TranslationX = value;
    public static void SetTranslationY(IFabTransform target, double value) => target.TranslationY = value;
    public static void SetScale(IFabTransform target, double value) => target.Scale = value;
    public static void SetScaleX(IFabTransform target, double value) => target.ScaleX = value;
    public static void SetScaleY(IFabTransform target, double value) => target.ScaleY = value;
    public static void SetRotation(IFabTransform target, double value) => target.Rotation = value;
    public static void SetRotationX(IFabTransform target, double value) => target.RotationX = value;
    public static void SetRotationY(IFabTransform target, double value) => target.RotationY = value;
    public static void SetAnchorX(IFabTransform target, double value) => target.AnchorX = value;
    public static void SetAnchorY(IFabTransform target, double value) => target.AnchorY = value;
}