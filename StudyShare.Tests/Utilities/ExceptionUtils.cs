namespace StudyShare.Tests.Utilities
{
    public class ExceptionUtils
    {
        public static void DoesNotThrows<T>(Action expressionUnderTest, string exceptionMessage = "Expected exception was thrown by target of invocation.") where T : Exception
        {
            try
            {
                expressionUnderTest();
            }
            catch (T)
            {
                Assert.Fail(exceptionMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An unexpected exception of type {ex.GetType()} was thrown: {ex.Message}");
            }

        }
    }
}