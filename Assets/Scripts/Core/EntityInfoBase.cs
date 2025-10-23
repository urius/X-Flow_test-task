using UnityEngine;

namespace Core
{
    public abstract class EntityInfoBase<TValue> : EntityInfoBase
    {
    }
    
    public abstract class EntityInfoBase : ScriptableObject
    {
        [SerializeField] private string _name;

        public abstract bool IsUnique { get; }
        public abstract string Key { get; }
        public abstract string FormatValue(string valueStr);

        public string EntityName => _name;
    }
}