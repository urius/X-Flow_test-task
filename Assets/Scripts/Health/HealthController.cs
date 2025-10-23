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
            return _playerData.GetEntityValue<HealthEntityInfo, int>() + deltaAmount >= 0;
        }

        public void ChangeHealth(int deltaAmount)
        {
            if (CanChangeHealth(deltaAmount))
            {
                var currentValue = _playerData.GetEntityValue<HealthEntityInfo, int>();
                _playerData.SetEntityValue<HealthEntityInfo, int>(_healthEntityKey, currentValue + deltaAmount);
            }
        }
    }
}