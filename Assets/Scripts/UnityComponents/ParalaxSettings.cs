using UnityEngine;

namespace UnityComponents
{
    [CreateAssetMenu(menuName = "ParalaxSettings", fileName = "ParalaxSettings")]
    public class ParalaxSettings : ScriptableObject
    {
        [SerializeField] private float startSpeed;
        [SerializeField] private float translationLength;
        [SerializeField] private float startX1;
        [SerializeField] private float startX2;


        public float TranslationLength => translationLength;

        public float StartSpeed => startSpeed;

        public float StartX1 => startX1;

        public float StartX2 => startX2;
    }
}