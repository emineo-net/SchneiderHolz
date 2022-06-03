using Microsoft.AspNetCore.Components;

namespace BlazorTable
{
    public partial class ToolBar : ComponentBase
    {
        [CascadingParameter(Name = "Table")]
        public ITable Table { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }


        protected override void OnInitialized()
        {
            Table.SetLoadingToolBarTemplate(this);
        }
    }
}
