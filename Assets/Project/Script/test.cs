using UnityEngine;
using UnityEngine.SceneManagement;
public class test : MonoBehaviour
{
    public void onclick()
    {
        SceneManager.LoadScene("SimpleScene", LoadSceneMode.Single);
    }
}
