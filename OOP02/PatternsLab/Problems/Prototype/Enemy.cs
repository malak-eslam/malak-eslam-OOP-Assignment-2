using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLab.Problems.Prototype;


public abstract class Enemy
{
    private string _modelData;

    public string Name { get; set; }
    public int Health { get; set; }
    public Weapon Weapon { get; set; }
    public List<string> Abilities { get; set; } = new();
    public string ModelId => _modelData;

    protected Enemy()
    {
        Console.WriteLine("   ...loading 3D model (slow)...");
        Thread.Sleep(500);
        _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
    }

    protected Enemy(Enemy other)
    {
        Name = other.Name;
        Health = other.Health;
        _modelData = other.ModelId;

        Weapon = new Weapon
        {
            Name = other.Weapon.Name,
            Damage = other.Weapon.Damage
        };

        Abilities = new List<string>(other.Abilities);

    }
    public abstract Enemy Clone();
}





