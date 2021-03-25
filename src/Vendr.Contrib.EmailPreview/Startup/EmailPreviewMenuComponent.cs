using Umbraco.Core.Composing;
using Umbraco.Core.Services;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Trees;
using static Vendr.Core.Constants.Entities;
using static Vendr.Web.Constants.Trees;

namespace Vendr.Contrib.EmailPreview.Startup
{
    public class EmailPreviewMenuComponent : IComponent
    {
        private readonly ILocalizedTextService _localizedTextService;

        public EmailPreviewMenuComponent(ILocalizedTextService localizedTextService)
        {
            _localizedTextService = localizedTextService;
        }

        public void Initialize()
        {
            TreeControllerBase.MenuRendering += TreeControllerBase_MenuRendering;
        }

        public void Terminate()
        {
            TreeControllerBase.MenuRendering -= TreeControllerBase_MenuRendering;
        }

        private void TreeControllerBase_MenuRendering(TreeControllerBase sender, MenuRenderingEventArgs e)
        {
            if (sender.TreeAlias == Settings.Alias)
            {
                if (e.QueryStrings["nodeType"] == EntityTypes.EmailTemplate)
                {
                    var name = _localizedTextService.Localize($"general/preview");

                    var menuItem = new MenuItem("preview", name)
                    {
                        Icon = "eye"
                    };

                    e.Menu.Items.Add(menuItem);
                }
            }
        }
    }
}