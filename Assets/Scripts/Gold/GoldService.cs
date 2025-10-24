using Core;

namespace Gold
{
    internal class GoldService
    {
        public static readonly GoldService Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;

        public bool CanChangeGold(GoldEntityInfo entityInfo, int deltaAmount)
        {
            return GetCurrentGold(entityInfo) + deltaAmount >= 0;
        }

        public void ChangeGold(GoldEntityInfo entityInfo, int deltaAmount)
        {
            if (CanChangeGold(entityInfo, deltaAmount))
            {
                var currentValue = GetCurrentGold(entityInfo);
                _playerData.SetEntityValue(entityInfo, currentValue + deltaAmount);
            }
        }

        public int GetCurrentGold(GoldEntityInfo entityInfo)
        {
            return PlayerData.Instance.GetEntityValue(entityInfo, defaultValue: 0);
        }
    }
}
