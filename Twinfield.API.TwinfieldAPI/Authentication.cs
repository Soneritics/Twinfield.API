using System.Threading.Tasks;
using Twinfield.API.TwinfieldAPI.Dto;
using Twinfield.API.TwinfieldAPI.Services;

namespace Twinfield.API.TwinfieldAPI
{
    /// <summary>
    /// Authentication class.
    /// Takes care of logging in and out.
    /// </summary>
    public static class Authentication
    {
        /// <summary>
        /// The login URI, which is the same constant for any cluster
        /// </summary>
        private const string LoginClusterUri = "https://login.twinfield.com";

        public static async Task<Session> PasswordLogin(string user, string password, string organization)
        {
            using var service = new LoginSessionService(LoginClusterUri);
            return await service.PasswordLogin(user, password, organization);
        }

        /// <summary>
        /// Logs out the specified session.
        /// </summary>
        /// <param name="session">The session.</param>
        public static async Task Logout(Session session)
        {
            using var service = new SessionService(session);
            await service.Logout();
        }
    }
}
