namespace DevQuestions.Contacts;

public record CreateQuestionDto(string Title, string Text, Guid UserId, Guid[] TagIds);