using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDoor : MonoBehaviour
{
    public HideInplayer _hideInPlayer;
   public HideZone _hideZone;
    public HideZoneSwich _hideZoneSwich;
    Vector3 ClosePosition;
    Vector3 StartPosition;
    float FullTime;
    private bool Closearrival = false;
    private bool Startarrival = true;

   public AudioClip DoorSuound;
   private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ClosePosition = new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z);
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
            FullTime += Time.deltaTime;
        if (_hideZone.DoorClose && Startarrival && _hideInPlayer.InPlayer)// 플레이어 오면 문닫음
        {
            
            if(FullTime > 1f)
            {
                FullTime = 0f;
            }
            transform.position = Vector3.Lerp(transform.position, ClosePosition, Time.deltaTime * 2f); 
                _hideZoneSwich.SwichOn = false;
            if(transform.position == ClosePosition)
            {
                Closearrival = true;
                Startarrival = false;
            }
        }
         
        if (_hideZoneSwich.SwichOn && Closearrival) // 스위치키면 문열림
        {
            
            if (FullTime > 1f)
            {
                FullTime = 0f;
            }
            transform.position = Vector3.Lerp(transform.position, StartPosition, Time.deltaTime * 2f);
                _hideZone.DoorClose = false;
            _hideInPlayer.InPlayer = false;
            if(transform.position == StartPosition)
            {
                Startarrival = true;
                Closearrival = false;

            }
        }
        


        
        


    }

    

   


  
    

}
