using Core;
using UnityEngine;

namespace Health
{
    internal class HealthService
    {
        public static readonly HealthService Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;

        public bool CanChangeHealth(int deltaAmount)
        {
            return GetCurrentHp() + deltaAmount > 0;
        }

        public void ChangeHealth(int deltaAmount)
        {
            if (CanChangeHealth(deltaAmount))
            {
                var currentValue = GetCurrentHp();
                _playerData.SetEntityValue<HealthEntityInfo, int>(currentValue + deltaAmount);
            }
        }

        public bool CanChangeHealthPercent(int deltaPercent)
        {
            var currentHp = GetCurrentHp();
            var newHp = GetChangedByPercentHp(currentHp, deltaPercent);

            return newHp > 0 && newHp != currentHp;
        }

        public void ChangeHealthPercent(int deltaPercent)
        {
            if (CanChangeHealthPercent(deltaPercent))
            {
                var currentHp = GetCurrentHp();
                var newHp = GetChangedByPercentHp(currentHp, deltaPercent);
                
                _playerData.SetEntityValue<HealthEntityInfo, int>(newHp);
            }
        }

        public int GetCurrentHp()
        {
            const int defaultHp = 100;
            
            return _playerData.GetEntityValue<HealthEntityInfo, int>(defaultHp);
        }

        private static int GetChangedByPercentHp(int initialHp, int deltaPercent)
        {
            var multiplier = deltaPercent / 100f;
            var deltaHp = Mathf.RoundToInt(initialHp * multiplier);
            
            return initialHp + deltaHp;
        }
    }
}