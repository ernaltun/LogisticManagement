using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LogisticManagement.Entity
{
	public class Permit
	{
		[Key]
		public int PermitId { get; set; }
        public bool IsApproval { get; set; }
        public DateTime PermitStart { get; set; }
        public DateTime PermitFinish { get; set; }
        public string Description { get; set; }
        public string PermitType { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
