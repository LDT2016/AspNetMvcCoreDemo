#region using

using ShowInfos.Core.Model;

#endregion

namespace ShowInfos.Core.Models
{
    public class NamedEntity : BaseEntity
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}