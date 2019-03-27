#region using

using ShowInfos.Core.Model;

#endregion

namespace ShowInfos.Core.Models
{
    public class Doctors : BaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Education
        /// </summary>
        public string Education { get; set; } = string.Empty;

        /// <summary>
        /// Position
        /// </summary>
        public string Position { get; set; } = string.Empty;

        /// <summary>
        /// Specialty
        /// </summary>
        public string Specialty { get; set; } = string.Empty;

        /// <summary>
        /// Photo
        /// </summary>
        public byte[] Photo { get; set; } = null;

        /// <summary>
        /// Copay
        /// </summary>
        public decimal Copay { get; set; }

        /// <summary>
        /// ClinicTime
        /// </summary>
        public string ClinicTime { get; set; } = string.Empty;
    }
}