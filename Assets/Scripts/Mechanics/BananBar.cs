using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text txt;
    private float _numberOfObjs =30 ;
    public float numberOfObjs => _numberOfObjs;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = _numberOfObjs.ToString();
        //txt.SetText(numberOfObjs.ToString());
    }
    
    public void AddLife() { _numberOfObjs++; txt.text = _numberOfObjs.ToString(); }
    public void RemoveLife() { _numberOfObjs--; txt.text = _numberOfObjs.ToString(); }

}
