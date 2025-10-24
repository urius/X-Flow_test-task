using Core;
using UnityEngine;

namespace Health
{
    internal class HealthService
    {
        public static readonly HealthService Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;

        public bool CanChangeHealth(HealthEntityInfo entityInfo, int deltaAmount)
        {
            return GetCurrentHp(entityInfo) + deltaAmount > 0;
        }

        public void ChangeHealth(HealthEntityInfo entityInfo, int deltaAmount)
        {
            if (CanChangeHealth(entityInfo, deltaAmount))
            {
                var currentValue = GetCurrentHp(entityInfo);
                _playerData.SetEntityValue(entityInfo, currentValue + deltaAmount);
            }
        }

        public bool CanChangeHealthPercent(HealthEntityInfo entityInfo, int deltaPercent)
        {
            var currentHp = GetCurrentHp(entityInfo);
            var newHp = GetChangedByPercentHp(currentHp, deltaPercent);

            return newHp > 0 && newHp != currentHp;
        }

        public void ChangeHealthPercent(HealthEntityInfo entityInfo, int deltaPercent)
        {
            if (CanChangeHealthPercent(entityInfo, deltaPercent))
            {
                var currentHp = GetCurrentHp(entityInfo);
                var newHp = GetChangedByPercentHp(currentHp, deltaPercent);
                
                _playerData.SetEntityValue(entityInfo, newHp);
            }
        }

        public int GetCurrentHp(HealthEntityInfo entityInfo)
        {
            const int defaultHp = 100;
            
            return _playerData.GetEntityValue(entityInfo, defaultHp);
        }

        private static int GetChangedByPercentHp(int initialHp, int deltaPercent)
        {
            var multiplier = deltaPercent / 100f;
            var deltaHp = Mathf.RoundToInt(initialHp * multiplier);
            
            return initialHp + deltaHp;
        }
    }
}