using System;

namespace Aircash.Shared.Components
{
    public class RootFactory<K, T>
     where T : class, K, new()
    {
        public static K CreateInstance()
        {
            K objK;

            objK = new T();

            return objK;
        }
    }
}
