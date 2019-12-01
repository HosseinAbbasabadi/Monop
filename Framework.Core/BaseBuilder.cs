using System.Collections.Generic;

namespace Framework.Core
{
    public abstract class BaseBuilder<T>
    {
        public abstract T Build();

        public List<T> Build(int count)
        {
            var result = new List<T>();
            for (var i = 0; i < count; i++)
            {
                result.Add(Build());
            }

            return result;
        }
    }
}