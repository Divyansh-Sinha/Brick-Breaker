using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Parameters
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject blockSparlesVFX;
    [SerializeField] Sprite[] hitSprites;


    // Cached Reference
    Level level;

    //State variable
    [SerializeField] int timesHit;
        
    
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprites();
            }
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().ScoreUpdate();
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        TriggerSparklesVFX();
        Destroy(gameObject);//Destroys the current block.
        level.BlockDestroyed();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparlesVFX,transform.position,transform.rotation); //Create and return a clone of game object.
        Destroy(sparkles, 1f);
    }
}
