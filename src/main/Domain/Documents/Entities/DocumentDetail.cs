using Domain.Base;
using Domain.Documents.Events;
using Domain.Enums;

namespace Domain.Documents.Entities;

public class DocumentDetail : BaseAuditableEntity
{
	public int DocumentId { get; set; }

	public string Text { get; set; } = default!;

	public PriorityLevel Priority { get; set; }

	private bool _solved;
	public bool Solved
	{
		get => _solved;
		set
		{
			// transition from not solved to solved
			if (value && !_solved)
				AddDomainEvent(new DocumentDetailSolvedEvent(this));

			_solved = value;
		}
	}

	public Document Document { get; set; } = default!;
}
