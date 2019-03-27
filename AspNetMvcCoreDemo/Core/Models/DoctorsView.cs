namespace ShowInfos.Core.Models
{
    public class DoctorsView
    {
        /// <summary>
        /// WorkNum
        /// </summary>
        public string WorkNum { get; set; } = string.Empty;

        /// <summary>
        /// EmplyeeName
        /// </summary>
        public string EmplyeeName { get; set; } = string.Empty;

        /// <summary>
        /// Position
        /// </summary>
        public string Position { get; set; } = string.Empty;

        /// <summary>
        /// Photo
        /// </summary>
        public string PhotoPath { get; set; }

        /// <summary>
        /// CompanyId
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// DepartmentId
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// RemarkScore
        /// </summary>
        public int? RemarkScore { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// DepartName
        /// </summary>
        public string DepartName { get; set; } = string.Empty;
    }
}