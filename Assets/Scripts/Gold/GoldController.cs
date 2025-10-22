using Core;

namespace Gold
{
    internal class GoldController
    {
        public static readonly GoldController Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;
        private readonly string _goldEntityKey = GoldEntityInfo.EntityKey;

        public bool CanChangeGold(int deltaAmount)
        {
            return _playerData.GetIntValue(_goldEntityKey) + deltaAmount >= 0;
        }

        public void ChangeGold(int deltaAmount)
        {
            if (CanChangeGold(deltaAmount))
            {
                var currentValue = _playerData.GetIntValue(_goldEntityKey);
                _playerData.SetIntValue(_goldEntityKey, currentValue + deltaAmount);
            }
        }
    }
}
