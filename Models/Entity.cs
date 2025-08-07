using Interfaces.Entities;
using System.ComponentModel.Composition;

namespace Models
{
    public class Entity : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Entity: Id = {Id}, Name = {Name}";
        }
    }

}
