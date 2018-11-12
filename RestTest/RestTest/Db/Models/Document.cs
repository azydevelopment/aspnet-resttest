using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestTest.Db.Models
{
	[Table("TableDocuments")]
	public class Document
	{
		[Key]
		[Column("Id")]
		public long mId { get; set; }

		[Column("Name", TypeName = "nvarchar(4000)")]
		[Required]
		public string mName { get; set; }

		[Column("Url", TypeName = "char(50)")]
		[Required]
		public string mUrl { get; set; }
	}
}
