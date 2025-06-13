using DevQuestions.Application.Extensions;
using DevQuestions.Application.Questions.Fails.Exceptions;
using DevQuestions.Contacts;
using DevQuestions.Domain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

namespace DevQuestions.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly ILogger<QuestionsService> _logger;
    private readonly IQuestionsRepository _questionsRepository;
    private readonly IValidator<CreateQuestionDto> _validator;
    
    public QuestionsService(ILogger<QuestionsService> logger, IQuestionsRepository questionsRepository, 
        IValidator<CreateQuestionDto> validator)
    {
        _logger = logger;
        _questionsRepository = questionsRepository;
        _validator = validator;
    }

    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new QuestionValidationException(validationResult.ToErrors());
        }

        int openUserQuestionsCount = await _questionsRepository.GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);

        if (openUserQuestionsCount>3)
        {
            throw new ToManyQuestionsException([Fails.Errors.Questions.ToManyQuestions()]);
        }
        var question = new Question
        {
            Id = Guid.NewGuid(),
            Title = questionDto.Title,
            Text = questionDto.Body,
            UserId = questionDto.UserId,
            Tags = questionDto.TagsId
        };
            

        await _questionsRepository.AddAsync(question, cancellationToken);
        _logger.LogInformation("Creating questions...{question.id}",question.Id);
        
        return question.Id;
    }
}