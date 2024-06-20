using HaloOnline.Server.Core.Http.Model.SessionControl;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface ISessionControlService
    {
        ClientGetStatusResult ClientGetStatus(ClientGetStatusRequest request);
    }
}
