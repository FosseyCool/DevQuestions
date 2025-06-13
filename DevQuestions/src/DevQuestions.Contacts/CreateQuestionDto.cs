namespace DevQuestions.Contacts;

public record CreateQuestionDto(string Title, string Body, Guid UserId, List<Guid[]> TagsId);