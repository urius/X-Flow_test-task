using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "HealthEntityInfo", menuName = "ScriptableObject/EntityInfo/HealthEntityInfo")]
    internal class HealthEntityInfo : EntityInfoBase<int>
    {
        public const string EntityKey = "Health";

        public override bool IsUnique => false;
        public override string Key => EntityKey;
        
        public override string FormatValue(string valueStr)
        {
            return string.IsNullOrEmpty(valueStr) ? "0" : valueStr;
        }
    }
}