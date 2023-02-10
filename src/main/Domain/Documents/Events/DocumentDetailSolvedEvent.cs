using Domain.Base;
using Domain.Documents.Entities;

namespace Domain.Documents.Events;

public class DocumentDetailSolvedEvent : BaseEvent
{
	public DocumentDetail DocumentDetail { get; init; }

	public DocumentDetailSolvedEvent(DocumentDetail documentDetail)
	{
		DocumentDetail = documentDetail;
	}
}
