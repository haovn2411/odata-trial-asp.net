using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataBookStore.Entity;

namespace ODataBookStore
{
    public static class OdataConfig
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Book>("Books");
            builder.EntitySet<Press>("Presses");
            return builder.GetEdmModel();
        }
    }
}
