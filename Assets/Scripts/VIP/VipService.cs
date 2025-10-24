using System;
using Core;

namespace VIP
{
    public class VipService
    {
        public static readonly VipService Instance = new();

        public bool CanChangeVipTime(VipEntityInfo entityInfo, int deltaSeconds)
        {
            return GetCurrentVipTime(entityInfo).TotalSeconds + deltaSeconds >= 0;
        }

        public void ChangeVipTime(VipEntityInfo entityInfo, int deltaSeconds)
        {
            if (CanChangeVipTime(entityInfo, deltaSeconds))
            {
                var currentVipTime = GetCurrentVipTime(entityInfo);
                var newTime = TimeSpan.FromSeconds(currentVipTime.TotalSeconds + deltaSeconds);
                
                PlayerData.Instance.SetEntityValue(entityInfo, newTime);
            }
        }

        public TimeSpan GetCurrentVipTime(VipEntityInfo entityInfo)
        {
            return PlayerData.Instance.GetEntityValue<VipEntityInfo, TimeSpan>(entityInfo);
        }
    }
}