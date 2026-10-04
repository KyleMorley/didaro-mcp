namespace Didaro.Mcp.Dtos;

public sealed record AssignmentEvaluationResponse(
    Guid EvaluationId,
    AssignmentEvaluationResultResponse Result);

public sealed record AssignmentEvaluationResultResponse(
    string SummaryFeedback,
    IReadOnlyList<AssignmentCriterionFeedbackResponse> Scores,
    string ModelVersion);

public sealed record AssignmentCriterionFeedbackResponse(
    string Criterion,
    string Level,
    string Feedback);