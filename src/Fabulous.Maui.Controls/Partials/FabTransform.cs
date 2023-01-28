using Microsoft.Maui;

namespace Fabulous.Maui.Controls;

public interface IFabTransform: ITransform
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