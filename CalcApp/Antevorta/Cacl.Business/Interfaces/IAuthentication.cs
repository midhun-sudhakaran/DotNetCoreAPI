using Cacl.Business.Model;
using Cacl.Business.Request;

namespace Calc.Business.Interfaces
{
    public interface IAuthentication
    {
        UserInfo GetUserInfo(UserRequest userRequest);
    }
}
