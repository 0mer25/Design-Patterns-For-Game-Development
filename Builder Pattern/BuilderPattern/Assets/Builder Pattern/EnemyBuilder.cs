using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder   // Builder Class                                                
{
    /* 
        Builder Pattern is used to build or construct a basic or complex object step by step.
        It is generally used with Factory Pattern to build objects. 

        It is used when 1- Object creation algorithm should be decoupled from the parts that vary.
                        2- A process of constructing an object should allow different representations for the object that is constructed.
                        3- The construction process must allow the object to be constructed step-by-step.
    */
    Enemy enemy = new GameObject("Enemy").AddComponent<Enemy>();

    public void AddWeapon()
    {
        enemy.gameObject.AddComponent<Weapon>();
    }
    public  void AddHealth()
    {
        enemy.gameObject.AddComponent<Health>();
    }

    public Enemy BuildEnemy()
    {
        Enemy builtEnemy = enemy;
        enemy = new GameObject("Enemy").AddComponent<Enemy>();
        return builtEnemy;
    }
}
public class EnemyDirector 
{
    EnemyBuilder enemyBuilder;
    public EnemyDirector(EnemyBuilder enemyBuilder)
    {
        this.enemyBuilder = enemyBuilder;
    }
    public Enemy ConstructEnemy(EnemyData enemyData)        // Build Enemy with Health and Weapon (Change here in according to your requirement)
    {
        enemyBuilder.AddHealth();
        enemyBuilder.AddWeapon();
        return enemyBuilder.BuildEnemy();
    }
}

public class Enemy : MonoBehaviour
{

}
public class Health : MonoBehaviour
{
    public Health health;
}
public class Weapon : MonoBehaviour
{
    public Weapon weapon;
}
public class EnemyData
{
    public Health health;
    public Weapon weapon;
}
