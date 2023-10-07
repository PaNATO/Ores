using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipementScript : MonoBehaviour
{
    public EquipementScript EquipementScriptInstance;
    private void Awake()
    {
        if (EquipementScriptInstance = null)
            EquipementScriptInstance = this;
        else
            Destroy(gameObject);
    }
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
