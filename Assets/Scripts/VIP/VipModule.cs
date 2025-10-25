using System;
using Core;
using UnityEngine;

namespace VIP
{
    [CreateAssetMenu(fileName = "VIPModule", menuName = "ScriptableObject/Modules/VIPModule")]
    public class VipModule : ModuleBase
    {
        [SerializeField] private VipEntityInfo _vipEntity;
        
        public override void Initialize()
        {
            PlayerData.Instance.RegisterEntity(_vipEntity, defaultValue: TimeSpan.Zero);
            
            VipService.Instance.Initialize(_vipEntity);
        }
    }
}
