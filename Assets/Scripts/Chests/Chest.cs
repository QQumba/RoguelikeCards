﻿using System.Security.Cryptography.X509Certificates;

namespace DefaultNamespace.Chests
{
    public abstract class Chest : Card
    {
       public override bool TryEnter(Hero hero)
       {
           Open();
           return false;
       }

       public virtual void Open()
       {
           Destroy(this.gameObject);
       }
    }
}