using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Vendr.Contrib.EmailPreview.Startup
{
    public class EmailPreviewComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<EmailPreviewMenuComponent>();
        }
    }
}