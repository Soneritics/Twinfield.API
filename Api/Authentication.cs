using System.Threading.Tasks;
using Api.Dto;
using Api.Services;

namespace Api
{
    /// <summary>
    /// Authentication class.
    /// Takes care of logging in and out.
    /// </summary>
    public static class Authentication
    {
        /// <summary>
        /// Logs in using user/password.
        /// This will be phased out in 2021.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <param name="organization">The organization.</param>
        /// <returns></returns>
        public static async Task<Session> PasswordLogin(string user, string password, string organization)
        {
            using var service = new LoginSessionService();
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
