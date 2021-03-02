using System;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectPlatformer
{
    [CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs/SpriteAnimationsConfig", order = 1)]
    internal sealed class SpriteAnimationsConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }
       
        public List<SpriteSequence> Sequences = new List<SpriteSequence>();
    }
}