using DevQuestions.Application.Exceptions;
using Shared;

namespace DevQuestions.Application.Questions.Fails.Exceptions;

public class ToManyQuestionsException(Error[] errors) : BadRequestException(errors);