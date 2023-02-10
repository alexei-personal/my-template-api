using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Base;

[Table("#TempId")]
public class TempId
{
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public int Id { get; set; }
}
