using DevQuestions.Application.Questions;
using DevQuestions.Domain.Questions;

namespace DevQuestions.Infrastructure.Postgres.Repositories;

public class QuestionsSqlRepository : IQuestionsRepository
{
    public Task<Guid> AddAsync(Question question, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> DeleteAsync(Guid questionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Question?> GetByIdAsync(Guid questionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}