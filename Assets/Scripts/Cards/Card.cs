using System;
using System.Collections.Generic;
using DefaultNamespace.Cards.Heroes;
using DefaultNamespace.CardStates;
using UnityEngine;

namespace DefaultNamespace.Cards
{
    public abstract class Card : CardBase, IVisitableCard, IWeightable
    {
        [SerializeField] private Weight weight;
        [SerializeField] private Card emptyCard;
        [SerializeField] private GameObject content;

        public GameObject Content => content;

        public Weight Weight => weight;
        public Card Empty => GetInstanceOf(emptyCard, Game);

        public bool Entered { get; protected set; } = false;

        public abstract void Accept(ICardVisitor visitor);

        public Card GetInstance(Game game)
        {
            return GetInstanceOf(this, game);
        }

        public void UpdateState()
        {
            State = State?.Update();
            Entered = false;
        }

        private Card GetInstanceOf(Card card, Game game)
        {
            var instance = Instantiate(card, transform.position, Quaternion.identity);

            instance.transform.localScale = Vector3.zero;
            instance.Game = game;
            instance.State = new StateCreated(instance);
            return instance;
        }
    }
}