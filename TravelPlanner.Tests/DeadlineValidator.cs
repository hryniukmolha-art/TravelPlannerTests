
using System;

namespace TravelPlanner.Tests;

public static class DeadlineValidator
{
    /// <summary>
    /// Перевіряє, чи не перевищує дедлайн тікета
    /// дедлайн етапу проєкту.
    /// </summary>
    public static bool IsDeadlineValid(
        DateTime ticketDeadline,
        DateTime stageDeadline)
    {
        bool isValid = ticketDeadline <= stageDeadline;
        return isValid;
    }
}
