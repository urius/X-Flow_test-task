using System;
using Core;

namespace VIP
{
    public class VipController
    {
        public static readonly VipController Instance = new();

        public bool CanChangeVipTime(int deltaSeconds)
        {
            return PlayerData.Instance.GetEntityValue<VipEntityInfo, TimeSpan>().TotalSeconds + deltaSeconds >= 0;
        }

        public void ChangeVipTime(int deltaSeconds)
        {
            if (CanChangeVipTime(deltaSeconds))
            {
                var currentVipTime = PlayerData.Instance.GetEntityValue<VipEntityInfo, TimeSpan>();
                var newTime = TimeSpan.FromSeconds(currentVipTime.TotalSeconds + deltaSeconds);
                
                PlayerData.Instance.SetEntityValue<VipEntityInfo, TimeSpan>(VipEntityInfo.EntityKey, newTime);
            }
        }
    }
}