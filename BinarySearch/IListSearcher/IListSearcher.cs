namespace IListSearcher
{
    using System.Collections.Generic;

    public interface IListSearcher<T>
    {
        int Search(IList<T> list, T key);
    }
}
