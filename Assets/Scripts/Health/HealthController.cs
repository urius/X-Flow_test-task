using Core;

namespace Health
{
    internal class HealthController
    {
        public static readonly HealthController Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;
        private readonly string _healthEntityKey = HealthEntityInfo.EntityKey;

        public bool CanChangeHealth(int deltaAmount)
        {
            return _playerData.GetIntValue(_healthEntityKey) + deltaAmount >= 0;
        }

        public void ChangeHealth(int deltaAmount)
        {
            if (CanChangeHealth(deltaAmount))
            {
                var currentValue = _playerData.GetIntValue(_healthEntityKey);
                _playerData.SetIntValue(_healthEntityKey, currentValue + deltaAmount);
            }
        }
    }
}