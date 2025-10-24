using System;
using Core;

namespace VIP
{
    public class VipService
    {
        public static readonly VipService Instance = new();

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
                
                PlayerData.Instance.SetEntityValue<VipEntityInfo, TimeSpan>(newTime);
            }
        }

        public TimeSpan GetCurrentVipTime()
        {
            return PlayerData.Instance.GetEntityValue<VipEntityInfo, TimeSpan>();
        }
    }
}