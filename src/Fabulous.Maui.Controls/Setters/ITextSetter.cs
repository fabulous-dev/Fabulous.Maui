namespace Fabulous.Maui.Controls;

public static class TextDefaults
{
    public const string Text = "";
}

public interface ITextSetter: ITextStyleSetter
{
    void SetText(string value);
}