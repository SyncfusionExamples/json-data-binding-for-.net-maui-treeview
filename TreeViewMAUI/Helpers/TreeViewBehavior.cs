using Syncfusion.Maui.TreeView;

namespace TreeViewMAUI
{
    public class TreeViewBehavior : Behavior<SfTreeView>
    {
        protected override void OnAttachedTo(SfTreeView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Loaded += Bindable_Loaded;
        }

        private void Bindable_Loaded(object? sender, TreeViewLoadedEventArgs e)
        {
            (sender as SfTreeView).ExpandAll();
        }

        protected override void OnDetachingFrom(SfTreeView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Loaded -= Bindable_Loaded;
        }
    }
}
