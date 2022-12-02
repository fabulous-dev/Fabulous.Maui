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

public static class FabTransformSetters
{
    public static void SetTranslationX(FabElement target, double value) => ((IFabTransform)target).TranslationX = value;
    public static void SetTranslationY(FabElement target, double value) => ((IFabTransform)target).TranslationY = value;
    public static void SetScale(FabElement target, double value) => ((IFabTransform)target).Scale = value;
    public static void SetScaleX(FabElement target, double value) => ((IFabTransform)target).ScaleX = value;
    public static void SetScaleY(FabElement target, double value) => ((IFabTransform)target).ScaleY = value;
    public static void SetRotation(FabElement target, double value) => ((IFabTransform)target).Rotation = value;
    public static void SetRotationX(FabElement target, double value) => ((IFabTransform)target).RotationX = value;
    public static void SetRotationY(FabElement target, double value) => ((IFabTransform)target).RotationY = value;
    public static void SetAnchorX(FabElement target, double value) => ((IFabTransform)target).AnchorX = value;
    public static void SetAnchorY(FabElement target, double value) => ((IFabTransform)target).AnchorY = value;
}