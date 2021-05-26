using System;

namespace DefaultNamespace.Enemies
{
    public class KingKong : Enemy
    {
        // public override int ApplyDamage(int damage)
        // {
        // var enemys = new List<Enemy>();
        // if (enemy.Top is Enemy enemyTop) 
        //     enemys.Add(enemyTop);
        // if(enemy.Bottom is Enemy enemyBottom)
        //     enemys.Add(enemyBottom);
        // if(enemy.Left is Enemy enemyLeft)
        //     enemys.Add(enemyLeft);
        // if(enemy.Right is Enemy enemyRight)
        //     enemys.Add(enemyRight);
        // }


        public override void Die()
        {
            
            base.Die();
        }
        
    }
}