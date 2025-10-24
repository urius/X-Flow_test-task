using Core;

namespace Gold
{
    internal class GoldService
    {
        public static readonly GoldService Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;

        public bool CanChangeGold(int deltaAmount)
        {
            return GetCurrentGold() + deltaAmount >= 0;
        }

        public void ChangeGold(int deltaAmount)
        {
            if (CanChangeGold(deltaAmount))
            {
                var currentValue = GetCurrentGold();
                _playerData.SetEntityValue<GoldEntityInfo, int>(currentValue + deltaAmount);
            }
        }

        public int GetCurrentGold()
        {
            return PlayerData.Instance.GetEntityValue<GoldEntityInfo, int>();
        }
    }
}
