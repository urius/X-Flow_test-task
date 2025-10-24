using Core;
using UnityEngine;

namespace Health
{
    internal class HealthService
    {
        public static readonly HealthService Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;
        private readonly string _healthEntityKey = HealthEntityInfo.EntityKey;

        public bool CanChangeHealth(int deltaAmount)
        {
            return _playerData.GetEntityValue<HealthEntityInfo, int>() + deltaAmount > 0;
        }

        public void ChangeHealth(int deltaAmount)
        {
            if (CanChangeHealth(deltaAmount))
            {
                var currentValue = _playerData.GetEntityValue<HealthEntityInfo, int>();
                _playerData.SetEntityValue<HealthEntityInfo, int>(_healthEntityKey, currentValue + deltaAmount);
            }
        }

        public bool CanChangeHealthPercent(int deltaPercent)
        {
            var currentHp = _playerData.GetEntityValue<HealthEntityInfo, int>();
            var newHp = GetChangedByPercentHp(currentHp, deltaPercent);

            return newHp > 0 && newHp != currentHp;
        }

        public void ChangeHealthPercent(int deltaPercent)
        {
            if (CanChangeHealthPercent(deltaPercent))
            {
                var currentHp = _playerData.GetEntityValue<HealthEntityInfo, int>();
                var newHp = GetChangedByPercentHp(currentHp, deltaPercent);
                
                _playerData.SetEntityValue<HealthEntityInfo, int>(_healthEntityKey, newHp);
            }
        }

        private static int GetChangedByPercentHp(int initialHp, int deltaPercent)
        {
            var multiplier = deltaPercent / 100f;
            var deltaHp = Mathf.RoundToInt(initialHp * multiplier);
            
            return initialHp + deltaHp;
        }
    }
}