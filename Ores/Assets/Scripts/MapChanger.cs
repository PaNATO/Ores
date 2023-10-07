using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapChanger : MonoBehaviour
{
    public static MapChanger MapChangerInstance;
    private void Awake()
    {
        if (MapChangerInstance == null)
            MapChangerInstance = this;
        else
            Destroy(gameObject);
    }
    [SerializeField]
    public string MapName;
    public void SetMap()
    {
        MapName = EventSystem.current.currentSelectedGameObject.name;
        MapChange();
    }
    public void MapChange()
    {
        foreach(var maps in Maps.MapsInstance.AllGameMaps)
        {
            if (maps.MapObject.name != MapName)
                maps.MapObject.SetActive(false);
            else
            maps.MapObject.SetActive(true);
            MiningSystem.MiningSystemInstance.CurrentMapObj = GameObject.Find(MapName);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
