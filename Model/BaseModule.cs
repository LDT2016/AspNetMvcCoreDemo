using System.Runtime.Serialization;

namespace Model
{
    public class BaseModule
    {
        [DataMember]
        public string Id { get; set; }
        
        [DataMember]
        public string FullName { get; set; }
        
        [DataMember]
        public string NavigateUrl { get; set; }
        
        [DataMember]
        public string ParentId { get; set; }
        
        [DataMember]
        public string ImageIndex { get; set; }
        
    }
}
