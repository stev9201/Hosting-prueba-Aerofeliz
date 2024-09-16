using System.Web.Mvc;

namespace YourNamespace.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString NewRequestButton(this HtmlHelper htmlHelper)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var link = urlHelper.Action("Create", "Planes"); // Cambia "ControllerName" al nombre del controlador adecuado
            var button = string.Format("<p><a href='{0}' class='btn btn-success'>Nueva Solicitud</a></p>", link);
            return new MvcHtmlString(button);
        }
    }
}
