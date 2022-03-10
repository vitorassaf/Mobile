using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class configuracao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Chamarcena()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

}
