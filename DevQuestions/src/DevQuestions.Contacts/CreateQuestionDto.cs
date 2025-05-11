namespace DevQuestions.Contacts;

public record CreateQuestionDto(string Title, string Body, Guid UserId, Guid[] TagsId);