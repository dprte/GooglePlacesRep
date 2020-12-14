using Aircash.Data.Model.GooglePlacesModel;
using Aircash.Interface.GooglePlaceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.Data.Repository.GooglePlacesRep
{
    public class GooglePlaceApiRepository : IGooglePlaceApiRepository<GooglePlace>
    {
        public void Delete(GooglePlace entity)
        {
            throw new NotImplementedException();
        }

        public GooglePlace Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GooglePlace> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<GooglePlace> GetPlaceDetails(int idPlace)
        {
            throw new NotImplementedException();
        }

        public bool Insert(GooglePlace entity)
        {
            throw new NotImplementedException();
        }

        public void Update(GooglePlace entity)
        {
            throw new NotImplementedException();
        }
    }
}
