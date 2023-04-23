using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCutscene : MonoBehaviour
{
    public GameObject prefab_obj;   //플레이어가 죽으면 그 자리에 소환될 시체
    public GameObject deathCam;     //플레이어가 죽으면 플레이어를 비출 카메라
    public GameObject playerCam;    //플레이어 카메라
    public float DeathCamHeight;
    public float offset;
    public float speed;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    { 
        player = GameObject.FindWithTag("Player");
        deathCam = GameObject.Find("DeathCam");
        deathCam.GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject obj = MonoBehaviour.Instantiate(prefab_obj);

            obj.name = "playerDeath";

            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = player.transform.position.z;

            obj.transform.position= new Vector3(x, y, z);

            deathCam.GetComponent<Camera>().enabled=true;
            deathCam.transform.position =new Vector3(x,y+offset,z);

            Vector3 Position = deathCam.transform.position;
            Vector3 newPosition = new Vector3(x, DeathCamHeight, z);
            StartCoroutine(DeathCamMoveUp(Position,newPosition));

        }
    }

    IEnumerator DeathCamMoveUp(Vector3 Position,Vector3 newPosition)
    {
        WaitForSeconds interval = new WaitForSeconds(0.001f);

        Vector3 CameraPos = new Vector3(0, 0, 0);
        float x=Position.x;
        float y=Position.y;
        float z=Position.z;

        float t = 0.0f;

        while (Mathf.Abs(y-newPosition.y)>Mathf.Epsilon)
        {
            print(deathCam.transform.position.y);
            y = Mathf.Lerp(y, newPosition.y, t);
            CameraPos.Set(x, y, z);
            deathCam.transform.position=CameraPos;

            t += speed * Time.deltaTime;

            deathCam.transform.rotation=Quaternion.Euler(t*200,0,0);

            if (deathCam.transform.position.y == DeathCamHeight)   //카메라가 다 올라가면 플레이어 비활성화
            {
                player.SetActive(false);
                
            }
            yield return interval;
        }
        
    }
}
