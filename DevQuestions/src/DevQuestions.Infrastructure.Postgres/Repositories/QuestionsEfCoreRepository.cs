using DevQuestions.Application.Questions;
using DevQuestions.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Infrastructure.Postgres.Repositories;

public class QuestionsEfCoreRepository : IQuestionsRepository
{
    private readonly QuestionsDbContext _dbContext;

    public QuestionsEfCoreRepository(QuestionsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

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
        var question = _dbContext.Questions
            .Include(q => q.Answers)
            .Include(q => q.Solution).FirstOrDefaultAsync(q => q.Id == questionId, cancellationToken);
        return question;
    }

    public Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}