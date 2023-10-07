using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class MiningSystem : MonoBehaviour
{
    public static MiningSystem MiningSystemInstance;
    private void Awake()
    {
        if (MiningSystemInstance == null)
            MiningSystemInstance = this;
        else
            Destroy(gameObject);
    }
    [SerializeField]
    public RectTransform Spawner;
    public TextMeshProUGUI MinesDone;
    public TextMeshProUGUI MinesNeeded;
    public GameObject CurrentMapObj;
    //private string CurrentMap = "GrassMap";
    public long MineHitsNeeded = 10;
    public long CurrentMineHits = 0;
    public string CurrentMapHit;
    public float time;
    public float TimeToR;
    Vector2 TargetPos = new Vector2(3.7f, 3.7f);
   /* Deprecated 12.12.2022 public bool MapObjCheck()
    {
        CurrentMapObj = GameObject.Find(CurrentMap);
        if(CurrentMapObj != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/
    public void MineOnClick()
    {
        if(Input.GetMouseButtonDown(0) 
            && !EventSystem.current.IsPointerOverGameObject() 
            && CurrentMapHit == CurrentMapObj.name)
        {
            CurrentMineHits += 1;
        }

        if(CurrentMineHits >= MineHitsNeeded)
        {
            OreAdder();
            CurrentMineHits = 0;
            NumberGenerator.NumberGeneratorInstance.NumberGeneratorA();
        }
    }
    public void OreAdder()
    {
        foreach(var maps in Maps.MapsInstance.AllGameMaps)
        {
            foreach(var ores in maps.AllOres)
            {
                foreach(var numbers in NumberGenerator.NumberGeneratorInstance.NumbersAm)
                {
                    if(numbers.Number >= ores.OreMinVal && numbers.Number <= ores.OreMaxVal && maps.Name == CurrentMapHit)
                    {
                        Vector3 mVec = new Vector3(Random.Range(-3, 3), Random.Range(-3,3), 0);
                        ores.ObtainedAmmount += 1;
                        GameObject ore = new GameObject("DroppedOre");
                        ore.tag = "Ore";
                        ore.AddComponent<Rigidbody>();
                        ore.AddComponent<BoxCollider>();
                        ore.GetComponent<Rigidbody>().drag = 1;
                        ore.GetComponent<Rigidbody>().mass = 1;
                        ore.GetComponent<Rigidbody>().AddForce(Random.Range(-6,6),Random.Range(1,6),0, ForceMode.Impulse);
                        SpriteRenderer render = ore.AddComponent<SpriteRenderer>();
                        Vector3 vec3 = new Vector3(0.10f, 0.10f, 0);
                        render.transform.position = mVec;
                        render.transform.localScale = vec3;
                        render.sprite = ores.OreIcon;
                       // GameObject.Instantiate(ores.OreIcon, mVec, Quaternion.identity, Spawner);
                    }
                }
            }
        }
    }
    /*private void DroppedDelete()
    { 
        if (GameObject.Find("DroppedOre"))
        {
            GameObject.Destroy(GameObject.Find("DroppedOre"));
        }
    }*/
    //Funkcja Piotrka do przesuwania obiektów
    /*class CurrentOre 
    { 
        public GameObject GameObject;
        public Vector3 Vector3;
    }

    CurrentOre[] gameObjects;
    private void DropMove()
    {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Ore")) 
        {
            if (gameObjects != null)
            {
                bool Tak_jest = false;
                //Sprawdź czy już jes na liście
                foreach (CurrentOre gameObject2 in gameObjects)
                {
                    if (gameObject == gameObject2.GameObject)
                    {
                        Tak_jest = true;
                        time += Time.deltaTime / TimeToR;
                        gameObject.transform.position = Vector2.Lerp(gameObject2.Vector3, TargetPos, time);
                    }
                }
                if (!Tak_jest)
                {
                    //To dodaj do listy
                    CurrentOre[] tmp = new CurrentOre[gameObjects.Length];

                    for (int i = 0; i < gameObjects.Length; i++)
                    {
                        tmp[i] = gameObjects[i];
                    }

                    gameObjects = new CurrentOre[tmp.Length + 1];

                    for (int i = 0; i < tmp.Length; i++)
                    {
                        gameObjects[i] = tmp[i];
                    }

                    gameObjects[gameObjects.Length - 1] = new CurrentOre();
                    gameObjects[gameObjects.Length - 1].GameObject = gameObject;
                    gameObjects[gameObjects.Length - 1].Vector3 = gameObject.transform.position;
                }
            }
            else
            {
                gameObjects = new CurrentOre[1];
                gameObjects[0] = new CurrentOre();
                gameObjects[0].GameObject = gameObject;
                gameObjects[0].Vector3 = gameObject.transform.position;
            }
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        //MapObjCheck();
        NumberGenerator.NumberGeneratorInstance.NumberGeneratorA();
        //InvokeRepeating("DroppedDelete", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D Hit = Physics2D.Raycast(MousePosition, Vector2.zero);
            if (Hit.collider != null && !EventSystem.current.IsPointerOverGameObject())
            {
                CurrentMapHit = Hit.collider.name;
            }
            else
            {
                CurrentMapHit = "None";
            }
        }

        MineOnClick();
        MinesDone.SetText(CurrentMineHits.ToString());
        MinesNeeded.SetText(MineHitsNeeded.ToString());
        //DropMove();
    }
}
