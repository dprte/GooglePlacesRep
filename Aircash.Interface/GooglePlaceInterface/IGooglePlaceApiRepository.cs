using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Interface.GooglePlaceInterface
{
    public interface IGooglePlaceApiRepository<T> : IRepository<T> where T : class
    {
        List<T> GetPlaceDetails(int idPlace);
    }
}