using System;
using System.Collections.Generic;

namespace Core
{
    public class PlayerData
    {
        public event Action<string> ValueChanged;
        
        public static readonly PlayerData Instance = new();

        private readonly Dictionary<string, int> _intValuesByEntityKey = new();
        private readonly Dictionary<string, string> _stringValuesByEntityKey = new();

        public int GetIntValue(string entityKey)
        {
            _intValuesByEntityKey.TryGetValue(entityKey, out var result);

            return result;
        }
        
        public void SetIntValue(string entityKey, int value)
        {
            _intValuesByEntityKey[entityKey] = value;
            
            ValueChanged?.Invoke(entityKey);
        }
        
        public string GetStrValue(string entityKey)
        {
            if (_stringValuesByEntityKey.TryGetValue(entityKey, out var result))
            {
                return result;
            }
            
            if (_intValuesByEntityKey.TryGetValue(entityKey, out var resultInt))
            {
                return resultInt.ToString();
            }

            return string.Empty;
        }
        
        public void SetStrValue(string entityKey, string value)
        {
            _stringValuesByEntityKey[entityKey] = value;
            
            ValueChanged?.Invoke(entityKey);
        }
    }
}