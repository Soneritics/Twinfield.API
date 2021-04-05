using System;

namespace Api.Dto.OAuth
{
    public class OAuthToken
    {
        public string Accesstoken { get; set; }

        public string RefreshToken { get; set; }

        private int _expiresIn;

        public int ExpiresIn
        {
            get => _expiresIn;
            set
            {
                _expiresIn = value;
                ExpiresAt = Created.AddSeconds(_expiresIn);
            }
        }

        public DateTime Created { get; } = DateTime.Now;
        public DateTime ExpiresAt { get; private set; } = DateTime.Now;

        public bool IsExpired()
        {
            return ExpiresAt <= DateTime.Now.Subtract(new TimeSpan(0, 1, 0));
        }
    }
}
