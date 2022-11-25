namespace Fabulous.Maui.Controls;

public static class TransformDefaults
{
    public const double AnchorX = 0.5;
    public const double AnchorY = 0.5;
    public const double Rotation = 0.0;
    public const double RotationX = 0.0;
    public const double RotationY = 0.0;
    public const double Scale = 1.0;
    public const double ScaleX = 1.0;
    public const double ScaleY = 1.0;
    public const double TranslationX = 0.0;
    public const double TranslationY = 0.0;
}

public interface ITransformSetter
{
    void SetTranslationX(double value);
    void SetTranslationY(double value);
    void SetScale(double value);
    void SetScaleX(double value);
    void SetScaleY(double value);
    void SetRotation(double value);
    void SetRotationX(double value);
    void SetRotationY(double value);
    void SetAnchorX(double value);
    void SetAnchorY(double value);
}