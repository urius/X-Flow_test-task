using Core;
using UnityEngine;

namespace Health
{
    internal class HealthService
    {
        public static readonly HealthService Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;
        
        private HealthEntityInfo _entityInfo;

        public void Initialize(HealthEntityInfo healthEntity)
        {
            _entityInfo = healthEntity;
        }

        public bool CanChangeHealth(int deltaAmount)
        {
            return GetCurrentHp() + deltaAmount > 0;
        }

        public void ChangeHealth(int deltaAmount)
        {
            if (CanChangeHealth(deltaAmount))
            {
                var currentValue = GetCurrentHp();
                _playerData.SetEntityValue(_entityInfo, currentValue + deltaAmount);
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
                
                _playerData.SetEntityValue(_entityInfo, newHp);
            }
        }

        public int GetCurrentHp()
        {
            return PlayerData.Instance.GetEntityValue<HealthEntityInfo, int>(_entityInfo);
        }

        private static int GetChangedByPercentHp(int initialHp, int deltaPercent)
        {
            var multiplier = deltaPercent / 100f;
            var deltaHp = Mathf.RoundToInt(initialHp * multiplier);
            
            return initialHp + deltaHp;
        }
    }
}