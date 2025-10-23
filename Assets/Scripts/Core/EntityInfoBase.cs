using UnityEngine;

namespace Core
{
    public abstract class EntityInfoBase<TValue> : EntityInfoBase
    {
    }
    
    public abstract class EntityInfoBase : ScriptableObject
    {
        [SerializeField] private string _name;

        public abstract string Key { get; }
        public abstract string GetStringValue();

        public string EntityName => _name;
    }
}