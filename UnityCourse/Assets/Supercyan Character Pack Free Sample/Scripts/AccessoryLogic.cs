using UnityEngine;

namespace Supercyan.FreeSample
{
    public class AccessoryLogic : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer m_renderer = null;
        public SkinnedMeshRenderer Renderer { get { return m_renderer; } }


        private void Awake() { }
    }
}