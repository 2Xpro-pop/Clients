using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Bll.Rest;
public class MementoMori
{
    public MementoMori(IUnitOfWork unitOfWork, IOfficeController officeController, IAuthClient authClient, IInventoryController inventoryController)
    {
        UnitOfWork = unitOfWork;
        OfficeController = officeController;
        AuthClient = authClient;
        InventoryController = inventoryController;
    }

    public IUnitOfWork UnitOfWork { get; }
    public IOfficeController OfficeController { get; }
    public IAuthClient AuthClient { get; }
    public IInventoryController InventoryController { get; }
}
