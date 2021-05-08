using DefaultNamespace;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private bool _isHeroMoving;

    public Game Game;
    
    private void Start()
    {
        _isHeroMoving = false;
    }

    private void Update()
    {
     
    }

    public void MoveHero(Card card)
    {
        if (_isHeroMoving) return;
        
        Game.SwapCards(card, Game.Hero);
    }
}
