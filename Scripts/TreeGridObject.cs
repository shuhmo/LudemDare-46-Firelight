using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGridObject : GridObject
{
   
    int _treeHp = 3;
    bool _isDead;
    int _woodYield = 1;
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    [SerializeField]
    GameObject _WoodTopHalf;

    [SerializeField]
    Sprite _deadLogSprite;

    private void Awake()
    {
        base.Awake();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
       
    }
   
    public override void OnGridObjectInteract(Player player)
    {
        if (!_isDead && player.hasSpaceInInventory())
        {

            takeDamage(1);
            _animator?.SetTrigger("Tree Shaking");
            if (_treeHp <= 0)
            {
                OnTreeDie(player);
            }
        }

        
    }
    private void takeDamage(int amount) {
        _treeHp -= amount;
        Debug.Log($"Tree takes {1} dmg!");
    }

    private void OnTreeDie(Player player) {
        _isDead = true;
        _spriteRenderer.sprite = _deadLogSprite;
        player.addWoodToInventory(_woodYield);
        _WoodTopHalf.SetActive(false);
        Debug.Log("Tree dies!");
    }

    
}
