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
            return _playerData.GetEntityValue<GoldEntityInfo, int>() + deltaAmount >= 0;
        }

        public void ChangeGold(int deltaAmount)
        {
            if (CanChangeGold(deltaAmount))
            {
                var currentValue = _playerData.GetEntityValue<GoldEntityInfo, int>();
                _playerData.SetEntityValue<GoldEntityInfo, int>(_goldEntityKey, currentValue + deltaAmount);
            }
        }
    }
}
