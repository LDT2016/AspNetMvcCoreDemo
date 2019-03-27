using System;
using System.Data;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// 实体类 Show_Doctors, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [DataContract]
    [Serializable]
    public class Show_Doctors : ICloneable
    {
        public Show_Doctors()
        { }

        #region 实体属性

        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public int? Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Education
        /// </summary>
        [DataMember]
        public string Education { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Specialty
        /// </summary>
        [DataMember]
        public string Specialty { get; set; }

        /// <summary>
        /// Photo
        /// </summary>
        [DataMember]
        public byte[] Photo { get; set; }

        /// <summary>
        /// Copay
        /// </summary>
        [DataMember]
        public double? Copay { get; set; }

        /// <summary>
        /// ClinicTime
        /// </summary>
        [DataMember]
        public string ClinicTime { get; set; }

        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public override bool Equals(object obj)
        {
            Model.Show_Doctors model = obj as Model.Show_Doctors;
            if (model != null && model.Id == this.Id)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}