using Core;
using UnityEngine;

namespace VIP
{
    [CreateAssetMenu(fileName = "ChangeVipTimeAction", menuName = "ScriptableObject/Actions/ChangeVipTimeAction")]
    public class ChangeVipTimeAction : EntityActionBase
    {
        [SerializeField] private int _deltaSeconds;
        
        public override bool CanPerform()
        {
            return VipController.Instance.CanChangeVipTime(_deltaSeconds);
        }

        public override void Perform()
        {
            VipController.Instance.ChangeVipTime(_deltaSeconds);
        }
    }
}