using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SpriteData Sprites { get; set; }
        public List<TypeData> Types { get; set; }

    }
}
