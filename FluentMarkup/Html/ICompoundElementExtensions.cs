namespace FluentMarkup.Html
{
    public static class ICompoundElementExtensions
    {
        public static IElement ToElement(this ICompoundElement helper)
        {
            var el = new BaseElement();

            el.AddChildren(helper.Elements);

            return el;
        }
    }
}