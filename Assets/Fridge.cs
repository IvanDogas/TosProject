using System.Collections;
using UnityEngine;

public class Fridge : MonoBehaviour,IUsable
{ 
    bool opened;
    [SerializeField] float doorOpenTime;
    [SerializeField] float openDegres;

    [SerializeField] Transform doorPivot;
    private void Start()
    {
        opened=false;
    }
    public void UseMechanic(GameObject holdObj)
    {       
        StartCoroutine(RotateDoor());
    }
    public IEnumerator RotateDoor()
    {
        for (float i = 0; i <= doorOpenTime; i+=Time.deltaTime)
        {
            float rotate = opened ? openDegres - (openDegres/doorOpenTime)*i : (openDegres / doorOpenTime) * i;
            doorPivot.localEulerAngles = transform.up * rotate;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        opened = !opened;
    }
}
