using UnityEngine;

public class PauseSystem : MonoBehaviour
{
        public bool Pause;
        public GameObject go;


    public void Start()
    {
        Pause = false;
    }
    public void MettrePause()
    {
        Pause = !Pause;
        go.SetActive(Pause);
    
    }
}
