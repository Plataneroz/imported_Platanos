using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
public class ChancletaDugeon : MonoBehaviour
{
    [SerializeField] Text txt;
    private float _numberOfObjs;
    public float numberOfObjs => _numberOfObjs;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = _numberOfObjs.ToString();
        //txt.SetText(numberOfObjs.ToString());
    }

    public void AddToDungeon() { _numberOfObjs++; txt.text = _numberOfObjs.ToString(); }
    public void RemoveFromDungeon() { _numberOfObjs--; txt.text = _numberOfObjs.ToString(); }

 }
