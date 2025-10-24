using Core;
using UnityEngine;

namespace VIP.Actions
{
    [CreateAssetMenu(fileName = "ChangeVipTimeAction", menuName = "ScriptableObject/Actions/ChangeVipTimeAction")]
    public class ChangeVipTimeAction : EntityActionBase<VipEntityInfo>
    {
        [SerializeField] private int _deltaSeconds;
        
        public override bool CanPerform()
        {
            return VipService.Instance.CanChangeVipTime(EntityInfo, _deltaSeconds);
        }

        public override void Perform()
        {
            VipService.Instance.ChangeVipTime(EntityInfo, _deltaSeconds);
        }
    }
}