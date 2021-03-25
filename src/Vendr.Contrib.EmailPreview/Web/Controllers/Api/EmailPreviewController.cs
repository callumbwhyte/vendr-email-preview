using System.Net.Http;
using System.Web.Http;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
using Vendr.Contrib.EmailPreview.Web.Models.Request;
using Vendr.Core.Api;
using Vendr.Core.Templating;

namespace Vendr.Contrib.EmailPreview.Web.Controllers.Api
{
    [PluginController("Vendr")]
    public class EmailPreviewController : UmbracoAuthorizedApiController
    {
        private readonly IVendrApi _vendr;
        private readonly IEmailTemplateEngine _emailTemplateEngine;

        public EmailPreviewController(IVendrApi vendr, IEmailTemplateEngine emailTemplateEngine)
        {
            _vendr = vendr;
            _emailTemplateEngine = emailTemplateEngine;
        }

        [HttpGet]
        public IHttpActionResult RenderPreview([FromUri] EmailPreviewRequest request)
        {
            var emailTemplate = _vendr.GetEmailTemplate(request.TemplateId);

            if (emailTemplate == null)
            {
                return BadRequest($"Failed to find template {request.TemplateId}");
            }

            var order = _vendr.GetOrder(request.OrderId);

            if (order == null)
            {
                return BadRequest($"Failed to find order {request.OrderId}");
            }

            var view = _emailTemplateEngine.RenderTemplateView(emailTemplate.TemplateView, order, request.Culture);

            if (string.IsNullOrWhiteSpace(view) == true)
            {
                return NotFound();
            }

            var response = new HttpResponseMessage
            {
                Content = new StringContent(view)
            };

            return ResponseMessage(response);
        }
    }
}