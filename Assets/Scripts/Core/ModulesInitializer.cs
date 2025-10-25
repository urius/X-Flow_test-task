using UnityEngine;

namespace Core
{
    public class ModulesInitializer : MonoBehaviour
    {
        [SerializeField] private ModuleBase[] _modules;

        private void Start()
        {
            foreach (var module in _modules)
            {
                module.Initialize();
            }
        }
    }
}