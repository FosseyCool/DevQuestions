namespace DevQuestions.Contacts;

public record UpdateQuestionDto(string Title, string Body, Guid[] TagIds);