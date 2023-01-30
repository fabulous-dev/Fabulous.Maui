using Microsoft.Maui;
using Microsoft.Maui.Handlers.Defaults;
using Microsoft.Maui.Layouts;

namespace Fabulous.Maui
{
    public interface IFabGridLayout : IGridLayout, IFabLayout
    {
        void SetColumnDefinitions(IReadOnlyList<IGridColumnDefinition> value);
        void SetRowDefinitions(IReadOnlyList<IGridRowDefinition> value);
        void SetColumnSpacing(double value);
        void SetRowSpacing(double value);
    }
    
    public static class FabGridLayoutAttachedDataKeys
    {
        public const string Row = $"{nameof(IFabGridLayout)}_{nameof(Row)}";
        public const string RowSpan = $"{nameof(IFabGridLayout)}_{nameof(RowSpan)}";
        public const string Column = $"{nameof(IFabGridLayout)}_{nameof(Column)}";
        public const string ColumnSpan = $"{nameof(IFabGridLayout)}_{nameof(ColumnSpan)}";
    }
}

namespace Fabulous.Maui.Controls
{
    public class FabGridLayout: FabLayout, IFabGridLayout
    {
        protected override ILayoutManager CreateLayoutManager() => new GridLayoutManager(this);
        
        public int GetRow(IView view) => view.GetAttachedData(FabGridLayoutAttachedDataKeys.Row, GridLayoutDefaults.Row);
        public int GetRowSpan(IView view) => view.GetAttachedData(FabGridLayoutAttachedDataKeys.RowSpan, GridLayoutDefaults.RowSpan);
        public int GetColumn(IView view) => view.GetAttachedData(FabGridLayoutAttachedDataKeys.Column, GridLayoutDefaults.Column);
        public int GetColumnSpan(IView view) => view.GetAttachedData(FabGridLayoutAttachedDataKeys.ColumnSpan, GridLayoutDefaults.ColumnSpan);

        public IReadOnlyList<IGridRowDefinition> RowDefinitions { get; private set; } = GridLayoutDefaults.RowDefinitions;
        public IReadOnlyList<IGridColumnDefinition> ColumnDefinitions { get; private set; } = GridLayoutDefaults.ColumnDefinitions;
        public double RowSpacing { get; private set; } = GridLayoutDefaults.RowSpacing;
        public double ColumnSpacing { get; private set; } = GridLayoutDefaults.ColumnSpacing;
        
        public void SetColumnDefinitions(IReadOnlyList<IGridColumnDefinition> value) => ColumnDefinitions = value;
        public void SetRowDefinitions(IReadOnlyList<IGridRowDefinition> value) => RowDefinitions = value;
        public void SetColumnSpacing(double value) => ColumnSpacing = value;
        public void SetRowSpacing(double value) => RowSpacing = value;
    }
}