using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dal.Rest;

namespace Bll.Rest;
public static class MementoMoriBuilder
{
    public static MementoMori Create(Action<MementoMoriApi> api)
    {
        var mementoMoriApi = new MementoMoriApi();
        api(mementoMoriApi);

        return new MementoMori(
            new RestUnitOfWork(mementoMoriApi.RestClient, mementoMoriApi),
            new RestOfficeController(mementoMoriApi),
            new RestAuth(mementoMoriApi),
            new RestInventoryController(mementoMoriApi));
    }
}
