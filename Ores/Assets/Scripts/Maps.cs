using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maps : MonoBehaviour
{
    public static Maps MapsInstance;
    private void Awake()
    {
        if (MapsInstance == null)
            MapsInstance = this;
        else
            Destroy(gameObject);
    }
    [System.Serializable]
    public class GameMaps
    {
        public string Name;
        public GameObject MapObject;
        [System.Serializable]
        public class Ores
        {
            public string OreName;
            public Sprite OreIcon;
            public int OreMinVal;
            public int OreMaxVal;
            public int ObtainedAmmount;
        }
        public List<Ores> AllOres;
    }
    public List<GameMaps> AllGameMaps;
}
