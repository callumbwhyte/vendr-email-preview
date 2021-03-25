using System;
using Newtonsoft.Json;

namespace Vendr.Contrib.EmailPreview.Web.Models.Request
{
    public class EmailPreviewRequest
    {
        [JsonProperty("storeId")]
        public Guid StoreId { get; set; }

        [JsonProperty("templateId")]
        public Guid TemplateId { get; set; }

        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }

        [JsonProperty("culture")]
        public string Culture { get; set; }
    }
}