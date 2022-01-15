using CustomerManagementModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagementBlazor.Services
{
    public interface ISettingAPIclient
    {
        Task<List<SettingDTO>> GetSettingList();
    }
}
