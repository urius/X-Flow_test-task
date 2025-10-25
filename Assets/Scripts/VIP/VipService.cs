using System;
using Core;

namespace VIP
{
    public class VipService
    {
        public static readonly VipService Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;
        
        private VipEntityInfo _entityInfo;

        public void Initialize(VipEntityInfo vipEntity)
        {
            _entityInfo = vipEntity;
        }

        public bool CanChangeVipTime(int deltaSeconds)
        {
            return GetCurrentVipTime().TotalSeconds + deltaSeconds >= 0;
        }

        public void ChangeVipTime(int deltaSeconds)
        {
            if (CanChangeVipTime(deltaSeconds))
            {
                var currentVipTime = GetCurrentVipTime();
                var newTime = TimeSpan.FromSeconds(currentVipTime.TotalSeconds + deltaSeconds);
                
                _playerData.SetEntityValue(_entityInfo, newTime);
            }
        }

        public TimeSpan GetCurrentVipTime()
        {
            return PlayerData.Instance.GetEntityValue<VipEntityInfo, TimeSpan>(_entityInfo);
        }
    }
}