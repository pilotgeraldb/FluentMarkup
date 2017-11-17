using FluentMarkup.Html;

namespace FluentMarkup
{
    internal interface ITypeResolver<T>
    {
        T Instance();
        ITypeResolver<T> Resolve(string type);
        ITypeResolver<T> WithNamespace(string ns);
    }
}   