using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLab.Problems.Prototype;
public class EnemyPrototypeRegistry
{
    private readonly Dictionary<string, Enemy> _prototypes = new Dictionary<string, Enemy>();

    public void Register(string name , Enemy prototype)
    {
        _prototypes[name] = prototype;
    }

    public Enemy Create(string name)
    {
        if (!_prototypes.TryGetValue(name, out var prototype))
            throw new KeyNotFoundException($"Prototype '{name}' not found.");

        return prototype.Clone();
    }
}
