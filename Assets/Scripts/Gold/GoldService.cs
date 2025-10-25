using Core;

namespace Gold
{
    internal class GoldService
    {
        public static readonly GoldService Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;
        
        private GoldEntityInfo _entityInfo;

        public void Initialize(GoldEntityInfo goldEntity)
        {
            _entityInfo = goldEntity;
        }

        public bool CanChangeGold(int deltaAmount)
        {
            return GetCurrentGold() + deltaAmount >= 0;
        }

        public void ChangeGold(int deltaAmount)
        {
            if (CanChangeGold(deltaAmount))
            {
                var currentValue = GetCurrentGold();
                _playerData.SetEntityValue(_entityInfo, currentValue + deltaAmount);
            }
        }

        public int GetCurrentGold()
        {
            return PlayerData.Instance.GetEntityValue(_entityInfo, defaultValue: 0);
        }
    }
}
