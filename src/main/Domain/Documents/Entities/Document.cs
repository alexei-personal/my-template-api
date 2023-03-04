using Domain.Base;
using Domain.ValueObjects;

namespace Domain.Documents.Entities;

public class Document : BaseAuditableEntity
{
	public string Code { get; set; } = default!;

	public string Title { get; set; } = default!;

	public Color? CategoryColor { get; set; }

	public bool IsActive { get; set; }

	public IList<DocumentDetail>? DocumentDetail { get; set; }
}
